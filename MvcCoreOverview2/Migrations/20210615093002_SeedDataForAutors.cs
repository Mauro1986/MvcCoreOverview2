using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcCoreOverview2.Migrations
{
    public partial class SeedDataForAutors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Authors values('Jan', 'Jambon', 'Brussel')");
            migrationBuilder.Sql("insert into Authors values('Kenan', 'Kurda', 'Gent')");
            migrationBuilder.Sql("insert into Authors values('Emre', 'Elagoz', 'Antwerpen')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
