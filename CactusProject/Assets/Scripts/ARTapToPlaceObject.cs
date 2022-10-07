using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlaceObject : MonoBehaviour
{
	
	public GameObject gameObjectToInstantiate;
	
	public static List<GameObject> spawnedObjects = new List<GameObject>();
	private ARRaycastManager _arRaycastManager;
	private Vector2 touchPosition;
	
	static List<ARRaycastHit> hits = new List<ARRaycastHit>();
	
    private void Awake()
    {
		 _arRaycastManager = GetComponent<ARRaycastManager>();
    }

	 bool TryGetTouch(out Touch touch){
		 if(Input.touchCount > 0){
			 touch = Input.GetTouch(0);
			 return true;
		 }
		 
		 touch = default;
		 return false;
	 }
	 
    void Update()
    {
		 if(!TryGetTouch(out Touch touch))
			 return;

		 if (touch.phase == TouchPhase.Began)
		 {
			 var touchPosition = touch.position;
			 if(_arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon)){
			 
				 var hitPose = hits[0].pose;
				 GameObject newCactus = Instantiate(gameObjectToInstantiate, hitPose.position, hitPose.rotation);
				 newCactus.transform.Rotate(new Vector3(0, 180, 0));
				 spawnedObjects.Add(newCactus);
				 
			 }
		 }
    }
	 
}
