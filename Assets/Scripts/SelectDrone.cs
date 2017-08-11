using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDrone : MonoBehaviour {
    public static List<GameObject> tempInfoList;
    public static List<GameObject> tempFeedList;

    // Gets access to both existing scroll views and their contents
    // For use with drone selection switching
    void Start () {
        tempInfoList = new List<GameObject>();
        tempFeedList = new List<GameObject>();

        tempInfoList = GameObject.FindWithTag("DroneInfoContent").transform.GetComponent<ElementList>().prefabList;
        tempFeedList = transform.parent.GetComponent<ElementList>().prefabList;
    }

    // Will figure out how to get index of selected item later
    // Once I have, this will set the correct right-pane scroll view to visible and disable all others
    public void setActiveComponent() {

    }
}
