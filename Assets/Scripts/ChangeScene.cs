using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.XR.iOS;
//using System;
//using System.Linq;
//using Collections.Hybrid.Generic;

public class ChangeScene : MonoBehaviour
{
    private bool loadScene = false;
    private TextManager _messageSender;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Load scene.");

        if (SceneManager.GetActiveScene().name != "MenuScreen")
        {
            _messageSender = FindObjectOfType<TextManager>();
            _messageSender.OnStatusChange += StatusChangeHandler;
        }
    }

    private void StatusChangeHandler(string newVal)
    {
        Debug.Log("Event Fired. My string = " + newVal);
    }

    public void ChangeNature(string scene)
    {
        Scene m_Scene = SceneManager.GetActiveScene();
        if (m_Scene.name != scene && loadScene == false)
        {
            loadScene = true;

            StartCoroutine(LoadNewScene(scene));

            if (scene != "MenuScreen")
            {
                _messageSender.ARStatus = "The " + scene;
            }
            else
            {
                _messageSender.ARStatus = "The Forest";
            }

            loadScene = false;

            GameObject[] goGround = GameObject.FindGameObjectsWithTag("GroundSpawn");
            GameObject[] goWall = GameObject.FindGameObjectsWithTag("WallSpawn");

            if (goGround == null || goGround.Length == 0)
                return;

            for (int i = goGround.Length - 1; i >= 0; i--)
            {
                Destroy(goGround[i]);
            }

            if (goWall == null || goWall.Length == 0)
                return;

            for (int i = goWall.Length - 1; i >= 0; i--)
            {
                Destroy(goWall[i]);
            }


        }
        else
        {
            //Debug.Log("m_Scene is " + m_Scene.buildIndex + " and scene is: " + scene);
        }


    }

    IEnumerator LoadNewScene(string scene)
    {

        AsyncOperation async2 = SceneManager.LoadSceneAsync("LoadingScreen");

        AsyncOperation async = SceneManager.LoadSceneAsync(scene);


        while (!async.isDone)
        {
            yield return null;
        }


    }


}
