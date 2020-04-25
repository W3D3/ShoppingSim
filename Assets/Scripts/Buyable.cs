using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Buyable : MonoBehaviour
{
    public Customer reservedFor = null;

    public bool bought = false;

    public bool Reserved => reservedFor != null;

    public bool Bought => bought;

    public bool Buy(Customer customer)
    {
        if (reservedFor == customer)
        {
            return bought = true;
        }

        return false;
    }
    
    public bool Reserve(Customer customer)
    {
        if (Reserved) return false;
        reservedFor = customer;
        return true;
    }
}
