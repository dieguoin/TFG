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
    public int currentScene;

    public Button playButton;
    public Button nextButton;
    public Button prevButton;
    public TMP_Text gameText;

    public Button settingsButton;
    public Button quitSettingsButton;
    public Button QuitButton;

    private void Start()
    {
        nextButton?.onClick.AddListener(NextSelect);
        prevButton?.onClick.AddListener(PrevSelect);
        playButton?.onClick.AddListener(Play);
        Debug.Log("buttonsAdded");
        QuitButton?.onClick.AddListener(GameManager.instance.QuitGame);
        gameText.text = scenesName[currentScene];
    }
    private void NextSelect()
    {
        Debug.Log(scenesName.Length);
        currentScene = (currentScene + 1) % scenesName.Length;
        gameText.text = scenesName[currentScene];
    }
    private void PrevSelect()
    {
        currentScene = (currentScene == 0)? scenesName.Length - 1 : currentScene - 1;
        gameText.text = scenesName[currentScene];
    }
    private void Play()
    {
        SceneController.instance.ChangeScene(scenesName[currentScene]);
    }
}
