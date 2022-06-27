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
            ps.Create(new Person { Age = new Random().Next(1, 99), LastName = ps.LastNamesGen()[new Random().Next(1, 88500)], FirstName = ps.NamesGen()[new Random().Next(1, 18000)] });
            ps.Create(new Person { Age = new Random().Next(1, 99), LastName = ps.LastNamesGen()[new Random().Next(1, 88500)], FirstName = ps.NamesGen()[new Random().Next(1, 18000)] });
            ps.Create(new Person { Age = new Random().Next(1, 99), LastName = ps.LastNamesGen()[new Random().Next(1, 88500)], FirstName = ps.NamesGen()[new Random().Next(1, 18000)] });
            ps.Create(new Person { Age = new Random().Next(1, 99), LastName = ps.LastNamesGen()[new Random().Next(1, 88500)], FirstName = ps.NamesGen()[new Random().Next(1, 18000)] });
            var peoples= ps.ConvertToPerson(ps.Read());
            ps.Print(peoples);
        }
    }



}
