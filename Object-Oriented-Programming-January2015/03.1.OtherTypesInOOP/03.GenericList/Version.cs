using System;

[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Enum,
    AllowMultiple = false)]
public class Version : System.Attribute
{
    public int Major { get; set; }
    public int Minor { get; set; }

    public string VersionNumber { get; private set; }

    public Version(int major, int minor)
    {
        this.Major = major;
        this.Minor = minor;
        this.VersionNumber = this.Major + "." + this.Minor;
    }
}
