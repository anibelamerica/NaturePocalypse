using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    public void ShowPop(GameObject mySecondCanvas)
    {
        mySecondCanvas.SetActive(true);
    }

    public void HidePop(GameObject mySecondCanvas)
    {
        mySecondCanvas.SetActive(false);
    }
}
