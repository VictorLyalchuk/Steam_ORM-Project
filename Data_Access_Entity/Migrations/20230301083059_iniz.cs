using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data_Access_Entity.Migrations
{
    public partial class iniz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Login = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AccountID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfStaff = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SupportedLanguages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Language = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportedLanguages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Accounts_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CostPrice = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Raiting = table.Column<int>(type: "int", nullable: false),
                    CountOfSell = table.Column<int>(type: "int", nullable: false),
                    OriginalGame = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeveloperID = table.Column<int>(type: "int", nullable: false),
                    PublisherID = table.Column<int>(type: "int", nullable: false),
                    GenreID = table.Column<int>(type: "int", nullable: false),
                    TagID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Games_Developers_DeveloperID",
                        column: x => x.DeveloperID,
                        principalTable: "Developers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_Genres_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genres",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_Publishers_PublisherID",
                        column: x => x.PublisherID,
                        principalTable: "Publishers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_Tags_TagID",
                        column: x => x.TagID,
                        principalTable: "Tags",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientGame",
                columns: table => new
                {
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    GameID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientGame", x => new { x.ClientID, x.GameID });
                    table.ForeignKey(
                        name: "FK_ClientGame_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientGame_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameSupportedLanguage",
                columns: table => new
                {
                    _GamesID = table.Column<int>(type: "int", nullable: false),
                    _SupportedLanguagesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSupportedLanguage", x => new { x._GamesID, x._SupportedLanguagesID });
                    table.ForeignKey(
                        name: "FK_GameSupportedLanguage_Games__GamesID",
                        column: x => x._GamesID,
                        principalTable: "Games",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameSupportedLanguage_SupportedLanguages__SupportedLanguagesID",
                        column: x => x._SupportedLanguagesID,
                        principalTable: "SupportedLanguages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ID", "AccountID", "Email", "FullName", "Login", "Password" },
                values: new object[] { 1, 1, "Victor@ukr.net", "Victor Lyalchuk", "Admin", "123" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "ID", "Country", "Name", "NumberOfStaff" },
                values: new object[,]
                {
                    { 12, "USA", "Endnight Games Ltd", 90 },
                    { 10, "USA", "Visual Concepts", 180 },
                    { 9, "USA", "Criterion Games", 140 },
                    { 8, "USA", "Naughty Dog LLC", 280 },
                    { 7, "USA", "Larian Studios", 80 },
                    { 11, "USA", "EA Canada & EA Romania", 120 },
                    { 5, "Poland", "CD PROJEKT RED", 520 },
                    { 4, "USA", "Infinity Ward", 20 },
                    { 3, "USA", "President Studio", 20 },
                    { 2, "USA", "Avalanche Software", 1500 },
                    { 1, "USA", "Rockstar Games", 2000 },
                    { 6, "USA", "Respawn", 250 }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 6, "Sport" },
                    { 5, "Racing" },
                    { 4, "Adventure" },
                    { 3, "Strategy" },
                    { 1, "Action" },
                    { 2, "RPG" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "ID", "Country", "Name" },
                values: new object[,]
                {
                    { 7, "USA", "Larian Studios" },
                    { 10, "USA", "Newnight" },
                    { 9, "USA", "2K" },
                    { 8, "USA", "PlayStation PC LLC" },
                    { 6, "USA", "Electronic Arts" },
                    { 2, "USA", "Warner Bros. Games" },
                    { 4, "USA", "Activision" },
                    { 3, "USA", "President Studio" },
                    { 1, "USA", "Rockstar Games" },
                    { 5, "USA", "CD PROJEKT RED" }
                });

            migrationBuilder.InsertData(
                table: "SupportedLanguages",
                columns: new[] { "ID", "Language" },
                values: new object[,]
                {
                    { 1, "English" },
                    { 2, "French" },
                    { 3, "German" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 8, "Cosmos Game" },
                    { 1, "Сriminal game" },
                    { 2, "Include cursing" },
                    { 3, "New Year Game" },
                    { 4, "Family Game" },
                    { 5, "Indie Game" },
                    { 6, "Military Game" },
                    { 7, "Historical Game" },
                    { 9, "Ection Game" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "ID", "AccountType", "ClientID" },
                values: new object[] { 1, "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "ID", "CostPrice", "CountOfSell", "DeveloperID", "GenreID", "Name", "OriginalGame", "Price", "PublisherID", "Raiting", "ReleaseDate", "TagID" },
                values: new object[,]
                {
                    { 1, 50, 10, 1, 1, "Grand Theft Auto V", "", 120, 1, 8, new DateTime(2013, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, 70, 0, 2, 2, "Hogwarts Legacy", "", 350, 2, 7, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 9, 50, 0, 8, 4, "UNCHARTED™: Legacy of Thieves Collection", "", 380, 8, 7, new DateTime(2022, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 3, 45, 0, 3, 3, "I Am Your President", "", 220, 3, 3, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 4, 85, 2, 4, 1, "Call of Duty®: Modern Warfare® II", "", 450, 4, 6, new DateTime(2022, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 5, 75, 0, 5, 2, "The Witcher® 3: Wild Hunt", "", 550, 5, 9, new DateTime(2015, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 7, 60, 150, 1, 2, "Red Dead Redemption 2", "", 450, 1, 8, new DateTime(2019, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 8, 40, 0, 7, 2, "Divinity: Original Sin 2 - Definitive Edition", "", 240, 7, 6, new DateTime(2017, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 13, 25, 0, 12, 1, "Sons Of The Forest", "", 130, 10, 6, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 6, 70, 0, 6, 1, "STAR WARS Jedi: Survivor™", "", 550, 6, 6, new DateTime(2023, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 10, 35, 3, 9, 5, "Need for Speed™ Unbound", "", 280, 6, 5, new DateTime(2022, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 11, 45, 0, 10, 6, "NBA 2K23", "", 330, 9, 6, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 12, 85, 0, 11, 6, "EA SPORTS™ FIFA 23", "", 830, 6, 7, new DateTime(2022, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 14, 55, 0, 5, 2, "Cyberpunk 2077\r\n", "", 830, 5, 7, new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ClientID",
                table: "Accounts",
                column: "ClientID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientGame_GameID",
                table: "ClientGame",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_DeveloperID",
                table: "Games",
                column: "DeveloperID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_GenreID",
                table: "Games",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PublisherID",
                table: "Games",
                column: "PublisherID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_TagID",
                table: "Games",
                column: "TagID");

            migrationBuilder.CreateIndex(
                name: "IX_GameSupportedLanguage__SupportedLanguagesID",
                table: "GameSupportedLanguage",
                column: "_SupportedLanguagesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "ClientGame");

            migrationBuilder.DropTable(
                name: "GameSupportedLanguage");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "SupportedLanguages");

            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
