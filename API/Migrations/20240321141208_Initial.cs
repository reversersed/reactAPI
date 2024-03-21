using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Rating = table.Column<float>(type: "real", nullable: true),
                    Year = table.Column<int>(type: "integer", nullable: true),
                    Cover = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true),
                    Tagline = table.Column<string>(type: "text", nullable: true),
                    Director = table.Column<string>(type: "text", nullable: true),
                    Screenwriter = table.Column<string>(type: "text", nullable: true),
                    Producer = table.Column<string>(type: "text", nullable: true),
                    Videographer = table.Column<string>(type: "text", nullable: true),
                    Composer = table.Column<string>(type: "text", nullable: true),
                    Drawer = table.Column<string>(type: "text", nullable: true),
                    Montage = table.Column<string>(type: "text", nullable: true),
                    Budget = table.Column<int>(type: "integer", nullable: true),
                    Collected = table.Column<int>(type: "integer", nullable: true),
                    Premier = table.Column<DateOnly>(type: "date", nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movies");
        }
    }
}
