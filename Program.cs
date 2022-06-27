using System;
using System.Collections.Generic;
using System.IO;

namespace LoadFromFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PersonService ps = new PersonService();
            List<Person> people = new List<Person>();
            ps.Create(new Person { Age = new Random().Next(1,99), LastName = "Poghosyan", FirstName = "Poghos" });
            ps.Create(new Person { Age = new Random().Next(1, 99), LastName = "Petrosyan", FirstName = "Petros" });
            ps.Create(new Person { Age = new Random().Next(1, 99), LastName = "Martirosyan", FirstName = "Martisros" });
            ps.Create(new Person { Age = new Random().Next(1, 99), LastName = "Khachikyan", FirstName = "Khachik" });
          var peoples= ps.ConvertToPerson(ps.Read());
            ps.Print(peoples);
        }
    }



}
