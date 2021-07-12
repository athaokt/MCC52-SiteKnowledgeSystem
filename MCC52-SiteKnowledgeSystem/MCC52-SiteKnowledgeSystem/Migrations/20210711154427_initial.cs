using Microsoft.EntityFrameworkCore.Migrations;

namespace MCC52_SiteKnowledgeSystem.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_m_Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_Sites",
                columns: table => new
                {
                    SiteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_Sites", x => x.SiteId);
                });

            migrationBuilder.CreateTable(
                name: "tb_t_Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    SiteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_t_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_tb_t_Employees_tb_m_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "tb_m_Sites",
                        principalColumn: "SiteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_t_Accounts",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_t_Accounts", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_tb_t_Accounts_tb_t_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "tb_t_Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_t_Contents",
                columns: table => new
                {
                    ContentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViewCounter = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_t_Contents", x => x.ContentId);
                    table.ForeignKey(
                        name: "FK_tb_t_Contents_tb_m_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "tb_m_Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_t_Contents_tb_t_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "tb_t_Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_t_RequestForms",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_t_RequestForms", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_tb_t_RequestForms_tb_t_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "tb_t_Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_t_AccountRoles",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_t_AccountRoles", x => new { x.EmployeeId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_tb_t_AccountRoles_tb_m_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tb_m_Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_t_AccountRoles_tb_t_Accounts_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "tb_t_Accounts",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_t_Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ContentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_t_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_tb_t_Messages_tb_t_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "tb_t_Contents",
                        principalColumn: "ContentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_t_Messages_tb_t_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "tb_t_Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_t_AccountRoles_RoleId",
                table: "tb_t_AccountRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_t_Contents_CategoryId",
                table: "tb_t_Contents",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_t_Contents_EmployeeId",
                table: "tb_t_Contents",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_t_Employees_SiteId",
                table: "tb_t_Employees",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_t_Messages_ContentId",
                table: "tb_t_Messages",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_t_Messages_EmployeeId",
                table: "tb_t_Messages",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_t_RequestForms_EmployeeId",
                table: "tb_t_RequestForms",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_t_AccountRoles");

            migrationBuilder.DropTable(
                name: "tb_t_Messages");

            migrationBuilder.DropTable(
                name: "tb_t_RequestForms");

            migrationBuilder.DropTable(
                name: "tb_m_Roles");

            migrationBuilder.DropTable(
                name: "tb_t_Accounts");

            migrationBuilder.DropTable(
                name: "tb_t_Contents");

            migrationBuilder.DropTable(
                name: "tb_m_Category");

            migrationBuilder.DropTable(
                name: "tb_t_Employees");

            migrationBuilder.DropTable(
                name: "tb_m_Sites");
        }
    }
}
