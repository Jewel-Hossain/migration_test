using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace migration_test.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE TABLE IF NOT EXISTS Parts (
                    Time timestamp NOT NULL,
                    BranchId INTEGER NOT NULL
                ) PARTITION BY RANGE(time);
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP TABLE IF EXISTS Parts;");
        }
    }
}
