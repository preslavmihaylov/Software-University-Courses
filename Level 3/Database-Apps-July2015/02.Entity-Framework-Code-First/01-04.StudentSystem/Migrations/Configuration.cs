
using System;
using System.Data.Entity.Migrations;

internal sealed class Configuration : DbMigrationsConfiguration<SQLServerContext>
{
    public Configuration()
    {
        this.AutomaticMigrationsEnabled = true;
        this.AutomaticMigrationDataLossAllowed = true;
    }

    protected override void Seed(SQLServerContext context)
    {
    }
}
