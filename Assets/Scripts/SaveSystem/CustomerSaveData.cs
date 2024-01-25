using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CustomerSaveData : SaveData
{
    public string Number { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Adress { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }

    public CustomerSaveData(string number, string firstName, string lastName, string adress, string street, string city, string state, string zip)
    {
        Number = number;
        FirstName = firstName;
        LastName = lastName;
        Adress = adress;
        Street = street;
        City = city;
        State = state;
        Zip = zip;
    }

}
