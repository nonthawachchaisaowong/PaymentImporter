using Microsoft.EntityFrameworkCore.Migrations;
using System.Globalization;
using System.Linq;

namespace PaymentImporter.Infrastructure.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Initial transaction data

            migrationBuilder.InsertData(
              table: "TransactionStatus",
              columns: new[] { "Status", "UnifiedFormat" },
              values: new object[] { "Approved", "A" });

            migrationBuilder.InsertData(
                table: "TransactionStatus",
                columns: new[] { "Status", "UnifiedFormat" },
                values: new object[] { "Failed", "R" });

            migrationBuilder.InsertData(
                table: "TransactionStatus",
                columns: new[] { "Status", "UnifiedFormat" },
                values: new object[] { "Finished", "D" });

            migrationBuilder.InsertData(
                table: "TransactionStatus",
                columns: new[] { "Status", "UnifiedFormat" },
                values: new object[] { "Rejected", "R" });

            migrationBuilder.InsertData(
                table: "TransactionStatus",
                columns: new[] { "Status", "UnifiedFormat" },
                values: new object[] { "Done", "D" });

            // Initial currency data

            var currencies = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                                      .Select(ci => ci.LCID).Distinct()
                                      .Select(id => new RegionInfo(id))
                                      .GroupBy(r => r.ISOCurrencySymbol)
                                      .Select(g => g.First())
                                      .Select(r => new
                                      {
                                          r.ISOCurrencySymbol,
                                          r.CurrencyEnglishName
                                      }).OrderBy(o => o.ISOCurrencySymbol);

            foreach (var item in currencies)
            {
                migrationBuilder.InsertData(
                               table: "Currency",
                               columns: new[] { "Name", "CurrencyCode" },
                               values: new object[] { item.CurrencyEnglishName, item.ISOCurrencySymbol });
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
             table: "TransactionStatus",
             keyColumn: "Status",
             keyValue: "Approved");

            migrationBuilder.DeleteData(
              table: "TransactionStatus",
              keyColumn: "Status",
              keyValue: "Failed");

            migrationBuilder.DeleteData(
              table: "TransactionStatus",
              keyColumn: "Status",
              keyValue: "Finished");

            migrationBuilder.DeleteData(
              table: "TransactionStatus",
              keyColumn: "Status",
              keyValue: "Rejected");

            migrationBuilder.DeleteData(
              table: "TransactionStatus",
              keyColumn: "Status",
              keyValue: "Done");

            var currencies = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                                 .Select(ci => ci.LCID).Distinct()
                                 .Select(id => new RegionInfo(id))
                                 .GroupBy(r => r.ISOCurrencySymbol)
                                 .Select(g => g.First())
                                 .Select(r => new
                                 {
                                     r.ISOCurrencySymbol
                                 }).OrderBy(o => o.ISOCurrencySymbol);

            foreach (var item in currencies)
            {
                migrationBuilder.DeleteData(
                            table: "Currency",
                            keyColumn: "CurrencyCode",
                            keyValue: item.ISOCurrencySymbol);
            }
        }
    }
}
