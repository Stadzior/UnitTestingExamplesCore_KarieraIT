using Microsoft.EntityFrameworkCore.Migrations;

namespace UnitTestingExamplesCore_KarieraIT.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Foos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    FooId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bars_Foos_FooId",
                        column: x => x.FooId,
                        principalTable: "Foos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Foos",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Foo1" },
                    { 2, "Foo2" },
                    { 3, "Foo3" },
                    { 4, "Foo4" }
                });

            migrationBuilder.InsertData(
                table: "Bars",
                columns: new[] { "Id", "FooId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Bar1" },
                    { 2, 1, "Bar2" },
                    { 3, 1, "Bar3" },
                    { 4, 1, "Bar4" },
                    { 5, 2, "Bar5" },
                    { 6, 2, "Bar6" },
                    { 7, 2, "Bar7" },
                    { 8, 3, "Bar8" },
                    { 9, 3, "Bar9" },
                    { 10, 4, "Bar10" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bars_FooId",
                table: "Bars",
                column: "FooId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bars");

            migrationBuilder.DropTable(
                name: "Foos");
        }
    }
}
