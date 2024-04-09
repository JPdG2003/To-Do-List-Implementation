using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace To_Do_List_Implementation.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigrationcorrections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_Users_Userid_user",
                table: "TodoItems");

            migrationBuilder.DropIndex(
                name: "IX_TodoItems_Userid_user",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "Userid_user",
                table: "TodoItems");

            migrationBuilder.RenameColumn(
                name: "id_user",
                table: "TodoItems",
                newName: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_UserId",
                table: "TodoItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_Users_UserId",
                table: "TodoItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_Users_UserId",
                table: "TodoItems");

            migrationBuilder.DropIndex(
                name: "IX_TodoItems_UserId",
                table: "TodoItems");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TodoItems",
                newName: "id_user");

            migrationBuilder.AddColumn<int>(
                name: "Userid_user",
                table: "TodoItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_Userid_user",
                table: "TodoItems",
                column: "Userid_user");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_Users_Userid_user",
                table: "TodoItems",
                column: "Userid_user",
                principalTable: "Users",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
