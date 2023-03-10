namespace UnivAssurance.DataAccess.Models;
public class Person
    {
        public int PersonID { get; set; } 
        public string NumberTypePart  { get; set; } = string.Empty;
        public string Name  { get; set; } = string.Empty;
        public string firstName { get; set; }   = string.Empty;
        public int Phone { get; set; } 
        public string Sex { get; set; } = string.Empty;
        public string MaritalStatus { get; set; } = string.Empty;
        public int NumberChildren { get; set; } 
        public string Employer { get; set; } = string.Empty;

        public virtual Subscription Subscription { get; set; }
        
    }
