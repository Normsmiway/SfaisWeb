using MongoDB.Bson;
using System;
using System.Collections.Generic;
namespace SfaisWeb.Models
{
    public class User
    {
        public ObjectId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Level { get; set; }
        public DateTime DOB { get; set; }
        public string Password { get; set; }
    }

    public class UserService
    {
        public static IEnumerable<User> GetUsers()
        {
            //var list = new List<User>();

            //list.Add(new User { FirstName = "Adeola", LastName = "Kolade", DOB = new DateTime(2001, 1, 18), Email="user@user11.com", Id=1,
            // Level="Begginer", Password="12345", PhoneNumber="08047473545446"});
            //list.Add(new User { Id= 2, FirstName= "Fatimah", LastName= "Omotoso", Email= "email@mine.com", PhoneNumber= "47489488493",
            //    DOB = new DateTime(2001,4, 2), Password = "", Level = "Level 1" });
            //list.Add(new User { Id = 3, FirstName = "Fatimah", LastName = "Omotoso", Email = "email@mine.com", PhoneNumber = "47489488493", DOB = new DateTime(2000,11,2), Password = "", Level = "Level 1" });
            //list.Add(new User { Id = 4, FirstName = "Kim", LastName = "Kardesh", Email = "aiit@now.com", PhoneNumber = "30957854", DOB = new DateTime(1998, 4, 21), Password = "", Level = "Level 1" });

            //list.Add(new User
            //{
            //    Id = 5,
            //    FirstName = "Kola",
            //    LastName = "Iyanda",
            //    Email = "try@this.com",
            //    PhoneNumber = "548455343",
            //    DOB = new DateTime(2000,10,1),
            //    Password = "",
            //    Level = "Level 4"
            //});
            //list.Add(new User { Id = 6, FirstName = "Kudirat", LastName = "Abioola", Email = "quite@now.com", PhoneNumber = "475855373", DOB = new DateTime(1997, 5, 23), Password = "", Level = "Level 4" });
            //list.Add(new User
            //{
            //    Id = 7,
            //    FirstName = "Tunde",
            //    LastName = "Lapa",
            //    Email = "o@mg.com",
            //    PhoneNumber = "0058563533",
            //    DOB = new DateTime(1997,7,21),
            //    Password = "",
            //    Level = "Level 3"
            //});

            //list.Add(new User
            //{
            //    Id = 8,
            //    FirstName = "Ana",
            //    LastName = "Walsh",
            //    Email = "o@kay.com",
            //    PhoneNumber = "4095987489",
            //    DOB = new DateTime(1999, 12, 21),
            //    Password = "",
            //    Level = "Begginer"
            //});
            //list.Add(new User { Id = 9, FirstName = "Kim", LastName = "Kardesh", Email = "aiit@now.com", PhoneNumber = "30957854", DOB = new DateTime(1999, 7, 8), Password = "", Level = "Level 1" });
            //list.Add(new User { Id = 10, FirstName = "Zakky", LastName = "Jim", Email = "co@mon.com", PhoneNumber = "4359-4-9887574", DOB = new DateTime(2001,11,12), Password = "", Level = "Level 2" });
            //list.Add(new User { Id = 11, FirstName = "Tura", LastName = "Lart", Email = "kicker@gmail.com", PhoneNumber = "57594947484", DOB = new DateTime(199, 1, 22), Password = "", Level = "Level 3" });
            //list.Add(new User { Id = 12, FirstName = "Trant", LastName = "Kiwi", Email = "kroo@iiu.com", PhoneNumber = "9087662345", DOB = new DateTime(1997, 8, 8), Password = "", Level = "Level 2" });
            //return list;

            return null;
        }



    }
}