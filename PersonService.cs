using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadFromFile
{

    public class PersonService
    {
        private readonly string path = @"persons";
        private readonly string Fnames = @"persons";
        private readonly string Lnames = @"persons";
        public PersonService()
        {
            path = Path.Combine(path, "persons.txt");
            Fnames = Path.Combine(Fnames, "FirstNames.txt");
            Lnames = Path.Combine(Lnames, "LastNames.txt");
        }
        public void Create(Person person)
        {
            string[] personstr = new string[4];
            personstr[0] = person.Id.ToString() + "\n";
            personstr[1] = person.FirstName + "\n";
            personstr[2] = person.LastName + "\n";
            personstr[3] = person.Age.ToString() + "\n";

            using (FileStream fstream = new FileStream(path, FileMode.Append))
            {
                for (int i = 0; i < personstr.Length; i++)
                {
                    byte[] buffer = Encoding.Default.GetBytes(personstr[i]);
                    fstream.Write(buffer, 0, buffer.Length);
                }
            }
        }
        public List<Person> ConvertToPerson(string[] persons)
        {
            List<Person> people = new List<Person>();
            for (int i = 0; i < persons.Length; i = i + 4)
            {
                try
                {
                    people.Add(new Person()
                    {
                        Id = Guid.Parse(persons[i]),
                        Age = Convert.ToInt16(persons[i + 3]),
                        LastName = persons[i + 2],
                        FirstName = persons[i + 1]
                    });
                }
                catch
                {
                }
            }
            return people;
        }
        public string[] Read()
        {
            string[] persons;
            using (FileStream fstream = File.OpenRead(path))
            {
                byte[] buffer = new byte[fstream.Length];
                fstream.Read(buffer, 0, buffer.Length);
                string textFromFile = Encoding.Default.GetString(buffer);
                fstream.Seek(-1, SeekOrigin.End);
                persons = textFromFile.Split("\n");
            }
            return persons;
        }
        public string[] NamesGen()
        {
            string[] persons;
            persons = File.ReadAllLines(Fnames);
            return persons;
        }
        public string[] LastNamesGen()
        {
            string[] persons;
            persons = File.ReadAllLines(Lnames);
            return persons;
        }

        public void Print(List<Person> people)
        {
            foreach (var person in people)
            {
                Console.WriteLine($"ID: {person.Id.ToString()}\n" +
                    $"AGE: {person.Age}\n" +
                    $"LAST NAME: {person.LastName}\n" +
                    $"FIRST NAME: {person.FirstName}\n" +
                    $"{new string('_', 30)}");
            }
        }

    }
}
