using System;
using System.Linq;
using UnivAssurance.DataAccess.Data;
using UnivAssurance.BusinessLogic.services;
namespace UnivAssurance.Datalogic.tests
{
    public class TestPerson
{
    private PersonServices _personService;

    private SouscriptionDbContext _souscriptionDbContext;
    
    [SetUp]
    public void Setup()
    {
        this._souscriptionDbContext = new SouscriptionDbContext();
        this._personService = new PersonServices( this._souscriptionDbContext);
    }

    [Test]
    public void _TestPerson()
    {
        var Ps = this._personService.GetAllPerson();
        Assert.IsNotNull(Ps);
    }
}
}