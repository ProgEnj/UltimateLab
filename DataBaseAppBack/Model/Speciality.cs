using DataBaseAppBack;

namespace Model;
public class Speciality
{
    public int id { get; set; }

    public int code {get; set;}
    public string name { get; set; }
    public string field { get; set; }

    public Speciality(int id, int code, string name, string field)
    {
        this.id = id;
        this.name = name;
        this.field = field;
        this.code = code;
    }
}