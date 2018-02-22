using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MISSILE_PROPULSION : MonoBehaviour {

    private float speed = 60f;



	// Use this for initialization
	void Start () {

        StartCoroutine(selfDestruction());
		
	}
	
	// Update is called once per frame
	void Update () {
        

        transform.Translate(Vector3.forward * Time.deltaTime*speed);
		
	}


    IEnumerator selfDestruction()
    {
      
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }


    private void OnTriggerEnter(Collider other)
    {

        other.gameObject.SetActive(false);
    }


}
