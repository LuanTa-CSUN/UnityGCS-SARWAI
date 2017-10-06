//This script was desinged to grab some text from a local server.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using UnityEngine.UI;

public class GrabText : MonoBehaviour {

    public Text webText;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(GetText());
    }
    //Handles GettingText
    IEnumerator GetText()
    {
        //comment switch depending on server
        //UnityWebRequest www = UnityWebRequest.Get("localhost:3000");
        //UnityWebRequest www = UnityWebRequest.Get("192.168.1.161:9090");
        //Gazeebo Text
        //UnityWebRequest www = UnityWebRequest.Get("http://192.168.1.161:8080");
        //JS Server
        UnityWebRequest www = UnityWebRequest.Get("http://192.168.1.142:8080/upload");

        yield return www.Send();

        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);

            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }
}