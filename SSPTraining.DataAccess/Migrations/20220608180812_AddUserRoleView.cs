#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;
using SSPTraining.Common.Constants;

namespace SSPTraining.DataAccess.Migrations;

public partial class AddUserRoleView : Migration
{
	protected override void Up(MigrationBuilder migrationBuilder) =>
		migrationBuilder.Sql(QueryConstant.AddUserRolesView);

	protected override void Down(MigrationBuilder migrationBuilder) =>
		migrationBuilder.Sql(QueryConstant.DeleteUserRolesView);
}