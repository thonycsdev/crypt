using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crypt.Repository.Migrations
{
    /// <inheritdoc />
    public partial class creditcardanddocument : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserDocument",
                table: "Wallets",
                newName: "DocumentUserDocumentHash");

            migrationBuilder.RenameColumn(
                name: "CreditCardNumber",
                table: "Wallets",
                newName: "CreditCardNumberHash");

            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    CreditCardNumberHash = table.Column<string>(type: "text", nullable: false),
                    CreditCardNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.CreditCardNumberHash);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    UserDocumentHash = table.Column<string>(type: "text", nullable: false),
                    UserDocument = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.UserDocumentHash);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_CreditCardNumberHash",
                table: "Wallets",
                column: "CreditCardNumberHash");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_DocumentUserDocumentHash",
                table: "Wallets",
                column: "DocumentUserDocumentHash");

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_CreditCards_CreditCardNumberHash",
                table: "Wallets",
                column: "CreditCardNumberHash",
                principalTable: "CreditCards",
                principalColumn: "CreditCardNumberHash",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_Documents_DocumentUserDocumentHash",
                table: "Wallets",
                column: "DocumentUserDocumentHash",
                principalTable: "Documents",
                principalColumn: "UserDocumentHash",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_CreditCards_CreditCardNumberHash",
                table: "Wallets");

            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_Documents_DocumentUserDocumentHash",
                table: "Wallets");

            migrationBuilder.DropTable(
                name: "CreditCards");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Wallets_CreditCardNumberHash",
                table: "Wallets");

            migrationBuilder.DropIndex(
                name: "IX_Wallets_DocumentUserDocumentHash",
                table: "Wallets");

            migrationBuilder.RenameColumn(
                name: "DocumentUserDocumentHash",
                table: "Wallets",
                newName: "UserDocument");

            migrationBuilder.RenameColumn(
                name: "CreditCardNumberHash",
                table: "Wallets",
                newName: "CreditCardNumber");
        }
    }
}
