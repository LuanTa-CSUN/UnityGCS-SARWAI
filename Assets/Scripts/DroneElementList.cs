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

    public void addElement() {
        if (prefabList.Count < 10)
            prefabList.Add(Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity, transform));
    }
}
