using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace blog.Migrations
{
    /// <inheritdoc />
    public partial class FirstOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "post",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comments_post_PostId",
                        column: x => x.PostId,
                        principalTable: "post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "post",
                columns: new[] { "Id", "Content", "Likes", "Title" },
                values: new object[,]
                {
                    { 1, "Topazio calça as ruas do rio vermelho pelo amor de deussss", 300, "Prefeitura de Florianópolis" },
                    { 2, "Que melancolia é essa, vai pra terapia moça", 14, "Lana del rey" },
                    { 3, "Veganos obriagda por deixarem mais para nós HAHAYSAGDYUBGEDWUY", 56, "Eu Amo Carne" }
                });

            migrationBuilder.InsertData(
                table: "comments",
                columns: new[] { "Id", "Content", "Name", "PostId" },
                values: new object[,]
                {
                    { 1, "Já tamo lá!", "Topázio Pref.", 1 },
                    { 2, "Simm, por isso sou swiftie", "I Love TS", 2 },
                    { 3, "O preço que se paga por saber ler...", "TheVeggieOne.", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_comments_PostId",
                table: "comments",
                column: "PostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "post");
        }
    }
}
