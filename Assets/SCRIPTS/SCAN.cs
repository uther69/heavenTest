using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCAN : MonoBehaviour {
	
	
	
	GameObject item;
	
	GameObject[]stock;
	
	Vector3 Direction;
	
	public GameObject Dummy;

	// Use this for initialization
	
	void Start () {
		
		
		
		stock = GameObject.FindGameObjectsWithTag("block");
		
		
		
		foreach ( GameObject item in stock)
		
		{
			
			checkStock(item);
			
		}
		
		
		
	}
	
	// Update is called once per frame
	
	void Update () {
		
		Vector3 Direction  = Dummy.transform.position - transform.position;
		
		Debug.DrawRay(transform.position,Direction,Color.red);
		
		
		
	}




	void checkStock(GameObject item){
	
	if (item.tag=="block")
		
		
	{
		
		float distance = Vector3.Distance(Dummy.transform.position,transform.position);
		
		print ("BLOCK FOUNDED" +  distance);
		
		
		
		
	}
	
	
	
}
	
	
	
};