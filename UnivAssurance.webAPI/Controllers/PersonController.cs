using Microsoft.AspNetCore.Mvc;
using UnivAssurance.webAPI.Logging;
using UnivAssurance.DataAccess.Data;
using UnivAssurance.BusinessLogic.services;
using UnivAssurance.DataAccess.Models;
using Microsoft.AspNetCore.Authorization;

namespace UnivAssurance.webAPI.Controllers
{   
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class PersonController: ControllerBase
    {   
        private PersonServices Ps;
        private Ilog not_log;
        private SouscriptionDbContext _ctx;
        public PersonController(Ilog logger,SouscriptionDbContext _ctx)
        {
               this.not_log = logger;
               this._ctx = _ctx;
               this.Ps = new PersonServices(this._ctx);
        }
       
     //   public string Get(){
     //     return "Hello world"; 
     //   }
        [HttpGet]
        [AllowAnonymous]
        [Route("PersonList")]
       public List<Person> Get2(){
          this.not_log.Information("bonjour");
        return this.Ps.GetAllPerson();
       }

         ///<summary>
         /// Recuperation de données
          ///</summary>
         [HttpPost]
       [Route("addPerson")]
       public object  addPerson([FromBody] object param )
       {
            return string.Format("Hello Kitty");
       }
       
          ///<summary>
         /// Recuperation de données
          ///</summary>
       
          
       [HttpPut]
        [Route("update person")]
        public Person UpdatePerson(Person person)
        {
            return UpdatePerson(person);
        }

       ///<summary>
         /// Recuperation de données
          ///</summary>

      // [HttpDelete]
       //[Route("AvecParam/{id}")]

       //public List<Person> Exoc(int id, [FromQuery]string? param = "12")
       //{
            //return this.Ps.DeletePerson();
       //}

    }

}