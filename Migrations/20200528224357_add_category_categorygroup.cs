using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AngularDotnetCore.Migrations
{
    public partial class add_category_categorygroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    CategoryGroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_CategoryGroups_CategoryGroupId",
                        column: x => x.CategoryGroupId,
                        principalTable: "CategoryGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CategoryGroups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Thuê (Share) & Cho Thuê" },
                    { 2, "Mua Bán" },
                    { 3, "Việc Làm (Jobs)" },
                    { 4, "Real Estate, Sang Nhượng Tiệm & Financing" },
                    { 5, "Dịch Vụ (Services)" },
                    { 6, "Linh Tinh (Misc)" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryGroupId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Thuê (Share) Phòng" },
                    { 24, 5, "Xây Cất / Construction" },
                    { 25, 5, "Sửa Điện, Ống Nước / Electric, Plumbing" },
                    { 26, 5, "Sửa Máy Móc Gia Dụng / Appliances Repair" },
                    { 27, 5, "Sửa Xe / Car (Auto) Repair" },
                    { 28, 5, "Làm Vườn / Landscaping" },
                    { 29, 5, "Máy Tính, Phần Mềm, Web / IT" },
                    { 30, 5, "Dạy Kèm / Tutoring" },
                    { 31, 5, "Đưa Đón / Pickup" },
                    { 23, 5, "Kế Toán, Luật Pháp, Tư Vấn / Accounting - Laws Service" },
                    { 32, 5, "Du Lịch, Du Học / Travel, Study" },
                    { 34, 5, "Cơm Tháng / Meal Delivery" },
                    { 35, 5, "Dọn Nhà, Chuyển Văn Phòng / Moving" },
                    { 36, 5, "Giặt Thảm, Vệ Sinh / Cleaning" },
                    { 37, 5, "Bảng Hiệu / Banner" },
                    { 38, 5, "Nhắn Tin, Thông Báo / Announcement" },
                    { 39, 5, "Các Dịch Vụ Khác / Other Services" },
                    { 40, 6, "Lời Nguyện Tôn Giáo / Religious Prayers" },
                    { 41, 6, "Tìm Người Thân / Friends and Family Search" },
                    { 33, 5, "Đấm Bóp & Thư Giãn / Massage" },
                    { 42, 6, "Tìm Bạn Bốn Phương / Connecting People" },
                    { 22, 4, "Vay Mượn & Đầu Tư / Loan - Financing" },
                    { 20, 4, "Mua Bán Cơ Sở Thương Mại / Business Office" },
                    { 2, 1, "Cần & Cho Thuê Nhà, Chung Cư, Apt. Condo" },
                    { 3, 1, "Cần & Cho Thuê Văn Phòng, Cửa Tiệm" },
                    { 4, 1, "Cần & Cho Thuê Các Thứ Khác" },
                    { 5, 2, "Nail & Beauty Spa Supply" },
                    { 6, 2, "Mua Bán Xe / Car" },
                    { 7, 2, "Mua Bán Sĩ, Xuất Nhập Khẩu" },
                    { 8, 2, "Mua Bán Các Loại" },
                    { 9, 3, "Cần Thợ Nails & Tóc" },
                    { 21, 4, "Mua Bán Nhà / Real Estate" },
                    { 10, 3, "Cần Chăm Sóc Trẻ Em, Người Già" },
                    { 12, 3, "Giúp Việc Nhà / Domestic Assistance" },
                    { 13, 3, "Việc Hãng Xưởng / Manufacturing Job" },
                    { 14, 3, "Việc Văn Phòng / Office - Clerical Jobs" },
                    { 15, 3, "Việc Chợ / Nhà Hàng - Restaurant/Supermarket" },
                    { 16, 3, "Việc Thợ may / Sewing Jobs" },
                    { 17, 3, "Các việc khác (General Jobs)" },
                    { 18, 3, "Người Tìm Việc / Looking for Job" },
                    { 19, 4, "Mua Bán Tiệm Nail & Tóc / Salon Office Transfer" },
                    { 11, 3, "Nhận Giữ Trẻ Em Và Chăm Sóc Người Già" },
                    { 43, 6, "Đồ Miễn Phí / Free Stuffs" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryGroupId",
                table: "Categories",
                column: "CategoryGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "CategoryGroups");
        }
    }
}
