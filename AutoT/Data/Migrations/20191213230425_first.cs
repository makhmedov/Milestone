using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoT.Data.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    very_low = table.Column<int>(nullable: false),
                    low = table.Column<int>(nullable: false),
                    medium = table.Column<int>(nullable: false),
                    high = table.Column<int>(nullable: false),
                    very_high = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceBook",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    UserId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceBook", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceBook_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRolesMap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    UserId1 = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    RoleId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRolesMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRolesMap_AspNetRoles_RoleId1",
                        column: x => x.RoleId1,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRolesMap_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceMaintance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    RatingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceMaintance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceMaintance_Rating_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Rating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceBookContent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MechanicsUserId = table.Column<int>(nullable: false),
                    Content = table.Column<int>(nullable: false),
                    duration = table.Column<int>(nullable: false),
                    RaServiceBookIdtingId = table.Column<int>(nullable: false),
                    ServiceBookId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceBookContent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceBookContent_ServiceBook_ServiceBookId",
                        column: x => x.ServiceBookId,
                        principalTable: "ServiceBook",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceBook_UserId1",
                table: "ServiceBook",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceBookContent_ServiceBookId",
                table: "ServiceBookContent",
                column: "ServiceBookId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceMaintance_RatingId",
                table: "ServiceMaintance",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRolesMap_RoleId1",
                table: "UserRolesMap",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserRolesMap_UserId1",
                table: "UserRolesMap",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceBookContent");

            migrationBuilder.DropTable(
                name: "ServiceMaintance");

            migrationBuilder.DropTable(
                name: "UserRolesMap");

            migrationBuilder.DropTable(
                name: "ServiceBook");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoles");
        }
    }
}
