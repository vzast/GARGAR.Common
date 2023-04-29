using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class ispersist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48fc0fde-7c78-4754-852f-e5bb2a54bc91");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00e41164-8655-45b0-be36-dce0ee09fa1b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d8c7f5e5-28c0-4ef1-a759-3bbc45e15cc1", "c1ad8a34-585d-4511-9313-145b5a602750", "Admin", "Administrator" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "da34d5bb-d0fa-4fbd-9f39-743c7fc2e3fc", 0, "23d905f6-c347-448f-85b3-583a1122d685", "TechnoGargar@outlook.com", false, "Sigma", "Dev", false, null, "technogargar@outlook.com", "gargar", "AQAAAAEAACcQAAAAEHGSjbhzEizqvqs0TiTlbWg3KaRK5L19Tty+ypugfjWlk176hdOp++Hsa76dVKw4GA==", null, false, "60e071eb-3715-4fad-9792-a8cf2add912e", false, "GarGar" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8c7f5e5-28c0-4ef1-a759-3bbc45e15cc1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "da34d5bb-d0fa-4fbd-9f39-743c7fc2e3fc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "48fc0fde-7c78-4754-852f-e5bb2a54bc91", "3f8c72a5-a1eb-42f4-bb21-ba2ccec21659", "Admin", "Administrator" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "00e41164-8655-45b0-be36-dce0ee09fa1b", 0, "0fb0ef60-5e12-4e6b-aa47-c3464d17af63", "TechnoGargar@outlook.com", false, "Sigma", "Dev", false, null, "technogargar@outlook.com", "gargar", "AQAAAAEAACcQAAAAEAKHXsHHEoCf15M96kb3YW64ppn0fUF1ztycHWY783dybL4Bn1fpNuz87XskcKHXJw==", null, false, "bab09c42-6af8-425c-91c3-511746303cc1", false, "GarGar" });
        }
    }
}
