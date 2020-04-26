using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Checkout : MonoBehaviour
{
    private int _cash;

    public List<Transform> queuePositions;

    private Queue<Customer> _customerQueue;
    
    // Start is called before the first frame update
    void Start()
    {
        _customerQueue = new Queue<Customer>();
        _cash = GameManager.currentMoney;
    }

    public int Cash => _cash;

    // Registers the customer and tells him where to go
    public Transform Register(Customer customer)
    {
        _customerQueue.Enqueue(customer);
       
        if (_customerQueue.Count > queuePositions.Count)
        {
            // when no position is available, let him stand there.
            return null;
        }
        else
        {
            // order him there
            return queuePositions[_customerQueue.Count - 1];
        }
    }
    
    
    public void PayAndAdvanceQueue()
    {
        // Emulate the customer paying for 5 seconds
        StartCoroutine(AdvanceQueue(2));
    }

    IEnumerator AdvanceQueue(int secondsToWait)
    {
        
        var currentCustomer = _customerQueue.Dequeue();
        Pay(currentCustomer.Cart);
        yield return new WaitForSeconds(secondsToWait);
        int i = 0;
        foreach (var customer in _customerQueue)
        {
            customer.OrderToPosition(queuePositions[i]);
            Debug.Log("Ordererd " + customer + " to " + queuePositions[i]);
        }
    }

    public void Pay(List<Item> items)
    {
        foreach (var item in items)
        {
            // TODO fix after Veit changes price to int
            _cash += item.price;
        }

        GameManager.currentMoney = _cash;
        Debug.Log("New cash after paying: " + _cash);
    }
}
