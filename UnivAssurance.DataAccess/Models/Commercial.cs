
namespace UnivAssurance.DataAccess.Models
{
    public class Commercial
    {
        public  int CommercialId { get; set; }
        public string nom { get; set; }
        public string SerialNumber { get;set; }
     public virtual ICollection<Subscription> Subscription { get; set; }
    }
}