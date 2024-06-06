using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Papeleriaweb.Migrations
{
    /// <inheritdoc />
    public partial class migracion2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id_producto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombreproducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marcaproducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcionproducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precioproducto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stockproducto = table.Column<int>(type: "int", nullable: false),
                    Tamañoproducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colorproducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipoproducto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id_producto);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Producto");
        }
    }
}
