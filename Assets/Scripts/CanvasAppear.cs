using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasAppear : MonoBehaviour
{
    public GameObject canvas; // Assign in inspector
    private bool isShowing;

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            isShowing = !isShowing;
            canvas.SetActive(isShowing);
        }
    }
}
