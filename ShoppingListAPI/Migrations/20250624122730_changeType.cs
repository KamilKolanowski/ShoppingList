using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingListAPI.Migrations
{
    /// <inheritdoc />
    public partial class changeType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingListItems_ShoppingList_ShoppingListId",
                schema: "TCSA",
                table: "ShoppingListItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingList",
                schema: "TCSA",
                table: "ShoppingList");

            migrationBuilder.RenameTable(
                name: "ShoppingList",
                schema: "TCSA",
                newName: "ShoppingLists",
                newSchema: "TCSA");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingLists",
                schema: "TCSA",
                table: "ShoppingLists",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingListItems_ShoppingLists_ShoppingListId",
                schema: "TCSA",
                table: "ShoppingListItems",
                column: "ShoppingListId",
                principalSchema: "TCSA",
                principalTable: "ShoppingLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingListItems_ShoppingLists_ShoppingListId",
                schema: "TCSA",
                table: "ShoppingListItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingLists",
                schema: "TCSA",
                table: "ShoppingLists");

            migrationBuilder.RenameTable(
                name: "ShoppingLists",
                schema: "TCSA",
                newName: "ShoppingList",
                newSchema: "TCSA");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingList",
                schema: "TCSA",
                table: "ShoppingList",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingListItems_ShoppingList_ShoppingListId",
                schema: "TCSA",
                table: "ShoppingListItems",
                column: "ShoppingListId",
                principalSchema: "TCSA",
                principalTable: "ShoppingList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
