using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHandler : MonoBehaviour
{
    public static UIHandler instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

    public string[] scenesName;
    public string[] scenesShownName;
    public int currentScene;

    public Button playButton;
    public Button nextButton;
    public Button prevButton;
    public TMP_Text gameText;

    public GameObject descriptionPanel;
    public GameObject descriptionText;
    public Button returnButton;
    public Button helpButton;
    public string[] descriptions;


    public Button settingsButton;
    public Button quitSettingsButton;
    public Button QuitButton;

    public GameObject ninjaPanel;
    public Button ninjaButton;
    
    public GameObject cablePanel;
    public Button cableButton;
    
    public GameObject cookiePanel;
    public Button cookieButton;
    
    public GameObject planePanel;
    public Button planeButton;

    public GameObject keyBoard;
    public GameObject InputField;
    private void Start()
    {
        returnButton.onClick.AddListener(ShowDescription);
        helpButton.onClick.AddListener(ShowDescription);
        nextButton?.onClick.AddListener(NextSelect);
        prevButton?.onClick.AddListener(PrevSelect);
        playButton?.onClick.AddListener(Play);

        settingsButton?.onClick.AddListener(ShowSettings);

        cableButton?.onClick.AddListener(HideSettingsPanel);
        ninjaButton?.onClick.AddListener(HideSettingsPanel);
        cookieButton?.onClick.AddListener(HideSettingsPanel);
        planeButton?.onClick.AddListener(HideSettingsPanel);

        QuitButton?.onClick.AddListener(GameManager.instance.QuitGame);
        gameText.text = scenesShownName[currentScene];


    }
    private void NextSelect()
    {
        //Debug.Log(scenesName.Length);
        currentScene = (currentScene + 1) % scenesName.Length;
        gameText.text = scenesShownName[currentScene];
    }
    private void PrevSelect()
    {
        currentScene = (currentScene == 0)? scenesName.Length - 1 : currentScene - 1;
        gameText.text = scenesShownName[currentScene];
    }
    private void Play()
    {
        SceneController.instance.ChangeScene(scenesName[currentScene]);
    }
    private void ShowDescription()
    {
        descriptionPanel.SetActive(!descriptionPanel.activeSelf);
        descriptionText.GetComponent<TMP_Text>().text = descriptions[currentScene];
    }

    private void ChangeName()
    {

    }

    private void HideSettingsPanel()
    {
        cablePanel.SetActive(false);
        cookiePanel.SetActive(false);
        ninjaPanel.SetActive(false);
        planePanel.SetActive(false);
    }
    private void ShowSettings()
    {
        switch(currentScene){
            case 0:
                cablePanel.SetActive(true);
                break;
            case 1:
                cookiePanel.SetActive(true);
                break;
            case 2:
                ninjaPanel.SetActive(true);                
                break;
            case 3:
                planePanel.SetActive(true);
                break;
        }
    }
    
    
}
