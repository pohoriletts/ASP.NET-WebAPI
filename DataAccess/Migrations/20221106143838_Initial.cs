using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypeTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeTransactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sum = table.Column<int>(type: "int", nullable: false),
                    TypeTransactionID = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SenderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_TypeTransactions_TypeTransactionID",
                        column: x => x.TypeTransactionID,
                        principalTable: "TypeTransactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TypeTransactions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "TransferToCard" },
                    { 2, "InternetPayment" },
                    { 3, "UtilityCompany" },
                    { 4, "MobileTopUp" },
                    { 5, "Restaurants" },
                    { 6, "Clothing" },
                    { 7, "Pharmacy" },
                    { 8, "Charity" },
                    { 9, "Cinema" },
                    { 10, "Game" },
                    { 11, "Salary" },
                    { 12, "Fines" },
                    { 13, "Others" }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "DateTime", "Description", "RecipientName", "SenderName", "Sum", "TypeTransactionID" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 20, 18, 30, 25, 0, DateTimeKind.Unspecified), "On tea", "Orest", "Kolya", 370, 1 },
                    { 2, new DateTime(2022, 10, 14, 14, 12, 1, 0, DateTimeKind.Unspecified), "Shop of clothing", "Shop", "Jack Wilston", 654, 6 },
                    { 3, new DateTime(2022, 3, 15, 23, 33, 33, 0, DateTimeKind.Unspecified), "On tea", "Kolya", "Orest", 1232, 1 },
                    { 4, new DateTime(2022, 3, 15, 23, 33, 33, 0, DateTimeKind.Unspecified), "On tea", "Sasha", "Vlad", 25000, 1 },
                    { 5, new DateTime(2022, 10, 14, 14, 12, 1, 0, DateTimeKind.Unspecified), "Shop of clothing", "Shop", "Jack Wilston", 654, 6 },
                    { 6, new DateTime(2022, 3, 15, 23, 33, 33, 0, DateTimeKind.Unspecified), "On tea", "Vlad", "Orest", 250, 1 },
                    { 7, new DateTime(2022, 3, 15, 23, 33, 33, 0, DateTimeKind.Unspecified), "On tea", "Kolya", "Orest", 1232, 1 },
                    { 8, new DateTime(2022, 3, 15, 23, 33, 33, 0, DateTimeKind.Unspecified), "On tea", "Kolya", "Orest", 1232, 1 },
                    { 9, new DateTime(2022, 3, 15, 23, 33, 33, 0, DateTimeKind.Unspecified), "On tea", "Sasha", "Vlad", 25000, 1 },
                    { 10, new DateTime(2022, 3, 15, 23, 33, 33, 0, DateTimeKind.Unspecified), "On tea", "Vlad", "Orest", 250, 1 },
                    { 11, new DateTime(2015, 7, 15, 11, 43, 33, 0, DateTimeKind.Unspecified), "On tea", "Kolya", "Orest", 1232, 1 },
                    { 12, new DateTime(2022, 3, 15, 23, 33, 33, 0, DateTimeKind.Unspecified), "Payment tickets", "MultiplexUA", "Matt Colin", 34, 9 },
                    { 13, new DateTime(2022, 3, 15, 23, 33, 33, 0, DateTimeKind.Unspecified), "Payment tickets", "MultiplexUA", "Matt Colin", 34, 9 },
                    { 14, new DateTime(2022, 3, 15, 23, 33, 33, 0, DateTimeKind.Unspecified), "On tea", "Vlad", "Orest", 250, 1 },
                    { 15, new DateTime(2022, 10, 14, 14, 12, 1, 0, DateTimeKind.Unspecified), "Shop of clothing", "Shop", "Jack Wilston", 654, 6 },
                    { 16, new DateTime(2022, 10, 14, 14, 12, 1, 0, DateTimeKind.Unspecified), "Transfer money to internet card", "apple.com", "Matt Daymon", 7900, 2 },
                    { 17, new DateTime(2022, 1, 11, 19, 23, 22, 0, DateTimeKind.Unspecified), "Charity transfer", "Charity Fund", "Jonny Deph", 1293, 8 },
                    { 18, new DateTime(2015, 7, 15, 11, 43, 33, 0, DateTimeKind.Unspecified), "On tea", "Kolya", "Orest", 1232, 1 },
                    { 19, new DateTime(2022, 1, 11, 19, 23, 22, 0, DateTimeKind.Unspecified), "Charity transfer", "Charity Fund", "Jonny Deph", 1293, 8 },
                    { 20, new DateTime(2022, 3, 15, 23, 33, 33, 0, DateTimeKind.Unspecified), "Payment tickets", "MultiplexUA", "Matt Colin", 34, 9 },
                    { 21, new DateTime(2022, 3, 15, 23, 33, 33, 0, DateTimeKind.Unspecified), "On tea", "Vlad", "Orest", 250, 1 },
                    { 22, new DateTime(2022, 10, 14, 14, 12, 1, 0, DateTimeKind.Unspecified), "Shop of clothing", "Shop", "Jack Wilston", 654, 6 },
                    { 23, new DateTime(2022, 3, 15, 23, 33, 33, 0, DateTimeKind.Unspecified), "Payment tickets", "MultiplexUA", "Matt Colin", 34, 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TypeTransactionID",
                table: "Transactions",
                column: "TypeTransactionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "TypeTransactions");
        }
    }
}
