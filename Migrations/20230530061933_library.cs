using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final.Migrations
{
    /// <inheritdoc />
    public partial class library : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_CatgID",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Books_BookID",
                table: "Borrows");

            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Readers_ReaderID",
                table: "Borrows");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_CatgID",
                table: "Books",
                column: "CatgID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Books_BookID",
                table: "Borrows",
                column: "BookID",
                principalTable: "Books",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Readers_ReaderID",
                table: "Borrows",
                column: "ReaderID",
                principalTable: "Readers",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_CatgID",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Books_BookID",
                table: "Borrows");

            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Readers_ReaderID",
                table: "Borrows");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_CatgID",
                table: "Books",
                column: "CatgID",
                principalTable: "Categories",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Books_BookID",
                table: "Borrows",
                column: "BookID",
                principalTable: "Books",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Readers_ReaderID",
                table: "Borrows",
                column: "ReaderID",
                principalTable: "Readers",
                principalColumn: "ID");
        }
    }
}
