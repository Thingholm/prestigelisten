using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "nations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    code = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "race_classifications",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_race_classifications", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "teams",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teams", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "nation_points",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nation_id = table.Column<int>(type: "integer", nullable: false),
                    points = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nation_points", x => x.id);
                    table.ForeignKey(
                        name: "FK_nation_points_nations_nation_id",
                        column: x => x.nation_id,
                        principalTable: "nations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nation_rankings_each_year",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nation_id = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    points = table.Column<int>(type: "integer", nullable: true),
                    placement = table.Column<int>(type: "integer", nullable: true),
                    number_of_results = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nation_rankings_each_year", x => x.id);
                    table.ForeignKey(
                        name: "FK_nation_rankings_each_year_nations_nation_id",
                        column: x => x.nation_id,
                        principalTable: "nations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nation_rankings_each_year_accumulated",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nation_id = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    points = table.Column<int>(type: "integer", nullable: true),
                    placement = table.Column<int>(type: "integer", nullable: true),
                    number_of_results = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nation_rankings_each_year_accumulated", x => x.id);
                    table.ForeignKey(
                        name: "FK_nation_rankings_each_year_accumulated_nations_nation_id",
                        column: x => x.nation_id,
                        principalTable: "nations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "point_system",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    race_classification_id = table.Column<int>(type: "integer", nullable: false),
                    result_type = table.Column<string>(type: "text", nullable: false),
                    points = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_point_system", x => x.id);
                    table.ForeignKey(
                        name: "FK_point_system_race_classifications_race_classification_id",
                        column: x => x.race_classification_id,
                        principalTable: "race_classifications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "races",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    active_span = table.Column<string>(type: "text", nullable: true),
                    nation_id = table.Column<int>(type: "integer", nullable: true),
                    race_classification_id = table.Column<int>(type: "integer", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    color_hex = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_races", x => x.id);
                    table.ForeignKey(
                        name: "FK_races_nations_nation_id",
                        column: x => x.nation_id,
                        principalTable: "nations",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_races_race_classifications_race_classification_id",
                        column: x => x.race_classification_id,
                        principalTable: "race_classifications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "riders",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "text", nullable: true),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    birth_year = table.Column<int>(type: "integer", nullable: true),
                    nation_id = table.Column<int>(type: "integer", nullable: false),
                    team_id = table.Column<int>(type: "integer", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_riders", x => x.id);
                    table.ForeignKey(
                        name: "FK_riders_nations_nation_id",
                        column: x => x.nation_id,
                        principalTable: "nations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_riders_teams_team_id",
                        column: x => x.team_id,
                        principalTable: "teams",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "race_calendar",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    race_id = table.Column<int>(type: "integer", nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_race_calendar", x => x.id);
                    table.ForeignKey(
                        name: "FK_race_calendar_races_race_id",
                        column: x => x.race_id,
                        principalTable: "races",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "race_dates",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    race_id = table.Column<int>(type: "integer", nullable: false),
                    stage = table.Column<int>(type: "integer", nullable: true),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_race_dates", x => x.id);
                    table.ForeignKey(
                        name: "FK_race_dates_races_race_id",
                        column: x => x.race_id,
                        principalTable: "races",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "previous_nationalities",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rider_id = table.Column<int>(type: "integer", nullable: false),
                    nation_id = table.Column<int>(type: "integer", nullable: false),
                    start_year = table.Column<int>(type: "integer", maxLength: 4, nullable: true),
                    end_year = table.Column<int>(type: "integer", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_previous_nationalities", x => x.id);
                    table.ForeignKey(
                        name: "FK_previous_nationalities_nations_nation_id",
                        column: x => x.nation_id,
                        principalTable: "nations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_previous_nationalities_riders_rider_id",
                        column: x => x.rider_id,
                        principalTable: "riders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rider_points",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rider_id = table.Column<int>(type: "integer", nullable: false),
                    points = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rider_points", x => x.id);
                    table.ForeignKey(
                        name: "FK_rider_points_riders_rider_id",
                        column: x => x.rider_id,
                        principalTable: "riders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rider_rankings_3_year_span",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rider_id = table.Column<int>(type: "integer", nullable: false),
                    start_year = table.Column<int>(type: "integer", nullable: false),
                    end_year = table.Column<int>(type: "integer", nullable: false),
                    points = table.Column<int>(type: "integer", nullable: true),
                    placement = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rider_rankings_3_year_span", x => x.id);
                    table.ForeignKey(
                        name: "FK_rider_rankings_3_year_span_riders_rider_id",
                        column: x => x.rider_id,
                        principalTable: "riders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rider_rankings_each_decade",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rider_id = table.Column<int>(type: "integer", nullable: false),
                    decade = table.Column<int>(type: "integer", nullable: false),
                    points = table.Column<int>(type: "integer", nullable: true),
                    placement = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rider_rankings_each_decade", x => x.id);
                    table.ForeignKey(
                        name: "FK_rider_rankings_each_decade_riders_rider_id",
                        column: x => x.rider_id,
                        principalTable: "riders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rider_rankings_each_year",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rider_id = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    points = table.Column<int>(type: "integer", nullable: true),
                    placement = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rider_rankings_each_year", x => x.id);
                    table.ForeignKey(
                        name: "FK_rider_rankings_each_year_riders_rider_id",
                        column: x => x.rider_id,
                        principalTable: "riders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rider_rankings_each_year_accumulated",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rider_id = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    points = table.Column<int>(type: "integer", nullable: false),
                    placement = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rider_rankings_each_year_accumulated", x => x.id);
                    table.ForeignKey(
                        name: "FK_rider_rankings_each_year_accumulated_riders_rider_id",
                        column: x => x.rider_id,
                        principalTable: "riders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "results",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    race_id = table.Column<int>(type: "integer", nullable: false),
                    rider_id = table.Column<int>(type: "integer", nullable: false),
                    result_type = table.Column<string>(type: "text", nullable: false),
                    placement = table.Column<int>(type: "integer", nullable: true),
                    race_date_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_results", x => x.id);
                    table.ForeignKey(
                        name: "FK_results_race_dates_race_date_id",
                        column: x => x.race_date_id,
                        principalTable: "race_dates",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_results_races_race_id",
                        column: x => x.race_id,
                        principalTable: "races",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_results_riders_rider_id",
                        column: x => x.rider_id,
                        principalTable: "riders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_nation_points_nation_id",
                table: "nation_points",
                column: "nation_id");

            migrationBuilder.CreateIndex(
                name: "IX_nation_rankings_each_year_nation_id",
                table: "nation_rankings_each_year",
                column: "nation_id");

            migrationBuilder.CreateIndex(
                name: "IX_nation_rankings_each_year_accumulated_nation_id",
                table: "nation_rankings_each_year_accumulated",
                column: "nation_id");

            migrationBuilder.CreateIndex(
                name: "IX_point_system_race_classification_id",
                table: "point_system",
                column: "race_classification_id");

            migrationBuilder.CreateIndex(
                name: "IX_previous_nationalities_nation_id",
                table: "previous_nationalities",
                column: "nation_id");

            migrationBuilder.CreateIndex(
                name: "IX_previous_nationalities_rider_id",
                table: "previous_nationalities",
                column: "rider_id");

            migrationBuilder.CreateIndex(
                name: "IX_race_calendar_race_id",
                table: "race_calendar",
                column: "race_id");

            migrationBuilder.CreateIndex(
                name: "IX_race_dates_race_id",
                table: "race_dates",
                column: "race_id");

            migrationBuilder.CreateIndex(
                name: "IX_races_nation_id",
                table: "races",
                column: "nation_id");

            migrationBuilder.CreateIndex(
                name: "IX_races_race_classification_id",
                table: "races",
                column: "race_classification_id");

            migrationBuilder.CreateIndex(
                name: "IX_results_race_date_id",
                table: "results",
                column: "race_date_id");

            migrationBuilder.CreateIndex(
                name: "IX_results_race_id",
                table: "results",
                column: "race_id");

            migrationBuilder.CreateIndex(
                name: "IX_results_rider_id",
                table: "results",
                column: "rider_id");

            migrationBuilder.CreateIndex(
                name: "IX_rider_points_rider_id",
                table: "rider_points",
                column: "rider_id");

            migrationBuilder.CreateIndex(
                name: "IX_rider_rankings_3_year_span_rider_id",
                table: "rider_rankings_3_year_span",
                column: "rider_id");

            migrationBuilder.CreateIndex(
                name: "IX_rider_rankings_each_decade_rider_id",
                table: "rider_rankings_each_decade",
                column: "rider_id");

            migrationBuilder.CreateIndex(
                name: "IX_rider_rankings_each_year_rider_id",
                table: "rider_rankings_each_year",
                column: "rider_id");

            migrationBuilder.CreateIndex(
                name: "IX_rider_rankings_each_year_accumulated_rider_id",
                table: "rider_rankings_each_year_accumulated",
                column: "rider_id");

            migrationBuilder.CreateIndex(
                name: "IX_riders_nation_id",
                table: "riders",
                column: "nation_id");

            migrationBuilder.CreateIndex(
                name: "IX_riders_team_id",
                table: "riders",
                column: "team_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nation_points");

            migrationBuilder.DropTable(
                name: "nation_rankings_each_year");

            migrationBuilder.DropTable(
                name: "nation_rankings_each_year_accumulated");

            migrationBuilder.DropTable(
                name: "point_system");

            migrationBuilder.DropTable(
                name: "previous_nationalities");

            migrationBuilder.DropTable(
                name: "race_calendar");

            migrationBuilder.DropTable(
                name: "results");

            migrationBuilder.DropTable(
                name: "rider_points");

            migrationBuilder.DropTable(
                name: "rider_rankings_3_year_span");

            migrationBuilder.DropTable(
                name: "rider_rankings_each_decade");

            migrationBuilder.DropTable(
                name: "rider_rankings_each_year");

            migrationBuilder.DropTable(
                name: "rider_rankings_each_year_accumulated");

            migrationBuilder.DropTable(
                name: "race_dates");

            migrationBuilder.DropTable(
                name: "riders");

            migrationBuilder.DropTable(
                name: "races");

            migrationBuilder.DropTable(
                name: "teams");

            migrationBuilder.DropTable(
                name: "nations");

            migrationBuilder.DropTable(
                name: "race_classifications");
        }
    }
}
