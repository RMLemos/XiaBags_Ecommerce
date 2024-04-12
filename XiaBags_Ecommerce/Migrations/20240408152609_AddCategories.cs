using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XiaBags_Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class AddCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories(CategoryName, CategoryDescription) " +
                "VALUES('Tote Bag', 'Everyday Tote Bag')");
            migrationBuilder.Sql("INSERT INTO Categories(CategoryName, CategoryDescription) " +
                "VALUES('Clutch Bag', 'Clutch Bag for every occasion')");
            migrationBuilder.Sql("INSERT INTO Categories(CategoryName, CategoryDescription) " +
                "VALUES('Keychain', 'Keychains with different shapes')");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categories");
        }
    }
}
