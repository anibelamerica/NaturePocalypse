using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

//[RequireComponent(typeof(AudioSource))]
public class NatureAudio : MonoBehaviour
{
    public AudioClip ForestClip;
    public AudioClip DesertClip;
    public AudioClip AmbienceClip;

    public void SceneLoad()
    {

        string sceneName = SceneManager.GetActiveScene().name;

        switch (sceneName)
        {
            case "Forest":
                AudioSource.PlayClipAtPoint(ForestClip, transform.position);
                break;
            case "Desert":
                AudioSource.PlayClipAtPoint(DesertClip, transform.position);
                break;
            default:
                AudioSource.PlayClipAtPoint(AmbienceClip, transform.position);
                break;
        }

    }
}

