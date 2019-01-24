using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CaptureARScreenshot : MonoBehaviour
{

    public void CaptureScreen()
    {
        StartCoroutine(TakeScreenshotAndSave());
    }

    private IEnumerator TakeScreenshotAndSave()
    {
        yield return null;
        Canvas canvas = GameObject.FindGameObjectWithTag("CanvasUI").GetComponent<Canvas>();
        canvas.enabled = false;
        yield return new WaitForEndOfFrame();



        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        // Save the screenshot to Gallery/Photos
        Debug.Log("Permission result: " + NativeGallery.SaveImageToGallery(ss, "GalleryTest", "My img {0}.png"));

        // To avoid memory leaks
        Destroy(ss);

        canvas.enabled = true;
    }



}
