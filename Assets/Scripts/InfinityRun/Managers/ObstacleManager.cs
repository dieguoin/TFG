using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.InputSystem;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public static ObstacleManager instance;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            return;
        }
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

    
    

    private InputAction pauseAction;
    [Space] [SerializeField] private InputActionAsset myActionsAsset;

  

    /// 

    [SerializeField]private bool initGame;
    public GameObject Canvas;
    public GameObject obstaclePrefab;
    public int obstacleCount = 0;
    private Queue<GameObject> coinPool = new Queue<GameObject>();
    private GameObject enteringObject;


    private int points;

    public Transform[] Roads;
    [Range(0, 10)]
    public int randomLat = 0;
    private float currentSpawnTime = 5;
    private float cookieTimer = DataManager.instance.configuracionActual.juegos.cookie_twist_vr.frecuencia_galletas;
    private float planeTimer = DataManager.instance.configuracionActual.juegos.air_ring_vr.frecuencia_anillos;

    private float timer = 0;

    private float gameTimer = 100;
    private float currentTimer = 0;

    private void Start()
    {
        Roads[1] .position = Roads[0].position + new Vector3(0, 0, DataManager.instance.configuracionActual.juegos.cookie_twist_vr.separacion_carriles);
        Roads[2] .position = Roads[0].position + new Vector3(0, 0, -DataManager.instance.configuracionActual.juegos.cookie_twist_vr.separacion_carriles);

        if(SceneController.instance.name == "Cookie")
        {
            gameTimer = DataManager.instance.configuracionActual.juegos.cookie_twist_vr.duracion_sesion_segundos;
            timer = cookieTimer;
        }
        else if(SceneController.instance.name == "Plane")
        {
            //gameTimer = DataManager.instance.configuracionActual.juegos.air_ring_vr.duracion_sesion_segundos;
            timer = planeTimer;
        }

        pauseAction = myActionsAsset.FindAction("XRI LeftHand Interaction/Pause");
    }
    private void Update()
    {
        if(currentTimer >= gameTimer)
        {
            FinishGame();
            return;
        }
        if (pauseAction.triggered)
        {
            StartGame(!initGame);
        }
        if (!initGame) return;
        if(currentSpawnTime > timer)
        {
            Debug.Log(coinPool.Count);
            if(coinPool.Count == 0)
            {
                enteringObject = GameObject.Instantiate(obstaclePrefab, transform);
                enteringObject.GetComponent<TravelObject>().Init.Invoke(Roads[(obstacleCount % 2 == 0)? 0 : GetRoad()]);
                obstacleCount++;
            }
            else
            {
                UseObject();
                enteringObject.GetComponent<TravelObject>().Init.Invoke(Roads[(obstacleCount % 2 == 0) ? 0 : GetRoad()]);
                obstacleCount++;
                
            }
            currentSpawnTime = 0;
        }
        currentSpawnTime += Time.deltaTime;
    }
    private int GetRoad()
    {
        //0 - centre
        //1 - right
        //2 - left

        if(Random.value > randomLat * 0.1)
        {
            return 1;
        }
        else
        {
            return 2;
        }


    }
    private void FinishGame()
    {
        StartGame(false);
        pauseAction = null;
    }
    public void SaveObject(GameObject obj)
    {
        coinPool.Enqueue(obj);
    }
    public void UseObject()
    {
        enteringObject = coinPool.Dequeue();

    }
    public void StartGame(bool starting)
    {
        initGame = starting;
        Canvas.SetActive(!starting);
    }
    public void AddPoints(GameObject go)
    {
        points += 1;
        UIGame3.instance.AddPoints(points);
    }
}
