using Microsoft.EntityFrameworkCore.Migrations;

namespace BitbucketSlackBot.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SlackUser",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<string>(nullable: true),
                    UserUuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlackUser", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SlackWorkspace",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkspaceName = table.Column<string>(nullable: true),
                    WorkspaceUuid = table.Column<string>(nullable: true)
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
                    SlackWorkspaceOwnerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BitbucketRepository", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BitbucketRepository_SlackWorkspace_SlackWorkspaceOwnerID",
                        column: x => x.SlackWorkspaceOwnerID,
                        principalTable: "SlackWorkspace",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SlackUserWorkspaceSettings",
                columns: table => new
                {
                    SlackUserID = table.Column<int>(nullable: false),
                    SlackWorkspaceID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlackUserWorkspaceSettings", x => new { x.SlackUserID, x.SlackWorkspaceID });
                    table.ForeignKey(
                        name: "FK_SlackUserWorkspaceSettings_SlackUser_SlackUserID",
                        column: x => x.SlackUserID,
                        principalTable: "SlackUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SlackUserWorkspaceSettings_SlackWorkspace_SlackWorkspaceID",
                        column: x => x.SlackWorkspaceID,
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
                    RepositoryAccess = table.Column<int>(nullable: false)
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
                        name: "FK_SlackUserRepositoryAccess_SlackUser_SlackUserID",
                        column: x => x.SlackUserID,
                        principalTable: "SlackUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscriber",
                columns: table => new
                {
                    SlackUserID = table.Column<int>(nullable: false),
                    BitbucketRepositoryID = table.Column<int>(nullable: false),
                    OnRepositoryCreated = table.Column<bool>(nullable: false)
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
                        name: "FK_Subscriber_SlackUser_SlackUserID",
                        column: x => x.SlackUserID,
                        principalTable: "SlackUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BitbucketRepository_SlackWorkspaceOwnerID",
                table: "BitbucketRepository",
                column: "SlackWorkspaceOwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_SlackUserRepositoryAccess_BitbucketRepositoryID",
                table: "SlackUserRepositoryAccess",
                column: "BitbucketRepositoryID");

            migrationBuilder.CreateIndex(
                name: "IX_SlackUserWorkspaceSettings_SlackWorkspaceID",
                table: "SlackUserWorkspaceSettings",
                column: "SlackWorkspaceID");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriber_BitbucketRepositoryID",
                table: "Subscriber",
                column: "BitbucketRepositoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SlackUserRepositoryAccess");

            migrationBuilder.DropTable(
                name: "SlackUserWorkspaceSettings");

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
