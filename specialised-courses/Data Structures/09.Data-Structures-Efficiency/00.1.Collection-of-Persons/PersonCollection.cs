using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class PersonCollection : IPersonCollection
{
    private Dictionary<string, Person> peopleByEmail;
    private Dictionary<string, SortedSet<Person>> peopleByEmailDomain;
    private Dictionary<string, SortedSet<Person>> peopleByNameAndTown;
    private OrderedDictionary<int, SortedSet<Person>> peopleByAge;
    private OrderedDictionary<int, Dictionary<string, SortedSet<Person>>> peopleByAgeAndTown; 

    public PersonCollection()
    {
        this.peopleByEmail = new Dictionary<string, Person>();
        this.peopleByEmailDomain = new Dictionary<string, SortedSet<Person>>();
        this.peopleByNameAndTown = new Dictionary<string, SortedSet<Person>>();
        this.peopleByAge = new OrderedDictionary<int, SortedSet<Person>>();
        this.peopleByAgeAndTown =
            new OrderedDictionary<int, Dictionary<string, SortedSet<Person>>>();
    }

    public bool AddPerson(string email, string name, int age, string town)
    {
        /*
         * •	Add-Person(email, name, age, town)
            o	The email is unique (it uniquely identities the person)
            o	If the email already exists returns false (without adding the person), otherwise return true
         */

        bool personExists = peopleByEmail.ContainsKey(email);

        if (personExists)
        {
            return false;
        }
        else
        {
            var person = new Person()
            {
                Name = name,
                Age = age,
                Email = email,
                Town = town
            };

            // People by Email
            peopleByEmail[email] = person;

            // People by Email Domain
            string emailDomain = GetEmailDomain(email);

            if (peopleByEmailDomain.ContainsKey(emailDomain))
            {
                peopleByEmailDomain[emailDomain].Add(person);
            }
            else
            {
                peopleByEmailDomain[emailDomain] = new SortedSet<Person>();
                peopleByEmailDomain[emailDomain].Add(person);
            }
            

            // People by Name and Town
            string nameTownKey = GetNameTownKey(name, town);

            if (peopleByNameAndTown.ContainsKey(nameTownKey))
            {
                peopleByNameAndTown[nameTownKey].Add(person);
            }
            else
            {
                peopleByNameAndTown[nameTownKey] = new SortedSet<Person>();
                peopleByNameAndTown[nameTownKey].Add(person);
            }
            
            // People by Age
            if (peopleByAge.ContainsKey(person.Age))
            {
                peopleByAge[person.Age].Add(person);
            }
            else
            {
                peopleByAge[person.Age] = new SortedSet<Person>();
                peopleByAge[person.Age].Add(person);
            }

            // People by Age and Town
            if (!peopleByAgeAndTown.ContainsKey(person.Age))
            {
                peopleByAgeAndTown.Add(
                    person.Age, 
                    new Dictionary<string, SortedSet<Person>>());
            }

            var dictionary = peopleByAgeAndTown[person.Age];
            if (!dictionary.ContainsKey(person.Town))
            {
                dictionary[person.Town] = new SortedSet<Person>();
            }

            dictionary[person.Town].Add(person);

            return true;
        }
    }

    public int Count
    {
        get { return this.peopleByEmail.Count; }
    }

    public Person FindPerson(string email)
    {
        /*
         * •	Find-Person(email)
            o	Returns the Person object or null (if it does not exits)
         */

        if (peopleByEmail.ContainsKey(email))
        {
            return peopleByEmail[email];
        }
        else
        {
            return null;
        }
    }

    public bool DeletePerson(string email)
    {
        /*
         * •	Delete-Person(email)
            o	Returns true (successfully deleted) or false (not found)
         */

        if (this.peopleByEmail.ContainsKey(email))
        {
            var person = this.peopleByEmail[email];

            // People by Email
            this.peopleByEmail.Remove(email);

            // People by Age
            this.peopleByAge[person.Age].Remove(person);

            if (this.peopleByAge[person.Age].Count == 0)
            {
                this.peopleByAge.Remove(person.Age);
            }

            // People by Email domain
            string emailDomain = this.GetEmailDomain(person.Email);

            this.peopleByEmailDomain[emailDomain].Remove(person);

            if (this.peopleByEmailDomain[emailDomain].Count == 0)
            {
                this.peopleByEmailDomain.Remove(emailDomain);
            }

            // People by Name and Town
            string nameTownKey = this.GetNameTownKey(person.Name, person.Town);

            this.peopleByNameAndTown[nameTownKey].Remove(person);

            if (this.peopleByNameAndTown[nameTownKey].Count == 0)
            {
                this.peopleByNameAndTown.Remove(nameTownKey);
            }

            // People by Age and Town
            var dictionary = this.peopleByAgeAndTown[person.Age];
            var sortedSet = dictionary[person.Town];
            sortedSet.Remove(person);
            if (sortedSet.Count == 0)
            {
                dictionary.Remove(person.Town);
                if (this.peopleByAgeAndTown[person.Age].Count == 0)
                {
                    this.peopleByAgeAndTown.Remove(person.Age);
                }
            }

            return true;
        }
        else
        {
            return false;
        }
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        /*
         * •	Find-People(email_domain)
            o	Returns a sequence of matched persons sorted by email
         */

        if (peopleByEmailDomain.ContainsKey(emailDomain))
        {
            return peopleByEmailDomain[emailDomain];
        }
        else
        {
            return Enumerable.Empty<Person>();
        }
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        /*
         * •	Find-People(name, town)
            o	Returns a sequence of matched persons sorted by email
         */

        string nameTownKey = this.GetNameTownKey(name, town);

        if (this.peopleByNameAndTown.ContainsKey(nameTownKey))
        {
            return this.peopleByNameAndTown[nameTownKey];
        }
        else
        {
            return Enumerable.Empty<Person>();
        }
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        /*
         * •	Find-People(start_age, end_age)
            o	Returns a sequence of matched persons sorted by age, then by email (as second criteria)
         */

        var personsInRange = 
            this.peopleByAge.Range(startAge, true, endAge, true).Values;

        foreach (var personRange in personsInRange)
        {
            foreach (var person in personRange)
            {
                yield return person;
            }
        }
    }

    public IEnumerable<Person> FindPersons(
        int startAge, int endAge, string town)
    {
        /*
         * •	Find-People(start_age, end_age, town)
            o	Returns a sequence of matched persons sorted by age, then by email (as second criteria)
         */

        var personsRange = 
            this.peopleByAgeAndTown.Range(startAge, true, endAge, true);

        foreach (var personRange in personsRange)
        {
            var dictionary = personRange.Value;
            if (dictionary.ContainsKey(town))
            {
                foreach (var person in dictionary[town])
                {
                    yield return person;
                }
            }
        }

        
    }

    private string GetEmailDomain(string email)
    {
        return email.Split('@')[1];
    }

    private string GetNameTownKey(string name, string town)
    {
        return name + "|" + town;
    }
}
