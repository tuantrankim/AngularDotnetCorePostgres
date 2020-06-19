using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularDotnetCore.Migrations
{
    public partial class category_external_url : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "ExternalUrl",
                table: "Categories",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExternalUrl",
                value: "https://mraovat.nguoi-viet.com/classified/phong-cho-thue-rooms-to-share-browse-88.aspx");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExternalUrl",
                value: "https://mraovat.nguoi-viet.com/classified/nha-cho-thue-house-for-rent-browse-86.aspx, https://mraovat.nguoi-viet.com/classified/apartment-condo-cho-thue-for-rent-browse-87.aspx");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "ExternalUrl",
                value: "https://mraovat.nguoi-viet.com/classified/xe-ban-auto-for-sale-browse-91.aspx");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "ExternalUrl",
                value: "https://mraovat.nguoi-viet.com/classified/ban-cac-loai-items-for-sale-browse-118.aspx");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "ExternalUrl",
                value: "https://mraovat.nguoi-viet.com/classified/viec-hair-nail-job-browse-96.aspx");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "ExternalUrl",
                value: "https://mraovat.nguoi-viet.com/classified/giu-tre-child-care-babysitter-browse-117.aspx");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "ExternalUrl",
                value: "https://mraovat.nguoi-viet.com/classified/viec-nha-domestic-assistance-browse-94.aspx");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                column: "ExternalUrl",
                value: "https://mraovat.nguoi-viet.com/classified/viec-hang-xuong-manufacturing-jobs-browse-95.aspx");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                column: "ExternalUrl",
                value: "https://mraovat.nguoi-viet.com/classified/viec-van-phong-office-clerical-jobs-browse-97.aspx");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                column: "ExternalUrl",
                value: "https://mraovat.nguoi-viet.com/classified/viec-cho-nha-hang-restaurants-market-jobs-browse-98.aspx");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16,
                column: "ExternalUrl",
                value: "https://mraovat.nguoi-viet.com/classified/viec-tho-may-sewing-jobs-browse-99.aspx");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17,
                column: "ExternalUrl",
                value: "https://mraovat.nguoi-viet.com/classified/viec-lam-employment-browse-93.aspx");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20,
                column: "ExternalUrl",
                value: "https://mraovat.nguoi-viet.com/classified/sang-nhuong-co-so-business-opportunities-browse-92.aspx");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 21,
                column: "ExternalUrl",
                value: "https://mraovat.nguoi-viet.com/classified/nha-ban-house-for-sale-browse-90.aspx");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 22,
                column: "ExternalUrl",
                value: "https://mraovat.nguoi-viet.com/classified/vay-muon-dau-tu-financing-investments-browse-111.aspx");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 24,
                column: "ExternalUrl",
                value: "https://mraovat.nguoi-viet.com/classified/sua-nha-tiem-construction-browse-105.aspx");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 25,
                column: "ExternalUrl",
                value: "https://mraovat.nguoi-viet.com/classified/sua-ong-nuoc-plumbing-browse-107.aspx");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 26,
                column: "ExternalUrl",
                value: "https://mraovat.nguoi-viet.com/classified/sua-may-moc-appliances-repair-browse-103.aspx");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 27,
                column: "ExternalUrl",
                value: "https://mraovat.nguoi-viet.com/classified/sua-xe-auto-repair-browse-104.aspx");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 28,
                column: "ExternalUrl",
                value: "https://mraovat.nguoi-viet.com/classified/lam-vuon-landscaping-browse-108.aspx");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 30,
                column: "ExternalUrl",
                value: "https://mraovat.nguoi-viet.com/classified/day-kem-huan-luyen-tutoring-training-browse-110.aspx");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 32,
                column: "ExternalUrl",
                value: "https://mraovat.nguoi-viet.com/classified/du-lich-travel-browse-101.aspx");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 33,
                column: "ExternalUrl",
                value: "https://mraovat.nguoi-viet.com/classified/dam-bop-thu-gian-massage-relax-browse-123.aspx");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 34,
                column: "ExternalUrl",
                value: "https://mraovat.nguoi-viet.com/classified/com-thang-meal-delivery-browse-116.aspx");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 35,
                column: "ExternalUrl",
                value: "https://mraovat.nguoi-viet.com/classified/don-nha-moving-browse-106.aspx");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 36,
                column: "ExternalUrl",
                value: "https://mraovat.nguoi-viet.com/classified/giat-tham-carpet-cleaning-browse-109.aspx");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 37,
                column: "ExternalUrl",
                value: "https://mraovat.nguoi-viet.com/classified/bang-hieu-sign-banners-browse-102.aspx");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 38,
                column: "ExternalUrl",
                value: "https://mraovat.nguoi-viet.com/classified/nhan-tin-thong-bao-annoucements-browse-119.aspx");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 39,
                column: "ExternalUrl",
                value: "https://mraovat.nguoi-viet.com/classified/dich-vu-services-browse-100.aspx, https://mraovat.nguoi-viet.com/classified/suc-khoe-tham-my-health-beauty-browse-112.aspx, https://mraovat.nguoi-viet.com/classified/tu-vi-chiem-tinh-psychics-astrologers-browse-113.aspx, https://mraovat.nguoi-viet.com/classified/linh-tinh-miscellaneous-browse-114.aspx, https://mraovat.nguoi-viet.com/classified/rao-vat-co-danh-thiep-business-cards-size-ads-browse-122.aspx");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 40,
                column: "ExternalUrl",
                value: "https://mraovat.nguoi-viet.com/classified/loi-nguyen-ton-giao-religious-prayers-browse-115.aspx");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 41,
                column: "ExternalUrl",
                value: "https://mraovat.nguoi-viet.com/classified/tim-nguoi-than-search-for-family-friends-browse-120.aspx");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 42,
                column: "ExternalUrl",
                value: "https://mraovat.nguoi-viet.com/classified/tim-ban-bon-phuong-connecting-with-people-browse-121.aspx");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 43,
                column: "ExternalUrl",
                value: "https://mraovat.nguoi-viet.com/classified/Do-dung-mien-phi-free-browse-124.aspx");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CityId",
                table: "Posts",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Categories_CategoryId",
                table: "Posts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Cities_CityId",
                table: "Posts",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categories_CategoryId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Cities_CityId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_CityId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ExternalUrl",
                table: "Categories");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Posts",
                type: "text",
                nullable: true);
        }
    }
}
