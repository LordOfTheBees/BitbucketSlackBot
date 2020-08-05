using Microsoft.EntityFrameworkCore.Migrations;

namespace BitbucketSlackBot.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SlackWorkspace",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlackWorkspace", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BitbucketRepository",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Workspace = table.Column<string>(nullable: true),
                    Repository = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    CommonAccess = table.Column<int>(nullable: false),
                    SlackTeamOwnerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BitbucketRepository", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BitbucketRepository_SlackWorkspace_SlackTeamOwnerID",
                        column: x => x.SlackTeamOwnerID,
                        principalTable: "SlackWorkspace",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SlackUser",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    TeamID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlackUser", x => new { x.ID, x.TeamID });
                    table.ForeignKey(
                        name: "FK_SlackUser_SlackWorkspace_TeamID",
                        column: x => x.TeamID,
                        principalTable: "SlackWorkspace",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SlackUserRepositoryAccess",
                columns: table => new
                {
                    SlackUserID = table.Column<int>(nullable: false),
                    BitbucketRepositoryID = table.Column<int>(nullable: false),
                    RepositoryAccess = table.Column<int>(nullable: false),
                    SlackUserID1 = table.Column<int>(nullable: false),
                    SlackUserTeamID = table.Column<int>(nullable: false),
                    SlackUserID2 = table.Column<int>(nullable: true),
                    SlackUserTeamID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlackUserRepositoryAccess", x => new { x.SlackUserID, x.BitbucketRepositoryID });
                    table.ForeignKey(
                        name: "FK_SlackUserRepositoryAccess_BitbucketRepository_BitbucketRepositoryID",
                        column: x => x.BitbucketRepositoryID,
                        principalTable: "BitbucketRepository",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SlackUserRepositoryAccess_SlackUser_SlackUserID1_SlackUserTeamID",
                        columns: x => new { x.SlackUserID1, x.SlackUserTeamID },
                        principalTable: "SlackUser",
                        principalColumns: new[] { "ID", "TeamID" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SlackUserRepositoryAccess_SlackUser_SlackUserID2_SlackUserTeamID1",
                        columns: x => new { x.SlackUserID2, x.SlackUserTeamID1 },
                        principalTable: "SlackUser",
                        principalColumns: new[] { "ID", "TeamID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subscriber",
                columns: table => new
                {
                    SlackUserID = table.Column<int>(nullable: false),
                    BitbucketRepositoryID = table.Column<int>(nullable: false),
                    OnRepositoryCreated = table.Column<bool>(nullable: false),
                    SlackUserID1 = table.Column<int>(nullable: false),
                    SlackUserTeamID = table.Column<int>(nullable: false),
                    SlackUserID2 = table.Column<int>(nullable: true),
                    SlackUserTeamID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriber", x => new { x.SlackUserID, x.BitbucketRepositoryID });
                    table.ForeignKey(
                        name: "FK_Subscriber_BitbucketRepository_BitbucketRepositoryID",
                        column: x => x.BitbucketRepositoryID,
                        principalTable: "BitbucketRepository",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscriber_SlackUser_SlackUserID1_SlackUserTeamID",
                        columns: x => new { x.SlackUserID1, x.SlackUserTeamID },
                        principalTable: "SlackUser",
                        principalColumns: new[] { "ID", "TeamID" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subscriber_SlackUser_SlackUserID2_SlackUserTeamID1",
                        columns: x => new { x.SlackUserID2, x.SlackUserTeamID1 },
                        principalTable: "SlackUser",
                        principalColumns: new[] { "ID", "TeamID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BitbucketRepository_SlackTeamOwnerID",
                table: "BitbucketRepository",
                column: "SlackTeamOwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_SlackUser_TeamID",
                table: "SlackUser",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_SlackUserRepositoryAccess_BitbucketRepositoryID",
                table: "SlackUserRepositoryAccess",
                column: "BitbucketRepositoryID");

            migrationBuilder.CreateIndex(
                name: "IX_SlackUserRepositoryAccess_SlackUserID1_SlackUserTeamID",
                table: "SlackUserRepositoryAccess",
                columns: new[] { "SlackUserID1", "SlackUserTeamID" });

            migrationBuilder.CreateIndex(
                name: "IX_SlackUserRepositoryAccess_SlackUserID2_SlackUserTeamID1",
                table: "SlackUserRepositoryAccess",
                columns: new[] { "SlackUserID2", "SlackUserTeamID1" });

            migrationBuilder.CreateIndex(
                name: "IX_Subscriber_BitbucketRepositoryID",
                table: "Subscriber",
                column: "BitbucketRepositoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriber_SlackUserID1_SlackUserTeamID",
                table: "Subscriber",
                columns: new[] { "SlackUserID1", "SlackUserTeamID" });

            migrationBuilder.CreateIndex(
                name: "IX_Subscriber_SlackUserID2_SlackUserTeamID1",
                table: "Subscriber",
                columns: new[] { "SlackUserID2", "SlackUserTeamID1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SlackUserRepositoryAccess");

            migrationBuilder.DropTable(
                name: "Subscriber");

            migrationBuilder.DropTable(
                name: "BitbucketRepository");

            migrationBuilder.DropTable(
                name: "SlackUser");

            migrationBuilder.DropTable(
                name: "SlackWorkspace");
        }
    }
}
