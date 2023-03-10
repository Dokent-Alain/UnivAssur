
namespace UnivAssurance.DataAccess.Models
{
public class InitialisationData
    {
        public static void Begin(){

            DataBase.TPCommercial.Add(new Commercial{
                CommercialId = 1,
                nom = "Lou",
                SerialNumber = "n20",
            });
            DataBase.TPCommercial.Add(new Commercial{
                CommercialId = 2,
                nom = "Michele",
                SerialNumber = "n20",
            });
        
            DataBase.TPerson.Add(new Person {
                    PersonID = 1,
                    NumberTypePart = "n02",
                    Name = "John",
                    firstName = "Issac",
                    Phone = 074856712,
                    Sex = "M",
                    MaritalStatus = "Marié",
                    NumberChildren = 1,
                    Employer = "Spvie"
            });
            DataBase.TPerson.Add(new Person {
                    PersonID = 2,
                    NumberTypePart = "n03",
                    Name = "Mozart",
                    firstName = "Kiang",
                    Phone = 074856712,
                    Sex = "M",
                    MaritalStatus = "Marié",
                    NumberChildren = 3,
                    Employer = "Spvie"
            });
            DataBase.TPerson.Add(new Person {
                    PersonID = 3,
                    NumberTypePart = "n04",
                    Name = "MBALI",
                    firstName = "Aube",
                    Phone = 074856712,
                    Sex = "M",
                    MaritalStatus = "Celibataire",
                    NumberChildren = 0,
                    Employer = "Spvie"
            });

            DataBase.TProduct.Add(new Product {
                ProductId = 1,
                ProductName = "Assurance vie",
                price = 1000,
                CampaignStartDate = "2023-01-20",
                CampaignEndDate = "2023-03-20",
            });
            DataBase.TProduct.Add(new Product {
                ProductId = 2,
                ProductName = "Assurance décès",
                price = 2000,
                CampaignStartDate = "2023-03-02",
                CampaignEndDate = "2023-04-05",
            });
            DataBase.TProduct.Add(new Product {
                ProductId = 3,
                ProductName = "Assurance mixte (vie et décès)",
                price = 5000,
                CampaignStartDate = "2023-03-02",
                CampaignEndDate = "2023-04-05",
            });
        
            DataBase.TSouscription.Add(new Subscription{
                SubscriptionID = 1,
                PersonID = 1,
                ProductID = 1,
                SubscriptionDate = new DateTime().ToLocalTime(),
                SubscriptionState = "2023-02-20",
                ComercialID = 1,
                SubscriptionTime = "2ans"
            });
            DataBase.TSouscription.Add(new Subscription{
                SubscriptionID = 1,
                PersonID = 2,
                ProductID = 1,
                SubscriptionDate = new DateTime().ToLocalTime(),
                SubscriptionState = "2023-02-20",
                ComercialID = 1,
                SubscriptionTime = "2ans"
            });
            DataBase.TSouscription.Add(new Subscription{
                SubscriptionID = 1,
                PersonID = 3,
                ProductID = 1,
                SubscriptionDate = new DateTime().ToLocalTime(),
                SubscriptionState = "2023-02-20",
                ComercialID = 1,
                SubscriptionTime = "2ans"
            });
            DataBase.TSouscription.Add(new Subscription{
                SubscriptionID = 1,
                PersonID = 2,
                ProductID = 2,
                SubscriptionDate = new DateTime().ToLocalTime(),
                SubscriptionState = "2023-02-20",
                ComercialID = 1,
                SubscriptionTime = "2ans"
            });
            DataBase.TSouscription.Add(new Subscription{
                SubscriptionID = 1,
                PersonID = 3,
                ProductID = 1,
                SubscriptionDate = new DateTime().ToLocalTime(),
                SubscriptionState = "2023-02-20",
                ComercialID = 1,
                SubscriptionTime = "2ans"
            });
        }
    }
}