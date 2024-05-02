using MySQLConn;
using SQLConn;
using Model;
using Microsoft.EntityFrameworkCore;

using var mdb = new MySQLConn.DBContext();
using var sdb = new SQLConn.DBContext();

var mEntities = mdb.entities.Include(e => e.City).ToList();
var sEntities = sdb.entities.Include(e => e.City).ToList();

foreach (var entity in mEntities)
{
    if (!sEntities.Contains(entity))
    {
        sdb.Add(new Person() { City = new City() { CityName = entity.City.CityName, PostalCode = entity.City.PostalCode }, FirstName = entity.FirstName, Jobtitle = entity.Jobtitle, LastName = entity.LastName });
    }
}
sdb.SaveChanges();


//var person1 = new Person() { City = new City() { CityName = "Silkeborg", PostalCode = 8600 }, FirstName = "person1", Jobtitle = "Student", LastName = "Askaa" };
//var person2 = new Person() { City = new City() { CityName = "Silkeborg", PostalCode = 8600 }, FirstName = "person2", Jobtitle = "Student", LastName = "Askaa" };
//var person3 = new Person() { City = new City() { CityName = "Silkeborg", PostalCode = 8600 }, FirstName = "person3", Jobtitle = "Student", LastName = "Askaa" };
//var person4 = new Person() { City = new City() { CityName = "Silkeborg", PostalCode = 8600 }, FirstName = "person4", Jobtitle = "Student", LastName = "Askaa" };
//var person5 = new Person() { City = new City() { CityName = "Silkeborg", PostalCode = 8600 }, FirstName = "person5", Jobtitle = "Student", LastName = "Askaa" };


//var people = new List<Person>();
//people.Add(person1);
//people.Add(person2);
//people.Add(person3);
//people.Add(person4);
//people.Add(person5);

//mdb.AddRange(people);
//mdb.SaveChanges();

