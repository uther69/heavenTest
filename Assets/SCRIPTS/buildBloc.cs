using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildBloc : MonoBehaviour {


	public float[] blocArray;




	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {




		
	}

	void OnMouseDown()


	{


		GameObject[] bobs = FindObjectsOfType(typeof(GameObject)) as GameObject[];

		foreach (GameObject bob in bobs) {

			Debug.Log (bob.name);

		}




		blocArray = new float[10];

		blocArray[1] =0.5f;
		Debug.Log ("bloc" + blocArray [1]);


		string nameRessource = "BLOC3";

		GameObject bloc = Resources.Load (nameRessource) as GameObject;



		GameObject currentBloc = Instantiate (bloc, transform.position, transform.rotation);

		Debug.Log ("mouse cliked");



	}




}
