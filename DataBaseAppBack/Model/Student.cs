using DataBaseAppBack;

namespace Model;
public class Student
{
    public int id { get; set; }
    public string surname { get; set; }
    public int related_group { get; set; }
    public int join_year { get; set; }
    public int rating { get; set; }

    public Student(int id, string surname, int related_group, int join_year, int rating)
    {
        this.id = id;
        this.surname = surname;
        this.related_group = related_group;
        this.join_year = join_year;
        this.rating = rating;
    }
}