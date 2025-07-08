using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class CableManager : MonoBehaviour
{
    public static CableManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            return;
        }
        Destroy(gameObject);
        
    }
    private void OnDestroy()
    {
        if(instance == this)
        {
            UIGame2.instance.SaveValue(cableNumber, seriesNumber);
            instance = null;
        }
    }

    public GameObject cableStartPrefab;
    public GameObject cableFinishPrefab;
    public GameObject rightRayHand;
    public List<GameObject> cableObjects;
    public Vector3 startPosition;
    [Header("Series")]
    [Range(1, 10)]
    private int seriesNumber = 1;
    private int currentSerie;
    [Range(1, 10)]
    private int cableNumber= 1;
    private int connectedCables;
    public GameObject Bar;
    private void Start()
    {
        seriesNumber = (int)DataManager.instance.configuracionActual.juegos.conectar_cables.numero_series;
        cableNumber = (int)DataManager.instance.configuracionActual.juegos.conectar_cables.numero_repeticiones;
    }
    public void Init()
    {
        rightRayHand.SetActive(false);
        currentSerie = 0;
        connectedCables = 0;
        GenerateSerie();
    }
    private void GenerateSerie()
    {
        Vector3 position = transform.position + startPosition; //+ new Vector3(.5f, 0, 0);
        Vector3 distance = new Vector3(0, -.5f, 0);
        bool control = false;
        bool control2 = false;
        for(int i = 0; i < cableNumber; i++)
        {
            cableObjects.Add(Instantiate(cableStartPrefab, position, new Quaternion(0, 0, 0, 0), gameObject.transform));
            cableObjects.Add(Instantiate(cableFinishPrefab, position + distance, new Quaternion(0, 0, 0, 0), gameObject.transform));
            if (control)
            {
                position += new Vector3(0, 0, .2f);
            }
            else
            {
                if (control2)
                {
                    position += new Vector3(.2f, 0, 0f);
                }
                else
                {
                    position -= new Vector3(.2f, 0, 0f);
                }
                control2 = !control2;
            }
            
            control = !control;
        }
        connectedCables = 0;
        currentSerie++;
    }
    private void ClearSet()
    {
        
        StartCoroutine(FinishSerie());
        foreach(GameObject go in cableObjects)
        {
            Destroy(go);
        }
    }
    public void CableConnect()
    {
        connectedCables++;
        if(connectedCables >= cableNumber)
        {
            ClearSet();
            if (currentSerie < seriesNumber)
            {
                GenerateSerie();
            }
            else
            {
                rightRayHand.SetActive(true);
            }
        }
    }
    private void LightBar(bool light)
    {
        Bar.transform.GetChild(0).gameObject.SetActive(light);
        Bar.transform.GetChild(1).gameObject.SetActive(light);
    }
    public void ChangeCableValue(float newValue)
    {
        cableNumber = (int)(1 + 9 * newValue);
    }
    public void ChangeSeriesValue(float newValue)
    {
        seriesNumber = (int)(1 + 9 * newValue );
    }
    private IEnumerator FinishSerie()
    {
        LightBar(true);
        Debug.Log("Coroutine");
        yield return new WaitForSeconds(1.0f);
        LightBar(false);
    }
    
}
