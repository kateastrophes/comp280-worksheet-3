using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JornalScript : MonoBehaviour
{
    public static JornalScript instance;

    public GameObject logBTN;
    public GameObject jornalCanvas;
    public GameObject hudCanvas;
    public Text LogTitle;
    public Text LogText;


    public List<JornalData> jornalDatas = new List<JornalData>();
    public Transform logButtonParent;

    void Awake()
    {
        instance = this;
        jornalCanvas.SetActive(false);
        hudCanvas.SetActive(true);
        Cursor.visible = false;
        addCollectedLogs();
    }

    [ContextMenu("Add Test Logs")]
    public void DebugAddLog()
    {        
        AddLog("test");
        AddLog("Log 1");
        AddLog("Log 2");
        AddLog("Log 3");
    }

    [ContextMenu("reset Logs")]
    public void resetLogs()
    {
        for (int i = 0; jornalDatas.Count > i; i++)
        {
            jornalDatas[i].collected = false;
        }

    }

    public void AddLog(string logName)
    {
       for (int i = 0; jornalDatas.Count > i; i++)
        {
            if (jornalDatas[i].logTitle == logName)
            {
                jornalDatas[i].collected = true;
                SetupButton(jornalDatas[i]);
            }
                    
        }
    }

    void addCollectedLogs()
    {
        for(int i = 0; i < jornalDatas.Count; i++)
        {
            if(jornalDatas[i].collected == true)
            {
                AddLog(jornalDatas[i].logTitle);
            }
        }
    }

    void SetupButton(JornalData data)
    {
        GameObject clone = Instantiate(logBTN, logButtonParent);
        clone.name = data.logTitle;
        clone.GetComponentInChildren<Text>().text = data.logTitle;

        Button logButton = clone.GetComponent<Button>();
        if(logButton != null)
        {
            logButton.onClick.AddListener(() => LogTitle.text = data.logTitle);
            logButton.onClick.AddListener(() => LogText.text = data.text);
        }
    }

    void Update()
    {
        if (Input.GetKeyUp("j"))
        {
            changeHudState();
        }
    }

    private void changeHudState()
    {
        bool isActive = jornalCanvas.activeInHierarchy;

        jornalCanvas.SetActive(!isActive);
        hudCanvas.SetActive(isActive);
        Cursor.visible = !isActive;
        Cursor.lockState = (isActive) ? CursorLockMode.Locked : CursorLockMode.None;
    }    
}
