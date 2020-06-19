﻿using AngularDotnetCore.Models;
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
        public DbSet<EventLog> EventLogs { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<CategoryGroup> CategoryGroups {get; set;}
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        [DbFunction("CodeFirstDatabaseSchema", "unaccent")]
        public string Unaccent(string value)
        {
            // no need to provide an implementation
            throw new NotSupportedException();
        }
        void LoadStatesWithCities(ref ModelBuilder builder)
        {
            List<State> states = new List<State>();
            List<City> cities = new List<City>();

            var myJsonString = File.ReadAllText(Path.Combine("Data","states.json"));
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
        void LoadCategoryGroupsWithCategories(ref ModelBuilder builder)
        {
            builder.Entity<CategoryGroup>().HasData(new CategoryGroup { Id = 1, Name = "Thuê (Share) & Cho Thuê" });
            builder.Entity<CategoryGroup>().HasData(new CategoryGroup { Id = 2, Name = "Mua Bán" });
            builder.Entity<CategoryGroup>().HasData(new CategoryGroup { Id = 3, Name = "Việc Làm (Jobs)" });
            builder.Entity<CategoryGroup>().HasData(new CategoryGroup { Id = 4, Name = "Real Estate, Sang Nhượng Tiệm & Financing" });
            builder.Entity<CategoryGroup>().HasData(new CategoryGroup { Id = 5, Name = "Dịch Vụ (Services)" });
            builder.Entity<CategoryGroup>().HasData(new CategoryGroup { Id = 6, Name = "Linh Tinh (Misc)" });

            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 1, Id = 1, Name = "Thuê (Share) Phòng", ExternalUrl = "https://mraovat.nguoi-viet.com/classified/phong-cho-thue-rooms-to-share-browse-88.aspx" });
            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 1, Id = 2, Name = "Cần & Cho Thuê Nhà, Chung Cư, Apt. Condo", ExternalUrl = "https://mraovat.nguoi-viet.com/classified/nha-cho-thue-house-for-rent-browse-86.aspx, https://mraovat.nguoi-viet.com/classified/apartment-condo-cho-thue-for-rent-browse-87.aspx" });
            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 1, Id = 3, Name = "Cần & Cho Thuê Văn Phòng, Cửa Tiệm" });
            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 1, Id = 4, Name = "Cần & Cho Thuê Các Thứ Khác" });

            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 2, Id = 5, Name = "Nail & Beauty Spa Supply" });
            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 2, Id = 6, Name = "Mua Bán Xe / Car", ExternalUrl= "https://mraovat.nguoi-viet.com/classified/xe-ban-auto-for-sale-browse-91.aspx" });
            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 2, Id = 7, Name = "Mua Bán Sĩ, Xuất Nhập Khẩu" });
            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 2, Id = 8, Name = "Mua Bán Các Loại", ExternalUrl= "https://mraovat.nguoi-viet.com/classified/ban-cac-loai-items-for-sale-browse-118.aspx" });


            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 3, Id = 9, Name = "Cần Thợ Nails & Tóc", ExternalUrl= "https://mraovat.nguoi-viet.com/classified/viec-hair-nail-job-browse-96.aspx" });
            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 3, Id = 10, Name = "Cần Chăm Sóc Trẻ Em, Người Già" });
            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 3, Id = 11, Name = "Nhận Giữ Trẻ Em Và Chăm Sóc Người Già", ExternalUrl= "https://mraovat.nguoi-viet.com/classified/giu-tre-child-care-babysitter-browse-117.aspx" });
            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 3, Id = 12, Name = "Giúp Việc Nhà / Domestic Assistance", ExternalUrl= "https://mraovat.nguoi-viet.com/classified/viec-nha-domestic-assistance-browse-94.aspx" });
            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 3, Id = 13, Name = "Việc Hãng Xưởng / Manufacturing Job", ExternalUrl= "https://mraovat.nguoi-viet.com/classified/viec-hang-xuong-manufacturing-jobs-browse-95.aspx" });
            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 3, Id = 14, Name = "Việc Văn Phòng / Office - Clerical Jobs", ExternalUrl= "https://mraovat.nguoi-viet.com/classified/viec-van-phong-office-clerical-jobs-browse-97.aspx" });
            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 3, Id = 15, Name = "Việc Chợ / Nhà Hàng - Restaurant/Supermarket", ExternalUrl= "https://mraovat.nguoi-viet.com/classified/viec-cho-nha-hang-restaurants-market-jobs-browse-98.aspx" });
            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 3, Id = 16, Name = "Việc Thợ may / Sewing Jobs", ExternalUrl= "https://mraovat.nguoi-viet.com/classified/viec-tho-may-sewing-jobs-browse-99.aspx" });
            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 3, Id = 17, Name = "Các việc khác (General Jobs)", ExternalUrl= "https://mraovat.nguoi-viet.com/classified/viec-lam-employment-browse-93.aspx" });
            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 3, Id = 18, Name = "Người Tìm Việc / Looking for Job" });

            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 4, Id = 19, Name = "Mua Bán Tiệm Nail & Tóc / Salon Office Transfer" });
            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 4, Id = 20, Name = "Mua Bán Cơ Sở Thương Mại / Business Office", ExternalUrl = "https://mraovat.nguoi-viet.com/classified/sang-nhuong-co-so-business-opportunities-browse-92.aspx" });
            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 4, Id = 21, Name = "Mua Bán Nhà / Real Estate", ExternalUrl= "https://mraovat.nguoi-viet.com/classified/nha-ban-house-for-sale-browse-90.aspx" });
            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 4, Id = 22, Name = "Vay Mượn & Đầu Tư / Loan - Financing", ExternalUrl= "https://mraovat.nguoi-viet.com/classified/vay-muon-dau-tu-financing-investments-browse-111.aspx" });

            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 5, Id = 23, Name = "Kế Toán, Luật Pháp, Tư Vấn / Accounting - Laws Service" });
            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 5, Id = 24, Name = "Xây Cất / Construction", ExternalUrl= "https://mraovat.nguoi-viet.com/classified/sua-nha-tiem-construction-browse-105.aspx" });
            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 5, Id = 25, Name = "Sửa Điện, Ống Nước / Electric, Plumbing", ExternalUrl= "https://mraovat.nguoi-viet.com/classified/sua-ong-nuoc-plumbing-browse-107.aspx" });
            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 5, Id = 26, Name = "Sửa Máy Móc Gia Dụng / Appliances Repair", ExternalUrl= "https://mraovat.nguoi-viet.com/classified/sua-may-moc-appliances-repair-browse-103.aspx" });
            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 5, Id = 27, Name = "Sửa Xe / Car (Auto) Repair", ExternalUrl= "https://mraovat.nguoi-viet.com/classified/sua-xe-auto-repair-browse-104.aspx" });
            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 5, Id = 28, Name = "Làm Vườn / Landscaping", ExternalUrl= "https://mraovat.nguoi-viet.com/classified/lam-vuon-landscaping-browse-108.aspx" });
            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 5, Id = 29, Name = "Máy Tính, Phần Mềm, Web / IT" });

            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 5, Id = 30, Name = "Dạy Kèm / Tutoring", ExternalUrl= "https://mraovat.nguoi-viet.com/classified/day-kem-huan-luyen-tutoring-training-browse-110.aspx" });
            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 5, Id = 31, Name = "Đưa Đón / Pickup" });
            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 5, Id = 32, Name = "Du Lịch, Du Học / Travel, Study", ExternalUrl= "https://mraovat.nguoi-viet.com/classified/du-lich-travel-browse-101.aspx" });
            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 5, Id = 33, Name = "Đấm Bóp & Thư Giãn / Massage", ExternalUrl= "https://mraovat.nguoi-viet.com/classified/dam-bop-thu-gian-massage-relax-browse-123.aspx" });
            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 5, Id = 34, Name = "Cơm Tháng / Meal Delivery", ExternalUrl= "https://mraovat.nguoi-viet.com/classified/com-thang-meal-delivery-browse-116.aspx" });
            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 5, Id = 35, Name = "Dọn Nhà, Chuyển Văn Phòng / Moving", ExternalUrl= "https://mraovat.nguoi-viet.com/classified/don-nha-moving-browse-106.aspx" });
            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 5, Id = 36, Name = "Giặt Thảm, Vệ Sinh / Cleaning", ExternalUrl= "https://mraovat.nguoi-viet.com/classified/giat-tham-carpet-cleaning-browse-109.aspx" });
            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 5, Id = 37, Name = "Bảng Hiệu / Banner", ExternalUrl= "https://mraovat.nguoi-viet.com/classified/bang-hieu-sign-banners-browse-102.aspx" });
            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 5, Id = 38, Name = "Nhắn Tin, Thông Báo / Announcement", ExternalUrl= "https://mraovat.nguoi-viet.com/classified/nhan-tin-thong-bao-annoucements-browse-119.aspx" });
            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 5, Id = 39, Name = "Các Dịch Vụ Khác / Other Services", 
                ExternalUrl= "https://mraovat.nguoi-viet.com/classified/dich-vu-services-browse-100.aspx, https://mraovat.nguoi-viet.com/classified/suc-khoe-tham-my-health-beauty-browse-112.aspx, https://mraovat.nguoi-viet.com/classified/tu-vi-chiem-tinh-psychics-astrologers-browse-113.aspx, https://mraovat.nguoi-viet.com/classified/linh-tinh-miscellaneous-browse-114.aspx, https://mraovat.nguoi-viet.com/classified/rao-vat-co-danh-thiep-business-cards-size-ads-browse-122.aspx"
            });


            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 6, Id = 40, Name = "Lời Nguyện Tôn Giáo / Religious Prayers", ExternalUrl= "https://mraovat.nguoi-viet.com/classified/loi-nguyen-ton-giao-religious-prayers-browse-115.aspx" });
            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 6, Id = 41, Name = "Tìm Người Thân / Friends and Family Search", ExternalUrl= "https://mraovat.nguoi-viet.com/classified/tim-nguoi-than-search-for-family-friends-browse-120.aspx" });
            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 6, Id = 42, Name = "Tìm Bạn Bốn Phương / Connecting People", ExternalUrl= "https://mraovat.nguoi-viet.com/classified/tim-ban-bon-phuong-connecting-with-people-browse-121.aspx" });
            builder.Entity<Category>().HasData(new Category { CategoryGroupId = 6, Id = 43, Name = "Đồ Miễn Phí / Free Stuffs", ExternalUrl= "https://mraovat.nguoi-viet.com/classified/Do-dung-mien-phi-free-browse-124.aspx" });

            }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            builder.Entity<Category>(entity => {
                entity.HasOne(c => c.CategoryGroup)
                       .WithMany(g => g.Categories)
                       .HasForeignKey("CategoryGroupId");

            });

            LoadCategoryGroupsWithCategories(ref builder);

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
