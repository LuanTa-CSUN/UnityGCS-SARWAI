using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Drone feed object instantiation
public class ElementList : MonoBehaviour {

    public GameObject prefab;
    public List<GameObject> prefabList;
    public List<GameObject> droneList;

    void Start () {
        prefabList = new List<GameObject>();
    }

    // Instantiates new generic prefab then names it according to its place in the List
    public void addElement () {
        prefabList.Add(Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity, transform));
        prefabList[prefabList.Count - 1].name = prefabList[prefabList.Count - 1].name + prefabList.Count;
    }

    // Same for drones, though I haven't gotten this working yet
    public void addDrone () {
        droneList.Add(Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity, transform));
        droneList[prefabList.Count - 1].name = droneList[prefabList.Count - 1].name + droneList.Count;
    }
}
