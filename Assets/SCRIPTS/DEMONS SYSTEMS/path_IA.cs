using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class path_IA : MonoBehaviour {

	
	
	public List<GameObject> myPaths = new List<GameObject>();
	
	GameObject currentPath;
	
	public GameObject target;
	
	
	// Listing to event 
	
	void OnEnable()
	
	{sensor.HITCall += ID_Hunting;}
	
	void OnDisable()
	
	{sensor.HITCall -= ID_Hunting;}
	
	
	
	
	void Awake () {
		
		//target = GameObject.FindWithTag("target");
		
		target= new GameObject();
		
		target.name  ="target";
		
		
		currentPath = Instantiate(myPaths[0],transform.position,Quaternion.identity );
		
		
		// on passe au Path manager et à la propulsion ce Gameobject et l'objet target
		
		currentPath.GetComponent<path_manager>().myDemon=gameObject;
		
		
		currentPath.GetComponent<path_manager>().target=target;
		
		
		gameObject.GetComponent<propulsion>().target=target;
		
		
		
	}
		
	
	
	void stopPath(){
		
		
		currentPath.GetComponent<path_manager>().myDemon=gameObject;		
		
		
	}
	
	
	
	void ID_Hunting()
	
	{
		
		// Mon sensor a t'il emis cette alerte  > Check bool
		
		bool testEmitting = gameObject.GetComponentInChildren<sensor>().Emitting;
		
		if (testEmitting) {
			
			currentPath.SetActive(false);
			
			
			
			// methode d'efficacité  : la fréquence de poursuite // 
			
			
			StartCoroutine(trackUpdate());
			
			
			
		}
		
	
	}
	
	
	IEnumerator trackUpdate(){
		
		
		
		InvokeRepeating("tracking", 0f, 0.6f);					//objet sélectionné par le sensor TEMP : 1er objet  dans  liste

		yield return new WaitForSeconds(10);    				// après le délai l'instruction qui suit est exécutée
		
		
		CancelInvoke("tracking");   							// stoppe tracking
		
		currentPath.SetActive(true);							// activation du path courant
		
		gameObject.GetComponentInChildren<sensor>().ObjectDetected.Clear(); // on vide la table des objets detectés
	}
	
	
	
	
	void tracking(){
		
		//Debug.Log("TRACK");
		
		
		
		GameObject myTarget = gameObject.GetComponentInChildren<sensor>().ObjectDetected[0];
		
		if (myTarget){
		
		target.transform.position = myTarget.transform.position;
			
		}
		
		
		
	}
	
	
}







