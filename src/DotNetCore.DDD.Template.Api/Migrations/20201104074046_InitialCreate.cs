using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DotNetCore.DDD.Template.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "test_platform");

            migrationBuilder.CreateTable(
                name: "test_case_group",
                schema: "test_platform",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    Sort = table.Column<short>(nullable: false),
                    OperCode = table.Column<string>(maxLength: 16, nullable: true),
                    OperTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_test_case_group", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "test_case",
                schema: "test_platform",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TestCaseGroupId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    Sort = table.Column<short>(nullable: false),
                    CodeContent = table.Column<string>(nullable: true),
                    OperCode = table.Column<string>(maxLength: 16, nullable: true),
                    OperTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_test_case", x => x.Id);
                    table.ForeignKey(
                        name: "FK_test_case_test_case_group_TestCaseGroupId",
                        column: x => x.TestCaseGroupId,
                        principalSchema: "test_platform",
                        principalTable: "test_case_group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "test_case_detail",
                schema: "test_platform",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TestCaseId = table.Column<long>(nullable: false),
                    Sort = table.Column<short>(nullable: false),
                    Params = table.Column<string[]>(maxLength: 16, nullable: true),
                    Variables = table.Column<string[]>(maxLength: 16, nullable: true),
                    EditorName = table.Column<string>(maxLength: 32, nullable: true),
                    Result = table.Column<string>(nullable: true),
                    IsCallBack = table.Column<bool>(nullable: false),
                    CallBackFormId = table.Column<long>(nullable: true),
                    OperCode = table.Column<string>(maxLength: 16, nullable: true),
                    OperTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_test_case_detail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_test_case_detail_test_case_TestCaseId",
                        column: x => x.TestCaseId,
                        principalSchema: "test_platform",
                        principalTable: "test_case",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_test_case_TestCaseGroupId",
                schema: "test_platform",
                table: "test_case",
                column: "TestCaseGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_test_case_detail_TestCaseId",
                schema: "test_platform",
                table: "test_case_detail",
                column: "TestCaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "test_case_detail",
                schema: "test_platform");

            migrationBuilder.DropTable(
                name: "test_case",
                schema: "test_platform");

            migrationBuilder.DropTable(
                name: "test_case_group",
                schema: "test_platform");
        }
    }
}
