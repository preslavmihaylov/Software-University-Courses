using System;
using System.Collections.Generic;
using System.Linq;

public class PersonCollectionSlow : IPersonCollection
{
    private List<Person> people;

    public PersonCollectionSlow()
    {
        this.people = new List<Person>();
    }

    public bool AddPerson(string email, string name, int age, string town)
    {
        /*
         * •	Add-Person(email, name, age, town)
            o	The email is unique (it uniquely identities the person)
            o	If the email already exists returns false (without adding the person), otherwise return true
         */

        var person = this.people.FirstOrDefault(p => p.Email == email);

        if (person != null)
        {
            return false;
        }
        else
        {
            this.people.Add(new Person()
            {
                Name = name,
                Email = email,
                Age = age,
                Town = town
            });

            return true;
        }
    }

    public int Count
    {
        get { return this.people.Count; }
    }

    public Person FindPerson(string email)
    {
        /*
         * •	Find-Person(email)
            o	Returns the Person object or null (if it does not exits)
         */

        return this.people.FirstOrDefault(p => p.Email == email);
    }

    public bool DeletePerson(string email)
    {
        /*
         * •	Delete-Person(email)
            o	Returns true (successfully deleted) or false (not found)
         */

        var person = this.people.FirstOrDefault(p => p.Email == email);

        if (person == null)
        {
            return false;
        }
        else
        {
            this.people.Remove(person);
            return true;
        }
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        /*
         * •	Find-People(email_domain)
            o	Returns a sequence of matched persons sorted by email
         */

        return this.people
            .Where(p => p.Email.EndsWith("@" + emailDomain))
            .OrderBy(p => p.Email)
            .AsEnumerable();
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        /*
         * •	Find-People(name, town)
            o	Returns a sequence of matched persons sorted by email
         */

        return this.people
            .Where(p => p.Name == name && p.Town == town)
            .OrderBy(p => p.Email)
            .AsEnumerable();
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        /*
         * •	Find-People(start_age, end_age)
            o	Returns a sequence of matched persons sorted by age, then by email (as second criteria)
         */

        return this.people
            .Where(p => p.Age >= startAge && p.Age <= endAge)
            .OrderBy(p => p.Age)
            .ThenBy(p => p.Email)
            .AsEnumerable();
    }

    public IEnumerable<Person> FindPersons(
        int startAge, int endAge, string town)
    {
        /*
         * •	Find-People(start_age, end_age, town)
            o	Returns a sequence of matched persons sorted by age, then by email (as second criteria)
         */

        return this.people
            .Where(p => p.Age >= startAge && p.Age <= endAge && p.Town == town)
            .OrderBy(p => p.Age)
            .ThenBy(p => p.Email)
            .AsEnumerable();
    }
}
