namespace UnivAssurance.DataAccess.Models;
public class Subscription
{
    public int PersonID {get; set;} 
    public int ProductID {get; set;}
    public int SubscriptionID {get; set;}
    public DateTime SubscriptionDate {get; set;}
    public string SubscriptionState {get; set;} = String.Empty;
    public int ComercialID {get; set;}
    public string SubscriptionTime {get; set;}

     public virtual Commercial Commercial { get; set; }
        public virtual Person Person { get; set; }
        public virtual Product Product { get; set; }
}