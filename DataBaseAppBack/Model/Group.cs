using DataBaseAppBack;

namespace Model;
public class Group
{
    public int id { get; set; }
    public string code { get; set; }
    public int lectern_id { get; set; }
    public int speciality_id { get; set; }

    public Group(int id, string code, int lectern_id, int speciality_id)
    {
        this.id = id;
        this.code = code;
        this.lectern_id = lectern_id;
        this.speciality_id = speciality_id;
    }
}