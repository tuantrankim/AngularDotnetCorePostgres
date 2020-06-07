using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDotnetCore.Services
{
    public class EmailSender : IEmailSender
    {
        private string _smtpServer;
        private int _smtpPort;
        private string _fromAddress;
        private string _fromAddressTitle;
        private string _username;
        private string _password;
        private bool _enableSsl;
        private bool _useDefaultCredentials;
        public EmailSender(IConfiguration configuration) // configuration is automatically added to DI in ASP.NET Core 3.0
        {
            _smtpServer = configuration["Email:SmtpServer"];
            _smtpPort = int.Parse(configuration["Email:SmtpPort"]);
            _smtpPort = _smtpPort == 0 ? 25 : _smtpPort;
            _fromAddress = configuration["Email:FromAddress"];
            _fromAddressTitle = configuration["FromAddressTitle"];
            _username = configuration["Email:SmtpUsername"];
            _password = configuration["Email:SmtpPassword"];
            _enableSsl = bool.Parse(configuration["Email:EnableSsl"]);
            _useDefaultCredentials = bool.Parse(configuration["Email:UseDefaultCredentials"]);
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var mimeMessage = new MimeMessage(); // MIME : Multipurpose Internet Mail Extension
            mimeMessage.From.Add(new MailboxAddress(_fromAddressTitle, _fromAddress));
            mimeMessage.To.Add(new MailboxAddress(email));
            mimeMessage.Subject = subject;

            var bodyBuilder = new MimeKit.BodyBuilder
            {
                HtmlBody = htmlMessage
            };

            mimeMessage.Body = bodyBuilder.ToMessageBody();
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect(_smtpServer, _smtpPort, _enableSsl);
                client.Authenticate(_username, _password); // If using GMail this requires turning on LessSecureApps : https://myaccount.google.com/lesssecureapps
                client.Send(mimeMessage);
                client.Disconnect(true);
            }
            return Task.FromResult(0);
        }

    }
}
