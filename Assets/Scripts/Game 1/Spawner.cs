using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject fruitPrefab;
    [SerializeField] private List<FruitsScriptable> fruitStats= new List<FruitsScriptable>(7);
    public GameObject player;
    [Range(1, 10)]
    public float minX;
    [Range(1, 10)]
    public float maxX;
    [Range(1, 10)]
    public float minY;
    [Range(1, 10)]
    public float maxY;
    [Range(1, 2)]
    public float velocityRange;
    [Range(1, 10)]
    public float respawnTimer;
    public float timer;
    private void Start()
    {
        timer = respawnTimer;
    }
    private void Update()
    {
        if(timer >= respawnTimer)
        {
            Spawn();
            timer = 0;
        }
        timer += Time.deltaTime;
    }
    public void Spawn()
    {
        GameObject newFruit = GameObject.Instantiate(fruitPrefab, player.transform.position + new Vector3((Random.value > 0.5f)? Random.Range(minX, maxX) : -Random.Range(minX, maxX), Random.Range(minY, maxY) , (Random.value > 0.5f) ? Random.Range(minX, maxX) : -Random.Range(minX, maxX)), new Quaternion(0, 0, 0, 0));
        newFruit.GetComponent<Fruit>().SetPlayer(player.transform.position, fruitStats[Random.Range(0, 7)]);
    }
}
