namespace PestFree.Models.Common
{
  public class BaseModel
  {
    public int Id { get; set; }
    public int CreateBy { get; set; }
    public DateTime CreateDate { get; set; }
    public int UpdateBy { get; set; }
    public DateTime UpdateDate { get; set; }


  }
}
