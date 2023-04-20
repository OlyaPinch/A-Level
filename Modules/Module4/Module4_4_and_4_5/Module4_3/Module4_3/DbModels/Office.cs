

namespace Module4_3.DbModels;

public class Office
{
    public int Id { get; set; }
    public string Title { get; set; }

    public string Location { get; set; }
    public virtual List<Employee> Employees { get; set; } = new List<Employee>();
 
}