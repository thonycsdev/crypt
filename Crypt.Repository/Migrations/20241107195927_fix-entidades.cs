using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Crypt.Repository.Migrations
{
    /// <inheritdoc />
    public partial class fixentidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_CreditCards_CreditCardNumberHash",
                table: "Wallets");

            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_Documents_DocumentUserDocumentHash",
                table: "Wallets");

            migrationBuilder.DropIndex(
                name: "IX_Wallets_CreditCardNumberHash",
                table: "Wallets");

            migrationBuilder.DropIndex(
                name: "IX_Wallets_DocumentUserDocumentHash",
                table: "Wallets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Documents",
                table: "Documents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CreditCards",
                table: "CreditCards");

            migrationBuilder.DropColumn(
                name: "CreditCardNumberHash",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "DocumentUserDocumentHash",
                table: "Wallets");

            migrationBuilder.AddColumn<long>(
                name: "CreditCardId",
                table: "Wallets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "DocumentId",
                table: "Wallets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "Documents",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "CreditCards",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Documents",
                table: "Documents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreditCards",
                table: "CreditCards",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_CreditCardId",
                table: "Wallets",
                column: "CreditCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_DocumentId",
                table: "Wallets",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_CreditCards_CreditCardId",
                table: "Wallets",
                column: "CreditCardId",
                principalTable: "CreditCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_Documents_DocumentId",
                table: "Wallets",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_CreditCards_CreditCardId",
                table: "Wallets");

            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_Documents_DocumentId",
                table: "Wallets");

            migrationBuilder.DropIndex(
                name: "IX_Wallets_CreditCardId",
                table: "Wallets");

            migrationBuilder.DropIndex(
                name: "IX_Wallets_DocumentId",
                table: "Wallets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Documents",
                table: "Documents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CreditCards",
                table: "CreditCards");

            migrationBuilder.DropColumn(
                name: "CreditCardId",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CreditCards");

            migrationBuilder.AddColumn<string>(
                name: "CreditCardNumberHash",
                table: "Wallets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocumentUserDocumentHash",
                table: "Wallets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Documents",
                table: "Documents",
                column: "UserDocumentHash");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreditCards",
                table: "CreditCards",
                column: "CreditCardNumberHash");

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
    }
}
