using UnityEngine;
using System.Collections;

public class OnLinkClick : MonoBehaviour
{
    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }

}