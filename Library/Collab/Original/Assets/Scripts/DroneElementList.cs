using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Drone feed object instantiation
public class DroneElementList : MonoBehaviour {

    public GameObject prefab;

    private List<GameObject> prefabList;

    void Start () {
        prefabList = new List<GameObject>();
    }

    // Method for testing purposes only
    public void addElement() {
//        for (int i = 0; prefabList.Count < 3; i++)
//            prefabList.Add(Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity, transform));
        Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity, transform).transform.Translate(transform.parent.position);
    }
}
