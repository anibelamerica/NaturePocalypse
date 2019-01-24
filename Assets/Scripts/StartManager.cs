using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    private TextManager _messageSender;
    public bool isReady = false;

    // Start is called before the first frame update
    void Awake()
    {
        _messageSender = FindObjectOfType<TextManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneStarted()
    {
        Debug.Log("SceneStarted method was called.");
        Scene m_Scene = SceneManager.GetActiveScene();
        if (m_Scene.name != "MenuScreen")
        {
            _messageSender.ARStatus = "The " + m_Scene.name;
        }

        GameObject startButton = GameObject.FindGameObjectWithTag("StartButton");
        Button button = startButton.GetComponent<Button>();
        button.interactable = !button.interactable;
        button.image.enabled = false;
    }
}
