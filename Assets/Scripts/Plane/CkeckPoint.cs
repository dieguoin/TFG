using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CkeckPoint : TravelObject
{
    public Vector3 localRotation;
    public float rotationLimit = 100;
    private void  Start()
    {
        //Init += SetRotation;

        rotationLimit = 120;
        SetRotation(/*transform*/);
    }
    public void SetRotation(/*Transform road*/)
    {
        Debug.Log(rotationLimit);
        transform.rotation = new Quaternion(0, 0, 0, 0);
        transform.localRotation = Quaternion.Euler(localRotation);
        transform.rotation = Quaternion.Euler(Random.Range(-rotationLimit, rotationLimit), transform.rotation.y, transform.rotation.z);
    }
    public void SetColor(string color)
    {
        switch (color)
        {
            case "red":
                GetComponent<MeshRenderer>().materials[0].color = new Color(255, 0, 0);
                break;
            case "green":
                GetComponent<MeshRenderer>().materials[0].color = new Color(0, 255, 0);
                break;
        }
        StartCoroutine(WaitSeconds(1));
        save?.Invoke(gameObject);
    }
    private IEnumerator WaitSeconds(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
