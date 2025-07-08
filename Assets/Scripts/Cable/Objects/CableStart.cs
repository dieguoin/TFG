using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CableStart : MonoBehaviour
{
    private GameObject attachedObject = null;
    private GameObject currentHand = null;
    private GameObject secondHand = null;
    private LineRenderer line;
    
    
    private void Awake()
    {
        line = GetComponent<LineRenderer>();
        
        

    }
    public void SetHand(GameObject hand)
    {
        //bool sameHand = currentHand == hand;
        //bool notHand = currentHand == null;
        //currentHand = (notHand)? hand : (currentHand == hand)?  secondHand  : currentHand;
        //secondHand = (notHand) ? null : (sameHand) ? null : (secondHand == hand)? null : hand;
        currentHand = hand;
    }
    
    public void CreateLine(GameObject go)
    {
        attachedObject = go;
        line.enabled = true;
        line.SetPosition(0, transform.position);
    }
    public void RemoveLine()
    {
        attachedObject = null;
        line.enabled = false;
    }
    private void Update()
    {
        if (!line.enabled) return;
        line?.SetPosition(1, attachedObject.transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        SetHand(other.gameObject);
        ChangeColor();
    }
    private void OnTriggerExit(Collider other)
    {
        SetHand(other.gameObject);
        ChangeColor();
    }
    private void ChangeColor()
    {
        GetComponent<MeshRenderer>().material.color = (currentHand != null & secondHand == null) ? Color.green : Color.red;
    }
    
}
