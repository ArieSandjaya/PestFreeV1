namespace PestFree.Models.Common
{
  public class BaseModel
  {
    public int Id { get; set; }
    public int CreateBy { get; set; } = 0;
    public DateTime CreateDate { get; set; } = DateTime.Now;
    public int UpdateBy { get; set; }
    public DateTime UpdateDate { get; set; }


  }
}
