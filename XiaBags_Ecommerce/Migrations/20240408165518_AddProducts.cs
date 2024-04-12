using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XiaBags_Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class AddProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Products(CategoryId, Name, Description, Price, ImageURL, ImageThumbnailURL, StockInHand) VALUES(3, 'Senegal', 'With plenty of space for your everyday essentials, our tote bag is made with fun prints and a double handle. This piece is fully lined, has a zip and a small pocket on the inside.', 24.90, '~/images/totebag_senegal.jpg', ' ', 1)");
            migrationBuilder.Sql("INSERT INTO Products(CategoryId, Name, Description, Price, ImageURL, ImageThumbnailURL, StockInHand) VALUES(4, 'Stamps', 'Made with fun prints, our slim design clutch is classic, fantastic and very versatile. This piece is fully lined, zipped at the top and has a small pocket on the inside.', 12.50, '~/images/clutct_stamps.jpg', ' ', 1)");
            migrationBuilder.Sql("INSERT INTO Products(CategoryId, Name, Description, Price, ImageURL, ImageThumbnailURL, StockInHand) VALUES(5, 'Fashion Print', 'Made with fun prints, this keychain with a coin pouch is versatile and practical. This piece is fully lined, zipped at the top and has a small pocket on the inside.', 5.50, '~/images/keychain.jpg', ' ', 1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}
