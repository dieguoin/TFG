using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public delegate void CoinDelegate(GameObject go);
    CoinDelegate GetCoin;
    private void Start()
    {
        GetCoin += GetComponent<TravelObject>().save.Invoke;
        GetCoin += ObstacleManager.instance.AddPoints;
        GetCoin += CountCoin;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if(other.tag == "MainCamera")
        {
            GetCoin?.Invoke(gameObject);
        }
    }
    private void CountCoin(GameObject go)
    {
        Debug.Log("+1");
    }
}
