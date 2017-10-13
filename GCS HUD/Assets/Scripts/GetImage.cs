/*
 //GetImage.cs is responsible for grabing a tecture form ROSbridge's 
 //video_websocket_server. The tecture corresponds to the live feed camera
 //that is attached to the Husky bot in Gazebo. 
 //After capturing the image, the image is displayed onto a Gameobject in Unity,
 //for visability. 
 //The image is refreshed at every frame providing an updated new image, thus giving
 //a live video stream of the cameras on the Gazebo Husky bot.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GetImage : MonoBehaviour {
	//Allows 
	public string url = "https://docs.unity3d.com/uploads/Main/ShadowIntro.png";

	//At start of program the first image is captured.
	void Start ()
	{
		//calls the funtion GetTexture to grab the Husky image.
		StartCoroutine(GetTexture());
	}
	
	//At every frame during program execut9ion, get a new image from ROSbridge video_websocket_server.
	void Update ()
	{
		//calls the funtion GetTexture to grab the Husky image.
		StartCoroutine((GetTexture()));
	}
	
	//Handles getting. 
	IEnumerator GetTexture()
	{
		//Instantiate a Texture2D.
		Texture2D tex;
		
		//Gives the dimensions and format of the texture.
		tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
		
		//A WWW instance is given access to a website, in this case the link to the ROSbridge 
		//video_websocket_server image.
		WWW www = new WWW(url);
		
		//Pause/wait for the site to respond with the image
		yield return www;
		
		//Loads the ROSbridge video_websocket_server husky image into the Textture2D 'tex'
		www.LoadImageIntoTexture(tex);
		
		/*
		 //Grabs the image loaded in 'tex' and renders it for visualization in the Unity GameObject that 
		 //the script is attached to. (allows for visualization)
		*/
		GetComponent<Renderer>().material.mainTexture = tex;
	}
}
