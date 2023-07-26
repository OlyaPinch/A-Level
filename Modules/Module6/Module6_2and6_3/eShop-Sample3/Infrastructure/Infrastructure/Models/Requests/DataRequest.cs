using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models.Requests;

public class DataRequest<T>
{
    [Required] 
    public T Data { get; set; }
}