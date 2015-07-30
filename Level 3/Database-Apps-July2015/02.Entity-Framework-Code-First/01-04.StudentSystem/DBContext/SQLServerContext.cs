using System.Data.Entity;

class SQLServerContext : DbContext
{
    public SQLServerContext()
        : base("SQLServer")
    {
    }

    public DbSet<Course> Courses
    {
        get;
        set;
    }

    public DbSet<Homework> Homeworks
    {
        get;
        set;
    }

    public DbSet<Resource> Resources
    {
        get;
        set;
    }

    public DbSet<Student> Students
    {
        get;
        set;
    }

    public DbSet<License> Licenses
    {
        get;
        set;
    }
}
