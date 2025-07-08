using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public GameObject cube;

    public TMPro.TMP_Text text;

    int points = 0;
    int errors = 0;

    int date = 0;
    private void Start()
    {
        text = GetComponentInChildren<TMPro.TMP_Text>();
        text.text = points.ToString();


        date = DateTime.Now.Hour * 60 + DateTime.Now.Minute * 60 + DateTime.Now.Second;
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        GameObject check = other.gameObject;
        switch (other.tag)
        {
            case "CheckPoint":
                cube.GetComponent<MeshRenderer>().material.color = Color.green;
                points++;
                text.text = points.ToString();

                break;
            case "Wall":
                cube.GetComponent<MeshRenderer>().material.color = Color.red;
                check = check.transform.parent.gameObject;
                errors++;
                break;
        }
        check.GetComponent<CkeckPoint>().SaveGameobject(check);
        

    }
    public void OnDestroy()
    {
        DataManager.instance.RegistrarSesionAirRing(DateTime.Today.ToString("g"), points, errors, 0, DateTime.Now.Hour * 60 + DateTime.Now.Minute * 60 + DateTime.Now.Second - date);
    }
}
