using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BitbucketSlackBot.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SlackTeam",
                columns: table => new
                {
                    SlackTeamID = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlackTeam", x => x.SlackTeamID);
                });

            migrationBuilder.CreateTable(
                name: "BitbucketRepository",
                columns: table => new
                {
                    BitbucketRepositoryUUID = table.Column<Guid>(nullable: false),
                    SlackTeamID = table.Column<string>(nullable: false),
                    Workspace = table.Column<string>(nullable: true),
                    Repository = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    CommonAccess = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BitbucketRepository", x => new { x.BitbucketRepositoryUUID, x.SlackTeamID });
                    table.ForeignKey(
                        name: "FK_BitbucketRepository_SlackTeam_SlackTeamID",
                        column: x => x.SlackTeamID,
                        principalTable: "SlackTeam",
                        principalColumn: "SlackTeamID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SlackUser",
                columns: table => new
                {
                    SlackUserID = table.Column<string>(maxLength: 30, nullable: false),
                    SlackTeamID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlackUser", x => new { x.SlackUserID, x.SlackTeamID });
                    table.ForeignKey(
                        name: "FK_SlackUser_SlackTeam_SlackTeamID",
                        column: x => x.SlackTeamID,
                        principalTable: "SlackTeam",
                        principalColumn: "SlackTeamID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SlackUserRepositoryAccess",
                columns: table => new
                {
                    SlackUserID = table.Column<string>(nullable: false),
                    SlackTeamID = table.Column<string>(nullable: false),
                    BitbucketRepositoryID = table.Column<Guid>(nullable: false),
                    RepositoryAccess = table.Column<int>(nullable: false),
                    BitbucketSlackTeamID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlackUserRepositoryAccess", x => new { x.SlackUserID, x.SlackTeamID, x.BitbucketRepositoryID });
                    table.CheckConstraint("SURA_CC_TeamIDMustBeEquals", "[BitbucketSlackTeamID] = [SlackTeamID]");
                    table.ForeignKey(
                        name: "FK_SlackUserRepositoryAccess_BitbucketRepository_BitbucketRepositoryID_BitbucketSlackTeamID",
                        columns: x => new { x.BitbucketRepositoryID, x.BitbucketSlackTeamID },
                        principalTable: "BitbucketRepository",
                        principalColumns: new[] { "BitbucketRepositoryUUID", "SlackTeamID" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SlackUserRepositoryAccess_SlackUser_SlackUserID_SlackTeamID",
                        columns: x => new { x.SlackUserID, x.SlackTeamID },
                        principalTable: "SlackUser",
                        principalColumns: new[] { "SlackUserID", "SlackTeamID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscriber",
                columns: table => new
                {
                    SlackUserID = table.Column<string>(nullable: false),
                    SlackTeamID = table.Column<string>(nullable: false),
                    BitbucketRepositoryID = table.Column<Guid>(nullable: false),
                    OnRepositoryCreated = table.Column<bool>(nullable: false),
                    BitbucketSlackTeamID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriber", x => new { x.SlackUserID, x.SlackTeamID, x.BitbucketRepositoryID });
                    table.CheckConstraint("S_CC_TeamIDMustBeEquals", "[BitbucketSlackTeamID] = [SlackTeamID]");
                    table.ForeignKey(
                        name: "FK_Subscriber_BitbucketRepository_BitbucketRepositoryID_BitbucketSlackTeamID",
                        columns: x => new { x.BitbucketRepositoryID, x.BitbucketSlackTeamID },
                        principalTable: "BitbucketRepository",
                        principalColumns: new[] { "BitbucketRepositoryUUID", "SlackTeamID" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscriber_SlackUser_SlackUserID_SlackTeamID",
                        columns: x => new { x.SlackUserID, x.SlackTeamID },
                        principalTable: "SlackUser",
                        principalColumns: new[] { "SlackUserID", "SlackTeamID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BitbucketRepository_SlackTeamID",
                table: "BitbucketRepository",
                column: "SlackTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_SlackUser_SlackTeamID",
                table: "SlackUser",
                column: "SlackTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_SlackUserRepositoryAccess_BitbucketRepositoryID_BitbucketSlackTeamID",
                table: "SlackUserRepositoryAccess",
                columns: new[] { "BitbucketRepositoryID", "BitbucketSlackTeamID" });

            migrationBuilder.CreateIndex(
                name: "IX_Subscriber_BitbucketRepositoryID_BitbucketSlackTeamID",
                table: "Subscriber",
                columns: new[] { "BitbucketRepositoryID", "BitbucketSlackTeamID" });
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
                name: "SlackTeam");
        }
    }
}
