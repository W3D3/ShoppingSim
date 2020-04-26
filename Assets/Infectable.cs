using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infectable : MonoBehaviour
{
    public float timeToBeInfected;
    public float infectionDistance;

    private bool _inInfectionZone;
    private float _timeInInfectionZone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = new Color(0.3f, 1, 0, 0.5f);
        Gizmos.DrawSphere(transform.position, infectionDistance);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (_inInfectionZone) _timeInInfectionZone += Time.deltaTime;
        //Debug.Log("_timeInInfectionZone");
        InfectFromRadius(transform.position, infectionDistance);

        if (_timeInInfectionZone > timeToBeInfected)
        {
            Debug.Log("[Infect]"+ this.name + " got infected ");
        }
    }
    
    void InfectFromRadius(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;
        bool hitThisFrame = false;
        while (i < hitColliders.Length)
        {
            var customer = hitColliders[i].GetComponent<Customer>();
            if (customer != null && customer != this.GetComponent<Customer>())
            {
                Debug.Log("[Infect]"+ this.name + " has customer in prox: " + customer.gameObject.name);
                _inInfectionZone = true;
                hitThisFrame = true;
            }
            i++;
        }

        if (!hitThisFrame) _inInfectionZone = false;
    }
}
