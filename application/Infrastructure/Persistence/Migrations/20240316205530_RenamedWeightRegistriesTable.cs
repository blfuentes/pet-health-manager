using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace application.Migrations
{
    /// <inheritdoc />
    public partial class RenamedWeightRegistriesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeightRegistry_Pets_PetId",
                table: "WeightRegistry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeightRegistry",
                table: "WeightRegistry");

            migrationBuilder.RenameTable(
                name: "WeightRegistry",
                newName: "WeightRegistries");

            migrationBuilder.RenameIndex(
                name: "IX_WeightRegistry_PetId",
                table: "WeightRegistries",
                newName: "IX_WeightRegistries_PetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeightRegistries",
                table: "WeightRegistries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WeightRegistries_Pets_PetId",
                table: "WeightRegistries",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeightRegistries_Pets_PetId",
                table: "WeightRegistries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeightRegistries",
                table: "WeightRegistries");

            migrationBuilder.RenameTable(
                name: "WeightRegistries",
                newName: "WeightRegistry");

            migrationBuilder.RenameIndex(
                name: "IX_WeightRegistries_PetId",
                table: "WeightRegistry",
                newName: "IX_WeightRegistry_PetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeightRegistry",
                table: "WeightRegistry",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WeightRegistry_Pets_PetId",
                table: "WeightRegistry",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
