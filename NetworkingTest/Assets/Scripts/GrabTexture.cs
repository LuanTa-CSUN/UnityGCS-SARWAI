//This script is designed to get the video feed from a local Web_Video_Server and play it back in Unity.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using UnityEngine.UI;

public class GrabTexture : MonoBehaviour
{
    Texture myTexture;
    //public Text webText;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(GetTexture());
    }


    //Handles Getting Texture.
    IEnumerator GetTexture()
    {
        //Video feed from Gazeebo
        //UnityWebRequest www = UnityWebRequestTexture.GetTexture("http://192.168.1.161:8080/stream_viewer?topic=/stereo/left/image_raw");
        // UnityWebRequest www = UnityWebRequestTexture.GetTexture("http://192.168.1.161:8080/stream_viewer?topic=/stereo/right/image_raw");
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("http://192.168.1.161:8080/stream_viewer?topic=/stereo/left/image_raw");
        yield return www.Send();

        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        }
    }
    //On GUI handles texture output (Display to Screen).
    void OnGUI()
    {
        if (!myTexture)
        {
            Debug.LogError("Assign a Texture in the inspector.");
            return;
        }
        GUI.DrawTexture(new Rect(0, 0, 400, 300), myTexture, ScaleMode.StretchToFill, true, 10.0F);
    }
}