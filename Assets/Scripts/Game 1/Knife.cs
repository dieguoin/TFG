using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public GameObject hand;
    public void ChangeSize(float scale)
    {
        transform.localScale =  new Vector3(scale, scale, scale);
        transform.localPosition = Vector3.zero;
    }
}
