using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class UIGame1 : MonoBehaviour
{
    public Spawner spawner;

    public Scrollbar fruitSizeControll;
    public TMP_Text fruitText;

    public Scrollbar swordSizeControll;
    public TMP_Text swordText;
    public Knife knife1;
    public Knife knife2;
    
    public Scrollbar timeControll;
    public TMP_Text timeText;

    public delegate void PauseGame();
    public PauseGame Pause;

    public GameObject pausePanel;

    private InputAction pauseAction;
    [Space] [SerializeField] private InputActionAsset myActionsAsset;


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

        Pause += GameManager.instance.PauseGame;
        Pause += ShowPausePanel;
    }
    private void Update()
    {
        if (pauseAction.triggered)
        {
            Pause?.Invoke();
        }
    }
    
    private void ChangeFruitSize(float value)
    {
        fruitText.text = (0.1f + 1.9f * value).ToString();
    }
    private void ChangeSwordSize(float value)
    {

    }
    private void ChangeTime(float value)
    {
        timeText.text = (1 + (9 * value)).ToString();
    }
    private void ShowPausePanel()
    {
        pausePanel.SetActive(!pausePanel.activeSelf);
    }
}
