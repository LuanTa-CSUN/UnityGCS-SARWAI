using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DroneInfoElement : MonoBehaviour {
    public GameObject prefab;
    //public Image tempImage;
    //public string csvPath;

	// Use this for initialization
    //void Start () {
    //    string columnTest;
    //    int count = 0;
    //    int length;

    //    var reader = new StreamReader(csvPath);
    //    columnTest = reader.ReadLine();
    //    length = columnTest.Length;

    //    while (length > 0) {
    //        columnTest.Split(',');
    //        length = columnTest.Length;
    //        count++;
    //    }
    //}

    void Start () {
        for (int i = 0; i < 10; i++)
            Instantiate(prefab, new Vector3(0,0,0), Quaternion.identity, transform);
    }
}
