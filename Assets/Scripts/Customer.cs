﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Moves through all of the transform goals one after another
/// Ignores the height of the supplied Tranform.positions.
/// Expect the GameObject to have a NavMeshAgent
/// </summary>
public class Customer : MonoBehaviour
{
    public List<Transform> goals;
    public Transform checkout;
    public Transform exit;
    
    private NavMeshAgent _agent;
    private Transform _goal;
    private Queue<Transform> _goalQueue;
    
    void Start () {
        _agent = GetComponent<NavMeshAgent>();
        if (_agent == null)
        {
            Debug.LogError("Customer has no NavMeshAgent attached!");
        }
        _goalQueue = new Queue<Transform>(goals);

        _goal = _goalQueue.Dequeue();
        
        // add the checkout and exit at the end
        _goalQueue.Enqueue(checkout);
        _goalQueue.Enqueue(exit);
        
        // use y of own transform so height is not an issue
        var goalPosition = _goal.position;
        _agent.destination = new Vector3(goalPosition.x, GetComponent<Transform>().position.y, goalPosition.z);
        _agent.autoBraking = true;
    }

    private void Update()
    {
        
        if (_agent.isStopped)
        {
            return;
        }
        
        if (Math.Abs(_agent.remainingDistance) < 0.001)
        {
            Debug.Log("Reached target = " + _agent.remainingDistance);
            // Take the item and remove it from the shopping list TODO
            
            Destroy(_goal.gameObject);
            //var oldGoal = _goal;
            
            if (_goalQueue.Count > 0)
            {
                _goal = _goalQueue.Dequeue();
                //Destroy(oldGoal.gameObject);
                _agent.destination = _goal.position;
            }
            else
            {
                Debug.Log("Done with targets!");
                Destroy(this.gameObject);
            }
        }
    }
}
