using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityEngine.EventSystems;
using TMPro;

public class TextManager : MonoBehaviour
{
    TextMeshProUGUI text;
    private string _ARStatus;

    public delegate void OnStatusChangeDelegate(string newVal);
    public event OnStatusChangeDelegate OnStatusChange;

    public string ARStatus
    {
        get { return _ARStatus; }
        set
        {
            if (_ARStatus == value) return;
            _ARStatus = value;
            if (OnStatusChange != null)
            {
                OnStatusChange(_ARStatus);
                ChangeStatusText();
            }
        }
    }


    void Awake()
    {
        GameObject canvasObject = GameObject.FindGameObjectWithTag("Status");
        text = canvasObject.GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        string firstStatus = "Point to surface.";
        if (ARStatus == null || ARStatus != firstStatus)
        {
            ARStatus = firstStatus;
        }
    }

    void ChangeStatusText()
    {
        if (ARStatus != "The MenuScreen")
        {
            text.text = ARStatus;
        }
    }
}
