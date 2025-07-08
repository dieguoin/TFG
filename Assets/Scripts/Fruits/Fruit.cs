using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public FruitsScriptable fruit;
    private Rigidbody rb;
    public Vector3 playerPosition;

    delegate void AddPoint();
    AddPoint addPoint;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 5);
        addPoint += UIGame1.instance.spawner.AddPoint;
    }
    public void SetPlayer(Vector3 playerPos, FruitsScriptable fruits)
    {
        playerPosition = playerPos + new Vector3(Random.Range(-1, 1), 1, Random.Range(-.5f, .5f));
        fruit = fruits;
        GetComponent<MeshRenderer>().material = fruit.fruitMaterial;
        GetComponent<MeshFilter>().mesh = fruit.fruitMesh;
        transform.localScale = new Vector3(fruit.size, fruit.size, fruit.size);
        Init();
    }
    
    private void Init()
    {
        rb.AddForce(fruit.speed * (playerPosition - transform.position) + new Vector3(0, fruit.speedY, 0));
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Knife")
        {
            addPoint?.Invoke();
            GameObject.Instantiate(fruit.DestroyFruit, transform.position, new Quaternion(0, 0, 0, 0));
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
    }
}
