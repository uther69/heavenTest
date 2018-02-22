using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fleche : MonoBehaviour {

	
	float speed =160f;
	
	
	public GameObject myExplosion ; 
	
	
	
	
	
	
	
	// Update is called once per frame
	void Update () {
		
		
		transform.Translate(Vector3.forward * Time.deltaTime*speed);
		Destroy(gameObject, 5);
	
	}
	
	
	
	//detection des ennemis //--------
	
	void OnTriggerEnter(Collider other) {
		
		
		if (other.gameObject.CompareTag("angel"))
		{
			
			
			Instantiate(myExplosion,other.gameObject.transform.position,other.gameObject.transform.rotation);
			
			Destroy(other.gameObject,0.1f);
	}
	
	
	
}


}
