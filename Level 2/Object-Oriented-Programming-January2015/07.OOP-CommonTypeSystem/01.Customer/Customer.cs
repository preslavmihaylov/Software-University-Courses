using System;
using System.Collections.Generic;

class Customer : ICloneable, IComparable<Customer>
{
    public Customer() : this("", "", "", "", "", "", "", new List<Payment>(), CustomerType.Regular)
    {
    }

    public Customer(string firstName, string middleName,
                    string lastName, string id, string address,
                    string mobilePhone, string email, List<Payment> payments, CustomerType type)
    {
        this.FirstName = firstName;
        this.MiddleName = middleName;
        this.LastName = lastName;
        this.ID = id;
        this.Address = address;
        this.MobilePhone = mobilePhone;
        this.Email = email;
        this.Payments = payments;
        this.Type = type;
    }

    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string ID { get; set; }
    public string Address { get; set; }
    public string MobilePhone { get; set; }
    public string Email { get; set; }
    public List<Payment> Payments { get; set; }
    public CustomerType Type { get; set; }

    public static bool operator ==(Customer cust1, Customer cust2)
    {
        return cust1.Equals(cust2);
    }

    public static bool operator !=(Customer cust1, Customer cust2)
    {
        return !cust1.Equals(cust2);
    }

    public override int GetHashCode()
    {
        return this.FirstName.GetHashCode() ^ this.LastName.GetHashCode() ^
               this.MiddleName.GetHashCode() ^ this.ID.GetHashCode() ^
               this.Address.GetHashCode() ^ this.MobilePhone.GetHashCode() ^
               this.Email.GetHashCode() ^ this.Payments.GetHashCode() ^ this.Type.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        if (!(obj is Customer))
        {
            return false;
        }

        Customer customer = (Customer)obj;

        if (this.FirstName == customer.FirstName &&
            this.MiddleName == customer.MiddleName &&
            this.LastName == customer.LastName &&
            this.ID == customer.ID &&
            this.Address == customer.Address &&
            this.MobilePhone == customer.MobilePhone &&
            this.Email == customer.Email &&
            this.Type == customer.Type)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public object Clone()
    {
        Customer customer = new Customer();

        customer.FirstName = this.FirstName;
        customer.MiddleName = this.MiddleName;
        customer.LastName = this.LastName;
        customer.ID = this.ID;
        customer.Address = this.Address;
        customer.MobilePhone = this.MobilePhone;
        customer.Email = this.Email;
        customer.Payments = new List<Payment>();
        foreach (var payment in this.Payments)
        {
            customer.Payments.Add((Payment)payment.Clone());
        }
        customer.Type = this.Type;

        return customer;
    }

    public int CompareTo(Customer other)
    {
        if (this.FirstName.CompareTo(other.FirstName) != 0)
        {
            return this.FirstName.CompareTo(other.FirstName);
        }
        else if (this.MiddleName.CompareTo(other.MiddleName) != 0)
        {
            return this.MiddleName.CompareTo(other.MiddleName);
        }
        else if (this.LastName.CompareTo(other.LastName) != 0)
        {
            return this.LastName.CompareTo(other.LastName);
        }
        else
        {
            return this.ID.CompareTo(other.ID);
        }
    }
}