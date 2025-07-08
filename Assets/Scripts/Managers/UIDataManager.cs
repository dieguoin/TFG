using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDataManager : MonoBehaviour
{
    public TMP_Dropdown userDropdown1;
    public Scrollbar spawnFrequency;
    public Scrollbar fruitSize;
    public Scrollbar knifeSize;
    public TMP_Text fruitText;
    public TMP_Text swordText;
    public TMP_Text timeText;

    public TMP_Dropdown userDropdown2;
    public Scrollbar series;
    public Scrollbar reps;
    public TMP_Text cableNumberText;
    public TMP_Text seriesNumberText;
    
    public TMP_Dropdown userDropdown3;
    public Scrollbar cookieSpeed;
    public Scrollbar timeLimit;
    public Scrollbar spawnDistance;
    public Scrollbar dispertion;
    public TMP_Text cookieSpeedText;
    public TMP_Text timeLimitText;
    public TMP_Text spawnDistanceText;
    public TMP_Text dispertionText;

    public TMP_Dropdown userDropdown4;
    public Scrollbar angle;
    public TMP_Text angleText;

    public Button saveButton1;
    public Button saveButton2;
    public Button saveButton3;
    public Button saveButton4;

    private void Start()
    {
        DataManager.instance.LoadUsers();

        SetDropdowns(1);
        userDropdown1.onValueChanged.AddListener(DataManager.instance.ChangeUser);
        userDropdown1.onValueChanged.AddListener(SetDropdowns);
        userDropdown1.onValueChanged.AddListener(SetStatsToUser);
        userDropdown2.onValueChanged.AddListener(DataManager.instance.ChangeUser);
        userDropdown2.onValueChanged.AddListener(SetDropdowns);
        userDropdown2.onValueChanged.AddListener(SetStatsToUser);

        saveButton1.onClick.AddListener(DataManager.instance.SaveUser);
        saveButton2.onClick.AddListener(DataManager.instance.SaveUser);
        saveButton3.onClick.AddListener(DataManager.instance.SaveUser);
        saveButton4.onClick.AddListener(DataManager.instance.SaveUser);

        spawnFrequency.onValueChanged.AddListener(ChangeSpawn);
        fruitSize.onValueChanged.AddListener(ChangeFruit);
        knifeSize.onValueChanged.AddListener(ChangeKnife);

        series.onValueChanged.AddListener(ChangeSeries);
        reps.onValueChanged.AddListener(ChangeReps);

        cookieSpeed.onValueChanged.AddListener(ChangeCookieSpeed);
        timeLimit.onValueChanged.AddListener(ChangeTimeLimit);
        spawnDistance.onValueChanged.AddListener(ChangeSpawnDistance);
        dispertion.onValueChanged.AddListener(ChangeDispertion);

        angle.onValueChanged.AddListener(ChangeAngle);

        SetStatsToUser(1);
    }
    private void SetDropdowns(int value)
    {
        userDropdown1.options = new List<TMP_Dropdown.OptionData>();
        userDropdown2.options = new List<TMP_Dropdown.OptionData>();
        userDropdown3.options = new List<TMP_Dropdown.OptionData>();
        userDropdown4.options = new List<TMP_Dropdown.OptionData>();
        userDropdown1.AddOptions(DataManager.instance.GetUsernames());
        userDropdown1.AddOptions(new List<string> { "New User +" });
        userDropdown3.AddOptions(DataManager.instance.GetUsernames());
        userDropdown3.AddOptions(new List<string> { "New User +" });
        userDropdown2.AddOptions(DataManager.instance.GetUsernames());
        userDropdown2.AddOptions(new List<string> { "New User +" });
        userDropdown4.AddOptions(DataManager.instance.GetUsernames());
        userDropdown4.AddOptions(new List<string> { "New User +" });
    }
    private void SetStatsToUser(int value)
    {
        var u = DataManager.instance.currentUser;
        
        spawnFrequency.value = u.spawnTime;
        fruitSize.value = u.fruitSize;
        knifeSize.value = u.knifeSize;

        series.value = u.series;
        reps.value = u.repetitions;
    }
    private void ChangeSpawn(float value)
    {
        DataManager.instance.ChangeValue("spawnTime", value);
        timeText.text = ((int)(1 + 9 * DataManager.instance.currentUser.spawnTime)).ToString();
    }
    private void ChangeFruit(float value)
    {
        DataManager.instance.ChangeValue("fruitSize", value);
        fruitText.text = ((int)(1 + 9 * DataManager.instance.currentUser.fruitSize)).ToString();
    }
    private void ChangeKnife(float value)
    {
        DataManager.instance.ChangeValue("knifeSize", value);
        swordText.text = ((int)(1 + 9 * DataManager.instance.currentUser.knifeSize)).ToString();
    }
    private void ChangeSeries(float value)
    {
        DataManager.instance.ChangeValue("series", value);
        seriesNumberText.text = ((int)(1 + DataManager.instance.currentUser.series * 9)).ToString();
    }
    private void ChangeReps(float value)
    {
        DataManager.instance.ChangeValue("repetitions", value);
        cableNumberText.text = ((int)(1 + DataManager.instance.currentUser.repetitions * 9)).ToString();
    }
    private void ChangeCookieSpeed(float value)
    {
        DataManager.instance.ChangeValue("cookieSpeed", value);
        cookieSpeedText.text = ((int)(1 + DataManager.instance.currentUser.cookieSpeed * 9)).ToString();
    }
    private void ChangeTimeLimit(float value)
    {
        DataManager.instance.ChangeValue("timeLimit", value);
        timeLimitText.text = ((int)(1 + (int)(DataManager.instance.currentUser.timeLimit * 9) * 10)).ToString();
    }
    private void ChangeSpawnDistance(float value)
    {
        DataManager.instance.ChangeValue("spawnDistance", value);
        spawnDistanceText.text = ((int)(1 + DataManager.instance.currentUser.spawnDistance * 9)).ToString();
    }
    private void ChangeDispertion(float value)
    {
        DataManager.instance.ChangeValue("dispertion", value);
        dispertionText.text = (value == 0) ? "izquierda" : (value == 1) ? "derecha" : "aleatorio";
    }
    private void ChangeAngle(float value)
    {
        DataManager.instance.ChangeValue("angle", value);
        angleText.text = (value != 1)?((int)(20 + (int)(DataManager.instance.currentUser.angle * 9)*20)).ToString(): "180";
    }
}
