namespace UnivAssurance.DataAccess.Models;
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName {get; set;}
        public int price { get; set; }

        public string CampaignStartDate { get; set; }

        public string CampaignEndDate { get; set; }

         public virtual ICollection<Subscription> Subscription { get; set; }
    }
