using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

class License
{
    private ICollection<Resource> courses;
 
    public License()
    {
        this.courses = new HashSet<Resource>();
    }

    [Key]
    public int LicenseId
    {
        get;
        set;
    }

    public string Name
    {
        get;
        set;
    }

    public virtual ICollection<Resource> Resources
    {
        get
        {
            return this.courses;
        }
        set
        {
            this.courses = value;
        }
    }
}
