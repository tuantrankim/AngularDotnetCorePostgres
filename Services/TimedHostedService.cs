using System;
using System.Threading;
using System.Threading.Tasks;
using AngleSharp.Html.Parser;
using AngularDotnetCore.Data;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Linq;
using AngleSharp;
using AngleSharp.Dom;
using Microsoft.Extensions.DependencyInjection;
using AngularDotnetCore.Models;
using System.Collections.Generic;
using AngularDotnetCore.Migrations;
using AngleSharp.Text;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace AngularDotnetCore.Services
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        private int executionCount = 0;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<TimedHostedService> _logger;
        private Timer _timer;
        private List<Category> categories = null;

        private bool _enabled = false;
        private bool _immediate = false;
        private int _interval = 0;//second
        private DateTime _scheduledTime = DateTime.Now;
        private string _userId;
        public TimedHostedService(IConfiguration configuration, ILogger<TimedHostedService> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
            try
            {
                _enabled = bool.Parse(configuration["Scheduler:Enabled"]);
                _immediate = bool.Parse(configuration["Scheduler:Immediate"]);
                _interval = int.Parse(configuration["Scheduler:Interval"]);
                _scheduledTime = DateTime.Parse(configuration["Scheduler:ScheduledTime"]);
                _userId = configuration["Scheduler:UserId"];
            }
            catch (Exception ex)
            {
                _enabled = false;
                _logger.LogError(ex.ToString());
            }
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Scheduler Service running.");
           

            using (var scope = _scopeFactory.CreateScope())
            {
                try
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    if (!_enabled && !string.IsNullOrEmpty(_userId))
                    {
                        dbContext.EventLogs.Add(new EventLog
                        {
                            Message = "Scheduler is disabled",
                            EventType = "scheduler",
                            CreatedDate = DateTime.Now
                        });
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        dbContext.EventLogs.Add(new EventLog
                        {
                            Message = "Scheduler is starting",
                            EventType = "scheduler",
                            CreatedDate = DateTime.Now
                        });
                        dbContext.SaveChanges();

                        categories = dbContext.Categories.ToList();
                                                
                        if (_immediate)
                        {
                            DoWork(null);
                        }

                        int interval = _interval * 1000;//milliseconds
                        int delay = (int)(((_scheduledTime - DateTime.Now).TotalMilliseconds) % interval + interval) % interval;
                        _logger.LogInformation("Scheduler delay {0} ms", delay);
                        _timer = new Timer(DoWork, null, delay, interval);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.ToString());
                }
            }

            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {
            var count = Interlocked.Increment(ref executionCount);

            _logger.LogInformation(
                "Scheduler Service is working. Count: {Count}", count);

            await GetContent();

        }

        private async Task GetContent()
        {
            try
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    DateTime startTime = DateTime.Now;
                    dbContext.EventLogs.Add(new EventLog
                    {
                        Message = "Start. Crawling content: ",
                        EventType = "scheduler",
                        CreatedDate = DateTime.Now
                    });
                    foreach (Category c in categories)
                    {
                        if (string.IsNullOrEmpty(c.ExternalUrl)) continue;
                        dbContext.EventLogs.Add(new EventLog
                        {
                            Message = "Start. Crawling for category: " + c.Name + " from " + c.ExternalUrl,
                            EventType = "scheduler",
                            CreatedDate = DateTime.Now
                        });

                        try
                        {
                            

                            int categoryId = c.Id;
                            string[] urls = c.ExternalUrl.SplitCommas();
                            foreach (string url in urls)
                            {
                                var config = Configuration.Default.WithDefaultLoader();
                                var context = BrowsingContext.New(config);
                                //string url = "https://mraovat.nguoi-viet.com/classified/phong-cho-thue-rooms-to-share-browse-88.aspx";
                                var document = await context.OpenAsync(url);

                                //var selectedItems = document.All.Where(m => m.LocalName == "td" && m.ClassList.Contains("TBLRoll"));
                                //view mor selectors syntax at
                                //https://www.w3schools.com/cssref/css_selectors.asp
                                //OR
                                var selectedItems = document.QuerySelectorAll("table.listingsTBL td");
                                //string userId = "3eb8064b-f4cd-480c-9e4c-f18d0cbadcc3";
                                foreach (var item in selectedItems)
                                {
                                    if (item.QuerySelector("div.ListingNewNDate>img") != null)
                                    {
                                        string title = item.QuerySelector("div.ListingDescription>a").Text().Trim();
                                        string datetime = item.QuerySelector("div.ListingNewNDate>span").Text();

                                        Post model = new Post
                                        {
                                            OwnerId = _userId,
                                            CreatedDate = DateTime.Now,
                                            ModifiedDate = DateTime.Now,
                                            Title = title,
                                            Content = null,
                                            CityId = null,
                                            CategoryId = categoryId,
                                            PostalCode = null,
                                            ContactEmail = null,
                                            ContactPhone = null
                                        };

                                        dbContext.Posts.Add(model);
                                    }
                                }
                            }

                            dbContext.EventLogs.Add(new EventLog
                            {
                                Message = "Done. Crawling for category: " + c.Name + " from " + c.ExternalUrl,
                                EventType = "scheduler",
                                CreatedDate = DateTime.Now
                            });
                            var result = await dbContext.SaveChangesAsync();
                        }
                        catch (Exception ex1)
                        {
                            dbContext.EventLogs.Add(new EventLog
                            {
                                Message = "Error. Crawling for category: " + c.Name + " from " + c.ExternalUrl,
                                EventType = "scheduler",
                                CreatedDate = DateTime.Now
                            });
                            var result1 = await dbContext.SaveChangesAsync();
                        }
                    }

                    dbContext.EventLogs.Add(new EventLog
                    {
                        Message = "End. Crawling content: " + (DateTime.Now - startTime).TotalSeconds + " (s)",
                        EventType = "scheduler",
                        CreatedDate = DateTime.Now
                    });
                    var result2 = await dbContext.SaveChangesAsync();

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
