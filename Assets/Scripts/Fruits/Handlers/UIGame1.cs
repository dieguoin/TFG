using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class UIGame1 : MonoBehaviour
{

    public static UIGame1 instance;
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
            DataManager.instance.RegistrarSesionFruitNinja(DateTime.Today.ToString("g"), spawner.frutas, spawner.points, DateTime.Now.Hour * 60 + DateTime.Now.Minute * 60 + DateTime.Now.Second - date, 0);

            instance = null;
        }
    }

    public Spawner spawner;

    public Scrollbar fruitSizeControll;
    public TMP_Text fruitText;

    public Scrollbar swordSizeControll;
    public TMP_Text swordText;
    public Knife knife1;
    public Knife knife2;
    
    public Scrollbar timeControll;
    public TMP_Text timeText;

    public delegate void PauseGame(bool active);
    public PauseGame Pause;

    public GameObject pausePanel;

    public Button returnButton;
    public Button startButton;

    public GameObject LeftRay;
    public GameObject RightRay;

    private InputAction pauseAction;
    [Space] [SerializeField] private InputActionAsset myActionsAsset;

    private int date;



    private void Start()
    {
        pauseAction = myActionsAsset.FindAction("XRI LeftHand Interaction/Pause");

        swordSizeControll.onValueChanged.AddListener(ChangeSwordSize);
        swordSizeControll.onValueChanged.AddListener(knife1.ChangeSize);
        swordSizeControll.onValueChanged.AddListener(knife2.ChangeSize);

        fruitSizeControll.onValueChanged.AddListener(ChangeFruitSize);
        fruitSizeControll.onValueChanged.AddListener(spawner.ChangeSize);

        timeControll.onValueChanged.AddListener(ChangeTime);
        timeControll.onValueChanged.AddListener(spawner.ChangeVelocity);

        returnButton.onClick.AddListener(ChangeScene);

        startButton.onClick.AddListener(StopGame);

        Pause += spawner.ChangeActiveState;
        Pause += ShowPausePanel;

        date = DateTime.Now.Hour * 60 + DateTime.Now.Minute * 60 + DateTime.Now.Second;
    }
    private void Update()
    {
        if (pauseAction.triggered)
        {
            Pause?.Invoke(true);
        }
    }
    private void StopGame()
    {
        Pause?.Invoke(false);
    }
    private void ChangeFruitSize(float value)
    {
        fruitText.text = ((int)(1 + 9 * value)).ToString();
    }
    private void ChangeSwordSize(float value)
    {
        swordText.text = ((int)(1 + 9 * value)).ToString();
    }
    private void ChangeTime(float value)
    {
        timeText.text = ((int)(1 + (9 * value))).ToString();
    }
    private void ShowPausePanel(bool isPaused)
    {
        pausePanel.SetActive(isPaused);
        
        LeftRay.GetComponent<XRRayInteractor>().enabled = isPaused;
        LeftRay.GetComponent<LineRenderer>().enabled = isPaused;
        LeftRay.GetComponent<XRInteractorLineVisual>().enabled = isPaused;

        RightRay.GetComponent<XRRayInteractor>().enabled = isPaused;
        RightRay.GetComponent<LineRenderer>().enabled = isPaused;
        RightRay.GetComponent<XRInteractorLineVisual>().enabled = isPaused;
    }
    private void ChangeScene()
    {
        SceneController.instance.ChangeScene("MenuScene");
    }
}
