using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blog.Migrations
{
    /// <inheritdoc />
    public partial class alterAppDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "post");

            migrationBuilder.UpdateData(
                table: "post",
                keyColumn: "Id",
                keyValue: 3,
                column: "Content",
                value: "Veganos obriagda por deixarem mais para nósHAHAHAHHAHAHAH");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "post",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "post",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Prefeitura de Florianópolis");

            migrationBuilder.UpdateData(
                table: "post",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Lana del rey");

            migrationBuilder.UpdateData(
                table: "post",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Content", "Title" },
                values: new object[] { "Veganos obriagda por deixarem mais para nós HAHAYSAGDYUBGEDWUY", "Eu Amo Carne" });
        }
    }
}
