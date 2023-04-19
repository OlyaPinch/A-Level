namespace Module4_3.DbModels;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Budget { get; set; }
    public DateTime StartedDate { get; set; }
    public virtual List<EmployeeProject> EmployeeProject { get; set; }=new List<EmployeeProject>();
    public virtual Client Client { get; set; }
    public int ClientId { get; set; }
}