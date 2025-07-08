using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIGame3 : MonoBehaviour
{
    public static UIGame3 instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            return;
        }
        Destroy(gameObject);
    }


    public GameObject LeftHandPlane;
    public GameObject RightHandPlane;
    public Button LeftHandButton;
    public Button RightHandButton;

    public int points;
    public TMP_Text pointsText;
    int date;
    private void Start()
    {
        LeftHandButton.onClick.AddListener(ChangeLeftHand);
        RightHandButton.onClick.AddListener(ChangeRightHand);

        date = DateTime.Now.Hour * 60 + DateTime.Now.Minute * 60 + DateTime.Now.Second;
    }
    public void ChangeScene()
    {
        SceneController.instance.ChangeScene("MenuScene");
    }

    private void ChangeRightHand()
    {
        RightHandPlane.SetActive(true);
        LeftHandPlane.SetActive(false);
    }
    private void ChangeLeftHand()
    {
        RightHandPlane.SetActive(false);
        LeftHandPlane.SetActive(true);
    }
    public void AddPoints(int points)
    {
        pointsText.text = points.ToString();
    }
    private void OnDestroy()
    {
        if(instance == this)
        {

            DataManager.instance.RegistrarSesionCookieTwist(DateTime.Today.ToString("g"), 0, points, DateTime.Now.Hour * 60 + DateTime.Now.Minute * 60 + DateTime.Now.Second - date);

            instance = null;
        }
    }
}
