using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSPTraining.DataAccess.Migrations;

public partial class Initial : Migration
{
	protected override void Up(MigrationBuilder migrationBuilder)
	{
		migrationBuilder.CreateTable(
			name: "Persons",
			columns: table => new
			{
				Id = table.Column<int>(type: "int", nullable: false)
					.Annotation("SqlServer:Identity", "1, 1"),
				Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
				Family = table.Column<string>(type: "nvarchar(max)", nullable: true),
				CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
				LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
			},
			constraints: table =>
			{
				table.PrimaryKey("PK_Persons", x => x.Id);
			});

		migrationBuilder.CreateTable(
			name: "Roles",
			columns: table => new
			{
				Id = table.Column<int>(type: "int", nullable: false)
					.Annotation("SqlServer:Identity", "1, 1"),
				Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
				Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
				CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
				LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
			},
			constraints: table =>
			{
				table.PrimaryKey("PK_Roles", x => x.Id);
			});

		migrationBuilder.CreateTable(
			name: "Users",
			columns: table => new
			{
				Id = table.Column<int>(type: "int", nullable: false)
					.Annotation("SqlServer:Identity", "1, 1"),
				Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
				Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
				PersonId = table.Column<int>(type: "int", nullable: false),
				CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
				LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
			},
			constraints: table =>
			{
				table.PrimaryKey("PK_Users", x => x.Id);
				table.ForeignKey(
					name: "FK_Users_Persons_PersonId",
					column: x => x.PersonId,
					principalTable: "Persons",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);
			});

		migrationBuilder.CreateTable(
			name: "UserRoles",
			columns: table => new
			{
				Id = table.Column<int>(type: "int", nullable: false)
					.Annotation("SqlServer:Identity", "1, 1"),
				UserId = table.Column<int>(type: "int", nullable: false),
				RoleId = table.Column<int>(type: "int", nullable: false),
				CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
				LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
			},
			constraints: table =>
			{
				table.PrimaryKey("PK_UserRoles", x => x.Id);
				table.ForeignKey(
					name: "FK_UserRoles_Roles_RoleId",
					column: x => x.RoleId,
					principalTable: "Roles",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);
				table.ForeignKey(
					name: "FK_UserRoles_Users_UserId",
					column: x => x.UserId,
					principalTable: "Users",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);
			});

		migrationBuilder.InsertData(
			table: "Persons",
			columns: new[] { "Id", "CreationDate", "Family", "LastUpdated", "Name" },
			values: new object[,]
			{
				{ 1, new DateTime(2022, 6, 8, 22, 25, 32, 391, DateTimeKind.Local).AddTicks(206), "Hoorbakht", new DateTime(2022, 6, 8, 22, 25, 32, 391, DateTimeKind.Local).AddTicks(206), "Mahyar" },
				{ 2, new DateTime(2022, 6, 8, 22, 25, 32, 391, DateTimeKind.Local).AddTicks(208), "Amarlu", new DateTime(2022, 6, 8, 22, 25, 32, 391, DateTimeKind.Local).AddTicks(208), "Arezu" }
			});

		migrationBuilder.InsertData(
			table: "Roles",
			columns: new[] { "Id", "CreationDate", "Description", "LastUpdated", "Title" },
			values: new object[,]
			{
				{ 1, new DateTime(2022, 6, 8, 22, 25, 32, 391, DateTimeKind.Local).AddTicks(137), "Admin of Application", new DateTime(2022, 6, 8, 22, 25, 32, 391, DateTimeKind.Local).AddTicks(137), "Admin" },
				{ 2, new DateTime(2022, 6, 8, 22, 25, 32, 391, DateTimeKind.Local).AddTicks(183), "User of Application", new DateTime(2022, 6, 8, 22, 25, 32, 391, DateTimeKind.Local).AddTicks(183), "User" }
			});

		migrationBuilder.InsertData(
			table: "Users",
			columns: new[] { "Id", "CreationDate", "LastUpdated", "Password", "PersonId", "Username" },
			values: new object[] { 1, new DateTime(2022, 6, 8, 22, 25, 32, 391, DateTimeKind.Local).AddTicks(220), new DateTime(2022, 6, 8, 22, 25, 32, 391, DateTimeKind.Local).AddTicks(220), "c7ad44cbad762a5da0a452f9e854fdc1e0e7a52a38015f23f3eab1d80b931dd472634dfac71cd34ebc35d16ab7fb8a90c81f975113d6c7538dc69dd8de9077ec", 1, "admin" });

		migrationBuilder.InsertData(
			table: "Users",
			columns: new[] { "Id", "CreationDate", "LastUpdated", "Password", "PersonId", "Username" },
			values: new object[] { 2, new DateTime(2022, 6, 8, 22, 25, 32, 391, DateTimeKind.Local).AddTicks(551), new DateTime(2022, 6, 8, 22, 25, 32, 391, DateTimeKind.Local).AddTicks(551), "5dcd58b93f68aea2077c8fdeb74473aa1882ffc7b5a4bf8e73109f92301e93d8502c111388b81bbfeae16dbb740f777ee09cb1fabd88229adb22f8847a181e47", 2, "a.amarlu" });

		migrationBuilder.InsertData(
			table: "UserRoles",
			columns: new[] { "Id", "CreationDate", "LastUpdated", "RoleId", "UserId" },
			values: new object[] { 1, new DateTime(2022, 6, 8, 22, 25, 32, 391, DateTimeKind.Local).AddTicks(604), new DateTime(2022, 6, 8, 22, 25, 32, 391, DateTimeKind.Local).AddTicks(604), 1, 1 });

		migrationBuilder.InsertData(
			table: "UserRoles",
			columns: new[] { "Id", "CreationDate", "LastUpdated", "RoleId", "UserId" },
			values: new object[] { 2, new DateTime(2022, 6, 8, 22, 25, 32, 391, DateTimeKind.Local).AddTicks(608), new DateTime(2022, 6, 8, 22, 25, 32, 391, DateTimeKind.Local).AddTicks(608), 2, 2 });

		migrationBuilder.CreateIndex(
			name: "IX_UserRoles_RoleId",
			table: "UserRoles",
			column: "RoleId");

		migrationBuilder.CreateIndex(
			name: "IX_UserRoles_UserId",
			table: "UserRoles",
			column: "UserId");

		migrationBuilder.CreateIndex(
			name: "IX_Users_PersonId",
			table: "Users",
			column: "PersonId",
			unique: true);
	}

	protected override void Down(MigrationBuilder migrationBuilder)
	{
		migrationBuilder.DropTable(
			name: "UserRoles");

		migrationBuilder.DropTable(
			name: "Roles");

		migrationBuilder.DropTable(
			name: "Users");

		migrationBuilder.DropTable(
			name: "Persons");
	}
}