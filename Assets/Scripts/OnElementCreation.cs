using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnElementCreation : MonoBehaviour {

    public GameObject svContent;
    private List<GameObject> feedCanvasList;

    // Sets all existing scroll views to disabled, then adds elements to the new view
    // Elements there only for testing purposes
    // Seems to be an error somewhere in here, causing a failure to display debug info in correct sequence
	void Start () {
        feedCanvasList = new List<GameObject>();
        feedCanvasList = transform.parent.GetComponent<ElementList>().prefabList;

        for (int i = 0; i < feedCanvasList.Count - 1; i++) {
            feedCanvasList[i].SetActive(false);
            Debug.Log(feedCanvasList[i].name);
        }

        for (int i = 1; i <= feedCanvasList.Count; i++)
            svContent.GetComponent<ElementList>().addElement();
	}
}
