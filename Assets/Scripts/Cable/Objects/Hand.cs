using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private GameObject cableStart = null;
    private GameObject cubeAttached = null;
    private GameObject cableFinish = null;

    
    public void CreateLine()
    {
        cableStart.GetComponent<LineRenderer>().enabled = true;
        cableStart.GetComponent<CableStart>().CreateLine(gameObject);
        cubeAttached = cableStart;
    }
    public void AttachLine()
    {
        if (cableFinish == null) return;
        cubeAttached.GetComponent<CableStart>().CreateLine(cableFinish);
        Destroy(cubeAttached.GetComponent<CableStart>());
        Destroy(cableFinish.GetComponent<CableFinish>());
        cubeAttached = null;
        CableManager.instance.CableConnect();
    }
    public void DestroyLine()
    {
        if (cableFinish != null) return;
        cubeAttached.GetComponent<CableStart>().RemoveLine();
        cubeAttached = null;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CableOrigin")
        {
            cableStart = other.gameObject;
        }
        if(other.tag == "CableFinish")
        {
            cableFinish = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "CableOrigin")
        {
            cableStart = null;
        }
        if (other.tag == "CableFinish")
        {
            cableFinish = null;
        }
    }
}
