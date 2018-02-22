using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stockBuild : MonoBehaviour {
	
	
	
	
	
	public static GameObject[] stock;
	
	
	
	
	// Use this for initialization
	
	void Awake () {
		
		
		stock = GameObject.FindGameObjectsWithTag("block");
		
		print (stock);
		
		
		
		foreach (GameObject item in stock)
		
		{
			
			
			print(item.name);
			
			
			
			
			
			
			
		}
	
	}
	
	
	
	
	// Update is called once per frame
	void Update () {
		
	}
}
