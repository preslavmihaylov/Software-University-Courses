using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

class Resource
{
    // •	Resources: id, name, type of resource (video / presentation / document / other), URL

    public int ResourceId
    {
        get;
        set;
    }

    [Required]
    public string Name
    {
        get;
        set;
    }

    [Required]
    public ResourceType ResourceType
    {
        get;
        set;
    }

    [Required]
    public string URL
    {
        get;
        set;
    }

    public int CourseId
    {
        get;
        set;
    }

    public virtual Course Course
    {
        get;
        set;
    }

    public int? LicenseId
    {
        get;
        set;
    }

    public virtual License License
    {
        get;
        set;
    }
}