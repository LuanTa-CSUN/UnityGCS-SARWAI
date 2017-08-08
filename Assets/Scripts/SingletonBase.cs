using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBase<T> : MonoBehaviour where T : MonoBehaviour {

	// Credit to: http://wiki.unity3d.com/index.php/Singleton
	private static T UI_Instance;

	private static object _lock = new object();

	public static T Instance
	{
		get
		{
			if (applicationIsQuitting) {
				Debug.LogWarning("[Singleton] Instance '"+ typeof(T) +
					"' already destroyed on application quit." +
					" Won't create again - returning null.");
				return null;
			}

			lock(_lock)
			{
				if (UI_Instance == null)
				{
					UI_Instance = (T) FindObjectOfType(typeof(T));

					if ( FindObjectsOfType(typeof(T)).Length > 1 )
					{
						Debug.LogError("[Singleton] Something went really wrong " +
							" - there should never be more than 1 singleton!" +
							" Reopening the scene might fix it.");
						return UI_Instance;
					}

					if (UI_Instance == null)
					{
						GameObject singletonPrefab = null;
						GameObject singleton = null;

						// Check if exists a singleton prefab on Resources Folder.
						// -- Prefab must have the same name as the Singleton SubClass
						singletonPrefab = (GameObject)Resources.Load(typeof(T).ToString(), typeof(GameObject));	

						// Create singleton as new or from prefab
						if (singletonPrefab != null) {
							singleton = Instantiate (singletonPrefab);
							UI_Instance = singleton.GetComponent<T> ();
						} else {
							singleton = new GameObject();
							UI_Instance = singleton.AddComponent<T> ();
						}
						singleton.name = "(singleton) "+ typeof(T).ToString();						
						DontDestroyOnLoad(singleton);

						Debug.Log("[Singleton] An instance of " + typeof(T) + 
							" is needed in the scene, so '" + singleton +
							"' was created with DontDestroyOnLoad.");
					} else {
						Debug.Log("[Singleton] Using instance already created: " +
							UI_Instance.gameObject.name);
					}
				}

				return UI_Instance;
			}
		}
	}

	private static bool applicationIsQuitting = false;
	/// <summary>
	/// When Unity quits, it destroys objects in a random order.
	/// In principle, a Singleton is only destroyed when application quits.
	/// If any script calls Instance after it have been destroyed, 
	///   it will create a buggy ghost object that will stay on the Editor scene
	///   even after stopping playing the Application. Really bad!
	/// So, this was made to be sure we're not creating that buggy ghost object.
	/// </summary>
	public void OnDestroy () {
		applicationIsQuitting = true;
	}
}
