using AspnetCoreMvcFull.Models.Common;

namespace AspnetCoreMvcFull.Models
{
  public class Company : BaseModel
  {
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public bool IsActive { get; set; }
    
  }
}
