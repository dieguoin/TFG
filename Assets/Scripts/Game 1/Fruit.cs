using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public FruitsScriptable fruit;
    private Rigidbody rb;
    public Vector3 playerPosition;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }
    public void SetPlayer(Vector3 playerPos, FruitsScriptable fruits)
    {
        playerPosition = playerPos;
        fruit = fruits;
        GetComponent<MeshRenderer>().material = fruit.fruitMaterial;
        GetComponent<MeshFilter>().mesh = fruit.fruitMesh;
        Init();
    }

    private void Init()
    {
        rb.AddForce(fruit.speed * (playerPosition - transform.position) + new Vector3(0, fruit.speedY, 0));
    }
}
