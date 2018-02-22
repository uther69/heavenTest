using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sensor : MonoBehaviour {

	
	public delegate void HIT();											// Déclaration de l'event HITCALL
	public static event HIT HITCall ;
	
	public bool Emitting ;												// check this instance is sending event
	

	float GizmoRadius;
	

	bluePrint_Demon Data;												// La classe qui gère les caractéristiques
	
	SphereCollider sensorSphere ;										// le collider généré (radius blueprint)
	
	public List<GameObject> ObjectDetected = new List<GameObject> ();	// liste des object detectés
	
	public GameObject otherObject;
	
	
	void Start()
	
	{
		
		
		
		bool Emitting  = false;												
	
		
		Data = gameObject.GetComponentInParent<demon>().Data ;			 // Get data  que le component Démon à loadé.
		
		
		AddSphere();
		
	
	}
	
	
	void AddSphere(){
		
	sensorSphere = gameObject.AddComponent<SphereCollider>() as SphereCollider;
	sensorSphere.radius = Data.sensorRadius;
	sensorSphere.isTrigger= true;
	sensorSphere.center = new Vector3(0,0,0);	
		
	GizmoRadius = Data.sensorRadius;
		
		print("SENSOR RADIUS" + Data.sensorRadius);
		
	}
	
	

	void OnTriggerEnter(Collider other)
	{

		otherObject = other.gameObject;
		
		//Debug.Log("TRIGGER ENTER");

		
		
			
		if (other.gameObject.tag == "angel")			 // TEMP : accès a la liste target Blueprint
			
			if (ObjectDetected.Count == 0)				// la liste est vide ? 
			
			{ ObjectDetected.Add (otherObject);
			
				Emitting = true;
		
				HITCall();								// -- CALL HIT EVENT for OTHER COMPONENTS
				
			}							
			
			
		else
			
			compareStock();
			
		
		}
		
	
	
	void compareStock(){
		
		print("compareStock" + ObjectDetected.Count);
		
		for (int i = 0; i < ObjectDetected.Count; i++) {
			
			
			
			if (ObjectDetected[i] == null)
				
			{
				
				print ("ADD OBJECT");
				
				ObjectDetected.Add (otherObject);
				
				Emitting = true;
				
				HITCall(); // -- CALL HIT EVENT for OTHER COMPONENTS
				
				
				break;	
			}
			
			
			else
			
				if (otherObject.name == ObjectDetected[i].name)
				
					print ("FIND DUPLICATE");
				
					break;
			
			}
			
			
		}
		

	
	
	
/*
	void check_duplicate()
	{
		
		print("compareStock");

		foreach (GameObject stockT in ObjectDetected)
		{
			print ("OBJECT name"+ otherObject.name    + " STOCK" + stockT.name);



			if (otherObject.name == stockT.name) // l'objet n'est t'il pas deja dans la table

				print ("IDE THE SAME" + stockT.GetInstanceID());

			else 

			{		

				print ("OBJET ADDED");

				ObjectDetected.Add (otherObject);


				// TRIGGER EVENT HITCALL / enregistrement de l'id dans la liste ID MANAGER -- TRIG EVENT


				Emitting = true;

				HITCall();

			
				// >>>> ENVOYER à path IA et ability 
				// autres traitements : choisir l'ennemi le moins fort, celui sur lequel on a des bonus, etc. //

			}

		}





	}



*/

		
		
	void OnTriggerExit(Collider other)
	{
		
		// on retire l'objet detecté de la liste des objets détectés
		
		///	ObjectDetected.Remove(other.gameObject);
		
		
		//	Debug.Log ("EXIT");
		
		
		
	}
	
	
	
	
	/*
	void OnTriggerEnter(Collider other)
	{

		//	Debug.Log ("COLLIDE");


		//GameObject currentCollider = other.gameObject;

		if (other.gameObject.CompareTag("demon")){

		ColliderObject.Add (other.gameObject);

			other.gameObject.GetComponent<HitReaction>().SpawnExplosion();
			
			
			
			foreach (GameObject GO in ColliderObject) {

				//Debug.Log ("TARGET object"+GO.name);
				
			}
			
			
		}
		
		
			

	}
	
	*/
	
	
	
	
	void OnDrawGizmos() {
		
	
		Gizmos.color = new Color(1f,0f,0f,0.25f);
		
		Gizmos.DrawSphere(transform.position,GizmoRadius);
	}
	
	
	

	}













