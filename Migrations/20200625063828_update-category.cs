using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularDotnetCore.Migrations
{
    public partial class updatecategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Phòng Cho Thuê (Rooms to Share)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExternalUrl", "Name" },
                values: new object[] { "https://mraovat.nguoi-viet.com/classified/apartment-condo-cho-thue-for-rent-browse-87.aspx", "Apt. Condo Cho Thuê (Apt. Condo for Rent)" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Icon", "Name" },
                values: new object[] { "store_mall_directory", "Văn Phòng, Cửa Tiệm Cho Thuê (Office for Lease)" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ExternalUrl", "Icon", "Name" },
                values: new object[] { "https://mraovat.nguoi-viet.com/classified/nha-cho-thue-house-for-rent-browse-86.aspx", "house", "Nhà Cho Thuê (House for Rent)" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Mua Bán Xe (Cars for Sale)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Mua Bán Sỉ, Xuất Nhập Khẩu (Wholesale, Import, Export)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Mua Bán Các Loại (Items for Sale)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Cần Thợ Hair, Nails (Hair, Nail Jobs)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Icon", "Name" },
                values: new object[] { "accessible", "Chăm Sóc Người Già, Tàn Tật" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Giữ Trẻ (Child Care)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Giúp Việc Nhà (Domestic Assistance)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Icon", "Name" },
                values: new object[] { "apartment", "Việc Hãng Xưởng (Manufacturing Job)" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "Việc Văn Phòng (Office - Clerical Jobs)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                column: "Name",
                value: "Việc Chợ, Nhà Hàng (Restaurant, Supermarket)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16,
                column: "Name",
                value: "Việc Thợ may (Sewing Jobs)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Icon", "Name" },
                values: new object[] { "people", "Việc Làm (Employment)" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ExternalUrl", "Icon", "Name" },
                values: new object[] { "https://mraovat.nguoi-viet.com/classified/suc-khoe-tham-my-health-beauty-browse-112.aspx", "self_improvement", "Sức Khỏe, Thẩm Mỹ (Health & Beauty)" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Icon", "Name" },
                values: new object[] { "storefront", "Mua Bán Tiệm Nail & Tóc (Salon Office Transfer)" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20,
                column: "Name",
                value: "Sang Nhượng Cơ Sở (Business Opportunities)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 21,
                column: "Name",
                value: "    ");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 22,
                column: "Name",
                value: "Vay Mượn & Đầu Tư (Loan, Financing)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 23,
                column: "Name",
                value: "Kế Toán, Luật Pháp, Tư Vấn (Accounting, Laws Service)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 24,
                column: "Name",
                value: "Xây Cất (Construction)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 25,
                column: "Name",
                value: "Sửa Điện, Nước (Electric, Plumbing)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 26,
                column: "Name",
                value: "Sửa Máy Móc Gia Dụng (Appliances Repair)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 27,
                column: "Name",
                value: "Sửa Xe (Car, Auto Repair)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 28,
                column: "Name",
                value: "Làm Vườn (Landscaping)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 29,
                column: "Name",
                value: "Máy Tính, Phần Mềm (Computer, Software, IT)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 30,
                column: "Name",
                value: "Dạy Kèm (Tutoring)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 31,
                column: "Name",
                value: "Đưa Đón (Pickup)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 32,
                column: "Name",
                value: "Du Lịch, Du Học (Travel, Study)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 33,
                column: "Name",
                value: "Đấm Bóp & Thư Giãn (Massage)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 34,
                column: "Name",
                value: "Cơm Tháng (Meal Delivery)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 35,
                column: "Name",
                value: "Dọn Nhà, Chuyển Văn Phòng (Moving)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 36,
                column: "Name",
                value: "Giặt Thảm, Vệ Sinh (Cleaning)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 37,
                column: "Name",
                value: "Bảng Hiệu (Banner)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 38,
                column: "Name",
                value: "Nhắn Tin, Thông Báo (Announcement)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "ExternalUrl", "Name" },
                values: new object[] { "https://mraovat.nguoi-viet.com/classified/dich-vu-services-browse-100.aspx, https://mraovat.nguoi-viet.com/classified/tu-vi-chiem-tinh-psychics-astrologers-browse-113.aspx, https://mraovat.nguoi-viet.com/classified/linh-tinh-miscellaneous-browse-114.aspx, https://mraovat.nguoi-viet.com/classified/rao-vat-co-danh-thiep-business-cards-size-ads-browse-122.aspx", "Các Dịch Vụ Khác (Miscellaneous)" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 40,
                column: "Name",
                value: "Lời Nguyện Tôn Giáo (Religious Prayers)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 41,
                column: "Name",
                value: "Tìm Người Thân (Friends and Family Search)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 42,
                column: "Name",
                value: "Tìm Bạn Bốn Phương (Connecting People)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 43,
                column: "Name",
                value: "Đồ Miễn Phí (Free Stuffs)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Thuê (Share) Phòng");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExternalUrl", "Name" },
                values: new object[] { "https://mraovat.nguoi-viet.com/classified/nha-cho-thue-house-for-rent-browse-86.aspx, https://mraovat.nguoi-viet.com/classified/apartment-condo-cho-thue-for-rent-browse-87.aspx", "Cần & Cho Thuê Nhà, Chung Cư, Apt. Condo" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Icon", "Name" },
                values: new object[] { "storefront", "Cần & Cho Thuê Văn Phòng, Cửa Tiệm" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ExternalUrl", "Icon", "Name" },
                values: new object[] { null, "emoji_symbols", "Cần & Cho Thuê Các Thứ Khác" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Mua Bán Xe / Car");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Mua Bán Sỉ, Xuất Nhập Khẩu");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Mua Bán Các Loại");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Cần Thợ Nails & Tóc");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Icon", "Name" },
                values: new object[] { "baby_changing_station", "Cần Chăm Sóc Trẻ Em, Người Già" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Nhận Giữ Trẻ Em Và Chăm Sóc Người Già");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Giúp Việc Nhà / Domestic Assistance");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Icon", "Name" },
                values: new object[] { "storefront", "Việc Hãng Xưởng / Manufacturing Job" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "Việc Văn Phòng / Office - Clerical Jobs");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                column: "Name",
                value: "Việc Chợ / Nhà Hàng - Restaurant/Supermarket");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16,
                column: "Name",
                value: "Việc Thợ may / Sewing Jobs");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Icon", "Name" },
                values: new object[] { "engineering", "Các việc khác (General Jobs)" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ExternalUrl", "Icon", "Name" },
                values: new object[] { null, "people", "Người Tìm Việc / Looking for Job" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Icon", "Name" },
                values: new object[] { "store_mall_directory", "Mua Bán Tiệm Nail & Tóc / Salon Office Transfer" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20,
                column: "Name",
                value: "Mua Bán Cơ Sở Thương Mại / Business Office");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 21,
                column: "Name",
                value: "Mua Bán Nhà / Real Estate");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 22,
                column: "Name",
                value: "Vay Mượn & Đầu Tư / Loan - Financing");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 23,
                column: "Name",
                value: "Kế Toán, Luật Pháp, Tư Vấn / Accounting - Laws Service");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 24,
                column: "Name",
                value: "Xây Cất / Construction");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 25,
                column: "Name",
                value: "Sửa Điện, Ống Nước / Electric, Plumbing");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 26,
                column: "Name",
                value: "Sửa Máy Móc Gia Dụng / Appliances Repair");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 27,
                column: "Name",
                value: "Sửa Xe / Car (Auto) Repair");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 28,
                column: "Name",
                value: "Làm Vườn / Landscaping");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 29,
                column: "Name",
                value: "Máy Tính, Phần Mềm, Web / IT");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 30,
                column: "Name",
                value: "Dạy Kèm / Tutoring");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 31,
                column: "Name",
                value: "Đưa Đón / Pickup");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 32,
                column: "Name",
                value: "Du Lịch, Du Học / Travel, Study");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 33,
                column: "Name",
                value: "Đấm Bóp & Thư Giãn / Massage");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 34,
                column: "Name",
                value: "Cơm Tháng / Meal Delivery");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 35,
                column: "Name",
                value: "Dọn Nhà, Chuyển Văn Phòng / Moving");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 36,
                column: "Name",
                value: "Giặt Thảm, Vệ Sinh / Cleaning");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 37,
                column: "Name",
                value: "Bảng Hiệu / Banner");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 38,
                column: "Name",
                value: "Nhắn Tin, Thông Báo / Announcement");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "ExternalUrl", "Name" },
                values: new object[] { "https://mraovat.nguoi-viet.com/classified/dich-vu-services-browse-100.aspx, https://mraovat.nguoi-viet.com/classified/suc-khoe-tham-my-health-beauty-browse-112.aspx, https://mraovat.nguoi-viet.com/classified/tu-vi-chiem-tinh-psychics-astrologers-browse-113.aspx, https://mraovat.nguoi-viet.com/classified/linh-tinh-miscellaneous-browse-114.aspx, https://mraovat.nguoi-viet.com/classified/rao-vat-co-danh-thiep-business-cards-size-ads-browse-122.aspx", "Các Dịch Vụ Khác / Other Services" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 40,
                column: "Name",
                value: "Lời Nguyện Tôn Giáo / Religious Prayers");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 41,
                column: "Name",
                value: "Tìm Người Thân / Friends and Family Search");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 42,
                column: "Name",
                value: "Tìm Bạn Bốn Phương / Connecting People");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 43,
                column: "Name",
                value: "Đồ Miễn Phí / Free Stuffs");
        }
    }
}
