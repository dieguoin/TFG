using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIGame2 : MonoBehaviour
{

    public static UIGame2 instance;

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

    public Button startButton;
    public Button returnButton;
    
    public Scrollbar cableBar;
    public TMP_Text cableNumberText;

    public Scrollbar seriesBar;
    public TMP_Text seriesNumberText;

    int date;
    private void Start()
    {
        cableBar.onValueChanged.AddListener(CableManager.instance.ChangeCableValue);
        cableBar.onValueChanged.AddListener(ChangeCableNumber);
        //cableNumberText.text = new string("1");
        seriesBar.onValueChanged.AddListener(CableManager.instance.ChangeSeriesValue);
        seriesBar.onValueChanged.AddListener(ChangeSeriesNumber);
        //seriesNumberText.text = new string("1");
        startButton.onClick.AddListener(CableManager.instance.Init);
        returnButton.onClick.AddListener(ChangeScene);

        date = DateTime.Now.Hour * 60 + DateTime.Now.Minute * 60 + DateTime.Now.Second;
    }
    private void ChangeScene()
    {
        SceneController.instance.ChangeScene("MenuScene");
    }
    private void ChangeCableNumber(float value)
    {
        cableNumberText.text = ((int)(1 + value * 9)).ToString();
    }
    private void ChangeSeriesNumber(float value)
    {
        seriesNumberText.text = ((int)(1 + value * 9)).ToString();
    }

    public void SaveValue(int series, int reps)
    {

        DataManager.instance.RegistrarSesionConectarCables(DateTime.Today.ToString("g"), series * reps, 0, 0,DateTime.Now.Hour * 60 + DateTime.Now.Minute * 60 + DateTime.Now.Second - date);
    }
}
