using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ID_manager : MonoBehaviour {

	
	
	
	public static List<int> ID_list = new List<int>();
	
	public static int ID_sended;
	
	
	void OnEnable()
	
	{sensor.HITCall += stockID;}
	
	void OnDisable()
	
	{sensor.HITCall -= stockID;}
	
	
	
	void stockID(){
		
		
		ID_list.Add(ID_sended);
		
		
		
		
	}
	
	public static void SupressID(int myID){
		
		
		ID_list.Remove(myID);
		
		
		
		
		
	}
	
	
}
