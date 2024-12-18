using DataBaseAppBack;

namespace Model;
public class Lectern
{
    public int id { get; set; }
    public string faculty { get; set; }
    public string manager { get; set; }

    public Lectern(int id, string faculty, string manager)
    {
        this.id = id;
        this.faculty = faculty;
        this.manager = manager;
    }
}
