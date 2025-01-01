using PestFree.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace PestFree.Models
{
  public class Company : BaseModel
  {
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    public string Phone { get; set; }

    public bool IsActive { get; set; }

    public byte[]? Icon {  get; set; } 
    
  }
}
