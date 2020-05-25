using AngularDotnetCore.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDotnetCore.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Post> Posts { get; set; }

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        void LoadStatesWithCities(ref ModelBuilder builder)
        {
            List<State> states = new List<State>();
            List<City> cities = new List<City>();

            var myJsonString = File.ReadAllText(@"Data\states.json");
            var myJObject = JObject.Parse(myJsonString);

            int stateId = 0;
            int cityId = 0;
            foreach (JProperty state in myJObject.Properties())
            {
                String abbreviation = state.Name;
                string stateName = state.Value.SelectToken("name").ToString();
                var citiesJObject = state.Value.SelectToken("cities") as JObject;
                stateId++;
                states.Add(new State { Id = stateId, Abbreviation = abbreviation, Name = stateName });

                foreach (JProperty city in citiesJObject.Properties())
                {
                    cityId++;
                    cities.Add(new City { StateId = stateId, Id = cityId, Name = city.Name });
                }
            }

            builder.Entity<State>().HasData(states);
            builder.Entity<City>().HasData(cities);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<City>(entity =>
            {
                entity.HasOne(c => c.State)
                    .WithMany(s => s.Cities)
                    .HasForeignKey("StateId");
            });

            //builder.Entity<State>(entity =>
            //{
            //    entity.HasMany(s => s.Cities)
            //        .WithOne(c => c.State)
            //        .HasForeignKey("StateId");
            //});

            LoadStatesWithCities(ref builder);

            base.OnModelCreating(builder);

            /*
            //States populate
            builder.Entity<State>().HasData(new State { Id = 1, Abbreviation = "AL", Name = "Alabama" });
           builder.Entity<State>().HasData(new State { Id = 2, Abbreviation = "AK", Name = "Alaska" });
           builder.Entity<State>().HasData(new State { Id = 3, Abbreviation = "AS", Name = "American Samoa" });
           builder.Entity<State>().HasData(new State { Id = 4, Abbreviation = "AZ", Name = "Arizona" });
           builder.Entity<State>().HasData(new State { Id = 5, Abbreviation = "AR", Name = "Arkansas" });
           builder.Entity<State>().HasData(new State { Id = 6, Abbreviation = "CA", Name = "California" });
           builder.Entity<State>().HasData(new State { Id = 7, Abbreviation = "CO", Name = "Colorado" });
           builder.Entity<State>().HasData(new State { Id = 8, Abbreviation = "CT", Name = "Connecticut" });
           builder.Entity<State>().HasData(new State { Id = 9, Abbreviation = "DE", Name = "Delaware" });
           builder.Entity<State>().HasData(new State { Id = 10, Abbreviation = "DC", Name = "District Of Columbia" });
           builder.Entity<State>().HasData(new State { Id = 11, Abbreviation = "FM", Name = "Federated States Of Micronesia" });
           builder.Entity<State>().HasData(new State { Id = 12, Abbreviation = "FL", Name = "Florida" });
           builder.Entity<State>().HasData(new State { Id = 13, Abbreviation = "GA", Name = "Georgia" });
           builder.Entity<State>().HasData(new State { Id = 14, Abbreviation = "GU", Name = "Guam" });
           builder.Entity<State>().HasData(new State { Id = 15, Abbreviation = "HI", Name = "Hawaii" });
           builder.Entity<State>().HasData(new State { Id = 16, Abbreviation = "ID", Name = "Idaho" });
           builder.Entity<State>().HasData(new State { Id = 17, Abbreviation = "IL", Name = "Illinois" });
           builder.Entity<State>().HasData(new State { Id = 18, Abbreviation = "IN", Name = "Indiana" });
           builder.Entity<State>().HasData(new State { Id = 19, Abbreviation = "IA", Name = "Iowa" });
           builder.Entity<State>().HasData(new State { Id = 20, Abbreviation = "KS", Name = "Kansas" });
           builder.Entity<State>().HasData(new State { Id = 21, Abbreviation = "KY", Name = "Kentucky" });
           builder.Entity<State>().HasData(new State { Id = 22, Abbreviation = "LA", Name = "Louisiana" });
           builder.Entity<State>().HasData(new State { Id = 23, Abbreviation = "ME", Name = "Maine" });
           builder.Entity<State>().HasData(new State { Id = 24, Abbreviation = "MH", Name = "Marshall Islands" });
           builder.Entity<State>().HasData(new State { Id = 25, Abbreviation = "MD", Name = "Maryland" });
           builder.Entity<State>().HasData(new State { Id = 26, Abbreviation = "MA", Name = "Massachusetts" });
           builder.Entity<State>().HasData(new State { Id = 27, Abbreviation = "MI", Name = "Michigan" });
           builder.Entity<State>().HasData(new State { Id = 28, Abbreviation = "MN", Name = "Minnesota" });
           builder.Entity<State>().HasData(new State { Id = 29, Abbreviation = "MS", Name = "Mississippi" });
           builder.Entity<State>().HasData(new State { Id = 30, Abbreviation = "MO", Name = "Missouri" });
           builder.Entity<State>().HasData(new State { Id = 31, Abbreviation = "MT", Name = "Montana" });
           builder.Entity<State>().HasData(new State { Id = 32, Abbreviation = "NE", Name = "Nebraska" });
           builder.Entity<State>().HasData(new State { Id = 33, Abbreviation = "NV", Name = "Nevada" });
           builder.Entity<State>().HasData(new State { Id = 34, Abbreviation = "NH", Name = "New Hampshire" });
           builder.Entity<State>().HasData(new State { Id = 35, Abbreviation = "NJ", Name = "New Jersey" });
           builder.Entity<State>().HasData(new State { Id = 36, Abbreviation = "NM", Name = "New Mexico" });
           builder.Entity<State>().HasData(new State { Id = 37, Abbreviation = "NY", Name = "New York" });
           builder.Entity<State>().HasData(new State { Id = 38, Abbreviation = "NC", Name = "North Carolina" });
           builder.Entity<State>().HasData(new State { Id = 39, Abbreviation = "ND", Name = "North Dakota" });
           builder.Entity<State>().HasData(new State { Id = 40, Abbreviation = "MP", Name = "Northern Mariana Islands" });
           builder.Entity<State>().HasData(new State { Id = 41, Abbreviation = "OH", Name = "Ohio" });
           builder.Entity<State>().HasData(new State { Id = 42, Abbreviation = "OK", Name = "Oklahoma" });
           builder.Entity<State>().HasData(new State { Id = 43, Abbreviation = "OR", Name = "Oregon" });
           builder.Entity<State>().HasData(new State { Id = 44, Abbreviation = "PW", Name = "Palau" });
           builder.Entity<State>().HasData(new State { Id = 45, Abbreviation = "PA", Name = "Pennsylvania" });
           builder.Entity<State>().HasData(new State { Id = 46, Abbreviation = "PR", Name = "Puerto Rico" });
           builder.Entity<State>().HasData(new State { Id = 47, Abbreviation = "RI", Name = "Rhode Island" });
           builder.Entity<State>().HasData(new State { Id = 48, Abbreviation = "SC", Name = "South Carolina" });
           builder.Entity<State>().HasData(new State { Id = 49, Abbreviation = "SD", Name = "South Dakota" });
           builder.Entity<State>().HasData(new State { Id = 50, Abbreviation = "TN", Name = "Tennessee" });
           builder.Entity<State>().HasData(new State { Id = 51, Abbreviation = "TX", Name = "Texas" });
           builder.Entity<State>().HasData(new State { Id = 52, Abbreviation = "UT", Name = "Utah" });
           builder.Entity<State>().HasData(new State { Id = 53, Abbreviation = "VT", Name = "Vermont" });
           builder.Entity<State>().HasData(new State { Id = 54, Abbreviation = "VI", Name = "Virgin Islands" });
           builder.Entity<State>().HasData(new State { Id = 55, Abbreviation = "VA", Name = "Virginia" });
           builder.Entity<State>().HasData(new State { Id = 56, Abbreviation = "WA", Name = "Washington" });
           builder.Entity<State>().HasData(new State { Id = 57, Abbreviation = "WV", Name = "West Virginia" });
           builder.Entity<State>().HasData(new State { Id = 58, Abbreviation = "WI", Name = "Wisconsin" });
           builder.Entity<State>().HasData(new State { Id = 59, Abbreviation = "WY", Name = "Wyoming" });
           //End states populate

           builder.Entity<City>().HasData(new City { StateId = 1, Id = 1, Name = "Anaheim" });
           builder.Entity<City>().HasData(new City { StateId = 1, Id = 2, Name = "Fountain Valley"});


            base.OnModelCreating(builder);
            */

        }
    }
}
