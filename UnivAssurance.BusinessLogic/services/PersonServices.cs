using UnivAssurance.DataAccess.Models;
using UnivAssurance.DataAccess.Data;
namespace UnivAssurance.BusinessLogic.services;

public class PersonServices
{

    private SouscriptionDbContext _Context;
    public PersonServices(SouscriptionDbContext Context)
    {
        InitialisationData.Begin();
        this._Context = Context;
    }


    public List<Person> GetAllPerson() => this._Context.Person.ToList();

    public Person? GetPersonById(int Id) => this._Context.Person.FirstOrDefault(p => p.PersonID == Id);


    public List<Person> CreatePerson(Person person)
    {
        this._Context.Person.Add(person);
        return this._Context.Person.ToList(); 
    }

    public List<Person> DeletePerson(int ID)
    {
        Person? P = GetPersonById(ID);
        //var p = this._Context.Person.Where(p => p.ID == ID).FirstOrDefault();

        if (P != null)
        {
           this._Context.Person.RemoveRange(P);
           this._Context.SaveChanges();
        }
        return this._Context.Person.ToList();
    }

    //public List<Person> UpdatePerson(int ID)
    //{
        //Person? p = GetPersonById(ID);
        //if(p!= null){
            //var R = this._Context.Update(p);
                //if(R != null)
                    //{
                        //this._Context.SaveChanges();
                    //}
        //} 
        //return this._Context.Person.ToList();
        
    //}

    public Person UpdatePerson( Person person)
        {
            Person personfind=_Context.Update<Person>(person).Entity;
            this._Context.SaveChanges();
            return personfind;
          
        }
}