using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelObject : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public delegate void Action(Transform road);
    public Action Init;
    public delegate void Save(GameObject go);
    public Save save;

    public void Awake()
    {
        rb.GetComponent<Rigidbody>();
        Init += ShowObject;
        Init += SetPosition;
        Init += SetVelocity;

        speed = DataManager.instance.currentUser.cookieSpeed;

        save += ObstacleManager.instance.SaveObject;
        save += HideObject;
        save += Stop;
    }
    public void SetPosition(Transform road)
    {
        transform.position = road.position;
    }
    public void SetVelocity(Transform road)
    {
        speed = -5;
        rb.velocity = new Vector3(0, 0, speed);
    }
    
    public void Stop(GameObject go)
    {
        rb.velocity = new Vector3(0, 0, 0);
    }
    public void Update()
    {
        if(transform.position.z <= -4)
        {
            SaveGameobject(gameObject);
        }
    }
    public void HideObject(GameObject go)
    {
        gameObject.SetActive(false);
    }
    public void ShowObject(Transform road)
    {
        gameObject.SetActive(true);
    }
    public void SaveGameobject(GameObject go)
    {
        if(go == gameObject) save?.Invoke(go);
    }
    
}
