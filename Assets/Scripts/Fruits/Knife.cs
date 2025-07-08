using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public GameObject hand;
    private void Start()
    {
        ChangeSize(DataManager.instance.configuracionActual.juegos.fruit_ninja_vr.tamaño_cuchillo);
    }
    public void ChangeSize(float scale)
    {
        transform.localScale =  new Vector3(.5f + .5f * scale, .5f + .5f * scale, .5f + .5f * scale);
        transform.localPosition = Vector3.zero;
    }
}
