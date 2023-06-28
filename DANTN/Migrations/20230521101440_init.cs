using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DANTN.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    LevelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LevelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Point = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.LevelId);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    TopicId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ParentID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NameTopic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TopicImage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TopicDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TopicAlias = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ViewCount = table.Column<int>(type: "int", maxLength: 255, nullable: true),
                    LevelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.TopicId);
                    table.ForeignKey(
                        name: "FK_Topics_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "LevelId");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirm = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LevelId = table.Column<int>(type: "int", nullable: false),
                    Point = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "LevelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TopicId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Answer_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer_4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCorrect = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isTuluan = table.Column<bool>(type: "bit", nullable: false),
                    QuesURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_Questions_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "TopicId");
                });

            migrationBuilder.CreateTable(
                name: "Vocabularies",
                columns: table => new
                {
                    VocId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WordVoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vocImgUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    vocExample = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    vocIPA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    level = table.Column<int>(type: "int", maxLength: 255, nullable: true),
                    typeVoc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vocabularies", x => x.VocId);
                    table.ForeignKey(
                        name: "FK_Vocabularies_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "TopicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "LevelId", "LevelName", "Point" },
                values: new object[] { 0, "Level 1", null });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "TopicId", "LevelId", "NameTopic", "ParentID", "TopicAlias", "TopicDesc", "TopicImage", "ViewCount" },
                values: new object[] { "TPFruits", null, "Fruits", "TP01", "aaa", "lorem abc das das was we awen", "https://example.com/avatar.jpg", 0 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "Answer_1", "Answer_2", "Answer_3", "Answer_4", "ImageURL", "IsCorrect", "QuesURL", "QuestionString", "TopicId", "isTuluan" },
                values: new object[,]
                {
                    { 1, "Apple", "Banana", "Lemon", "Kiwi", "", 0, null, "This is a test question", "TPFruits", false },
                    { 2, "Apple", "", "", "", "", 0, null, "Số táo viết như thế nào", "TPFruits", true }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Avatar", "Code", "DateTimeCreated", "Dob", "Email", "EmailConfirm", "FirstName", "LastLogin", "LastName", "LevelId", "PasswordHash", "PhoneNumber", "Point", "Role", "UserName" },
                values: new object[] { new Guid("91a2cca2-7bf1-451b-a47e-9f33ad54bd3c"), "https://example.com/avatar2.jpg", null, new DateTime(2022, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1985, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "user1@example.com", true, "Jane", new DateTime(2023, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doe", 0, "0E7517141FB53F21EE439B355B5A1D0A", null, null, 1, "user1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Avatar", "Code", "DateTimeCreated", "Dob", "Email", "EmailConfirm", "FirstName", "LastLogin", "LastName", "LevelId", "PasswordHash", "PhoneNumber", "Point", "UserName" },
                values: new object[] { new Guid("f75de9b6-51cd-4578-bfac-8d5eec4068b5"), "https://example.com/avatar.jpg", null, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@example.com", true, "John", new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doe", 0, "0E7517141FB53F21EE439B355B5A1D0A", null, null, "admin" });

            migrationBuilder.InsertData(
                table: "Vocabularies",
                columns: new[] { "VocId", "TopicId", "WordVoc", "level", "typeVoc", "vocExample", "vocIPA", "vocImgUrl" },
                values: new object[] { 1, "TPFruits", "Orange", 1, "N", "This is my orange", "orange", "https://example.com/avatar.jpg" });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TopicId",
                table: "Questions",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_LevelId",
                table: "Topics",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LevelId",
                table: "Users",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Vocabularies_TopicId",
                table: "Vocabularies",
                column: "TopicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vocabularies");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Levels");
        }
    }
}
