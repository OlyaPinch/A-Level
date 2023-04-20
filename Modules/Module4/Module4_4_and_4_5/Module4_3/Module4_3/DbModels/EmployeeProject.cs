
namespace Module4_3.DbModels;

public class EmployeeProject
{
    public int Id { get; set; }
    public double Rate { get; set; }
    public DateTime StartedDate { get; set; }

    public virtual Employee Employee { get; set; }
    public int EmployeeId { get; set; }

    public virtual Project Project { get; set; }
    public int ProjectId { get; set; }


}