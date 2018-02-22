using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class archer : MonoBehaviour {

	
	public  GameObject target;
	
	public GameObject fleche;
	
	
	
	// Listing to event 
	
	void OnEnable()
	
	{sensor.HITCall += ID_Shooting;}
	
	void OnDisable()
	
	{sensor.HITCall -= ID_Shooting;}
	
	
	
	 void Awake()
	{
	
		
		fleche = Resources.Load("PREFABS/fleche") as GameObject;
		
		
	}
	
	
	
	void ID_Shooting()
	
	{
		
		// Mon sensor a t'il emis cette alerte  > Check bool
		
		bool testEmitting = gameObject.GetComponentInChildren<sensor>().Emitting;
		
		if (testEmitting) {
			
			StartCoroutine(Repeat_shooting());
		
			
			// methode d'efficacité  : la fréquence de poursuite // 
		}
		
	}
	
	
	
	IEnumerator Repeat_shooting(){
		
		
		InvokeRepeating("Shooting",0f,1.5f);
		
		
		yield return new WaitForSeconds(20f);
		CancelInvoke();
		
	}
	
	
	void Shooting(){
		
		
		Instantiate (fleche,transform.position,transform.rotation);
		
		
	}
	
	

}
