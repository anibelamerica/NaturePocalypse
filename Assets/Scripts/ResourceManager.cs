using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        Application.lowMemory += OnLowMemory;
    }

    public void OnLowMemory()
    {
        Resources.UnloadUnusedAssets();
    }
}
