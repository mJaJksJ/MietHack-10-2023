using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MietHack_10_2023.Database.Migrations
{
    /// <inheritdoc />
    public partial class FixUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Students_student_id",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "linq_to_gruop",
                table: "Events",
                newName: "linq_to_group");

            migrationBuilder.AlterColumn<int>(
                name: "student_id",
                table: "Users",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<byte[]>(
                name: "logo",
                table: "StudentUnions",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Students_student_id",
                table: "Users",
                column: "student_id",
                principalTable: "Students",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Students_student_id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "logo",
                table: "StudentUnions");

            migrationBuilder.RenameColumn(
                name: "linq_to_group",
                table: "Events",
                newName: "linq_to_gruop");

            migrationBuilder.AlterColumn<int>(
                name: "student_id",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Students_student_id",
                table: "Users",
                column: "student_id",
                principalTable: "Students",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
