using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Customer : MonoBehaviour
{
    public ShoppingList shoppingList;
    public Checkout checkout;
    public Transform exit;
    
    private NavMeshAgent _agent;
    private Transform _goal;
    private Item _currentItem;
    private Queue<Item> _itemQueue;
    private List<Transform> _reached;
    private List<Item> _cart;
    private Queue<Transform> _afterShoppingQueue;
    private Animator _animator;
    
    private UnityEvent _notFoundEvent;

    public List<Item> Cart => _cart;

    private const string RUNNING_ANIM = "Running";

    void Start () {
        _agent = GetComponent<NavMeshAgent>();
        if (_agent == null)
        {
            Debug.LogError("[" + name + "] has no NavMeshAgent attached!");
        }
        
        _cart = new List<Item>();
        _reached = new List<Transform>();
        _itemQueue = new Queue<Item>(shoppingList.itemList);
        _animator = GetComponent<Animator>();

        _notFoundEvent = new UnityEvent();

        _goal = SelectNextDestination(false);

        // use y of own transform so height is not an issue
        var goalPosition = _goal.position;
        _agent.destination = new Vector3(goalPosition.x, GetComponent<Transform>().position.y, goalPosition.z);
        _agent.autoBraking = true;
        _animator.SetBool(RUNNING_ANIM, true);
    }

    Transform SelectNextDestination(bool tryAgain)
    {
        Transform target = null;
        // search for our items first
        while (target == null && _itemQueue.Count > 0)
        {
            if(!tryAgain) _currentItem = _itemQueue.Dequeue();
            target = FindNextGoalForItem(_currentItem);
        }

        if (target != null)
        {
            var buyable = target.GetComponent<Buyable>();
            buyable.Reserve(this);
            return target;
        }
        // afterwards go through our remaining goals
        if (_itemQueue.Count == 0)
        {
            return checkout.Register(this);
        }

        return null;

    }

    Transform FindNextGoalForItem(Item item)
    {
        float minDist = Single.PositiveInfinity;
        Transform minTranform = null;
        foreach (var levelItem in GameObject.FindGameObjectsWithTag("Item"))
        {
            if (levelItem.name.StartsWith(item.name))
            {
                if (!_reached.Contains(levelItem.transform))
                {
                    var difference = transform.position - levelItem.transform.position;
                    var buyable = levelItem.GetComponent<Buyable>();
                    if (difference.magnitude < minDist && buyable.Reserved == false)
                    {
                        minDist = difference.magnitude;
                        minTranform = levelItem.transform;
                    }
                }
            }
        }

        if (minTranform == null)
        {
            // no item found
            // TODO Frustrate customer when no element can be found?
            Debug.Log("[" + name + "] Cannot find a proper item to pick up for " + item.name);
            _notFoundEvent.Invoke();
        }

        return minTranform;
    }

    private void FixedUpdate()
    {
        _animator.SetFloat("Speed", _agent.speed / 3);
        if (_agent.isStopped)
        {
            return;
        }
        
        if (Math.Abs(_agent.remainingDistance) < 0.001)
        {
            if (_goal == null)
            {
                Debug.Log("[" + name + "] Someone snatched our item " + "away!");
                _goal = SelectNextDestination(true);
            }
            else
            {
                Debug.Log("[" + name + "] Reached target = " + _goal.name);
                _reached.Add(_goal);
                
                
                var buyableGoal = _goal.GetComponent<Buyable>();
                var checkoutGoal = _goal.GetComponent<Checkout>();
                if (buyableGoal != null)
                {
                    // we have reached an item that we want to buy
                    if (buyableGoal.Buy(this))
                    {
                        _cart.Add(_currentItem);
                        Destroy(_goal.gameObject);
                        _goal = SelectNextDestination(false);
                    }
                    else
                    {
                        Debug.LogWarning("Could not buy reserved item! Should not be possible!");
                        _goal = SelectNextDestination(true);
                    }
                } 
                else if (checkoutGoal != null)
                {
                    // we have reached the checkout
                    checkoutGoal.PayAndAdvanceQueue();
                    _goal = exit;
                }
                else if (_goal.name.ToUpper() == "EXIT")
                {
                    Destroy(gameObject);
                }
            }

            if (_goal == null)
            {
                Debug.Log("[" + name + "] Done - Waiting for input!");
                _agent.isStopped = true;
                //Destroy(gameObject);
            }
            else
            {
                Debug.Log("[" + name + "] Set next goal = " + _goal.name);
                if(!_agent.isStopped)
                    _agent.destination = _goal.position;
            }
        }
    }

    public void OrderToPosition(Transform transform)
    {
        _agent.isStopped = false;
        _agent.destination = transform.position;
        _goal = transform;
    }
}
