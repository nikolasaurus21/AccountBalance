using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AccountBalance.Migrations
{
    public partial class Relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "moneyaccount",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    balance = table.Column<decimal>(type: "numeric", nullable: false),
                    expences = table.Column<decimal>(type: "numeric", nullable: false),
                    saved = table.Column<decimal>(type: "numeric", nullable: false),
                    salary = table.Column<decimal>(type: "numeric", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_moneyaccount", x => x.id);
                    table.ForeignKey(
                        name: "fk_moneyaccount_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "moneyhistory",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    history_type = table.Column<int>(type: "integer", nullable: false),
                    money_acc_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_moneyhistory", x => x.id);
                    table.ForeignKey(
                        name: "fk_moneyhistory_moneyaccount_money_acc_id",
                        column: x => x.money_acc_id,
                        principalTable: "moneyaccount",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_moneyaccount_user_id",
                table: "moneyaccount",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_moneyhistory_money_acc_id",
                table: "moneyhistory",
                column: "money_acc_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "moneyhistory");

            migrationBuilder.DropTable(
                name: "moneyaccount");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
