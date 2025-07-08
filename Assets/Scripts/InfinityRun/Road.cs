using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{

    public float raycastDistance;
    public LayerMask playerLayer;
    // Update is called once per frame
    void Update()
    {
        Glow(Physics.Raycast(transform.position, -transform.forward, raycastDistance, playerLayer));
    }
    private void Glow(bool contact)
    {

        GetComponent<MeshRenderer>().material.color = (contact) ? Color.red : Color.blue;
        
    }
    
}
