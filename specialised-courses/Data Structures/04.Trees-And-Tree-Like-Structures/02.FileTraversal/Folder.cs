using System.Collections.Generic;

class Folder
{
    private long? size;

    public Folder(string name)
    {
        this.Name = name;
        this.Folders = new List<Folder>();
        this.Files = new List<File>();
    }

    public string Name
    {
        get;
        set;
    }

    public List<Folder> Folders
    {
        get;
        set;
    }

    public List<File> Files
    {
        get;
        set;
    }

    public long? Size
    {
        get
        {
            if (this.size != null)
            {
                return this.size;
            }
            else
            {
                this.size = 0;
                foreach (var folder in this.Folders)
                {
                    this.size += folder.Size;
                }

                foreach (var file in this.Files)
                {
                    this.size += file.Size;
                }

                return this.size;   
            }
        }
    }
}