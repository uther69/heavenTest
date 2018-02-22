using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

	// Use this for initialization

	public GameObject[] ennemyList;

	// une liste qui va stocker les ennemis générés

	List<GameObject> listEnnemy = new List<GameObject> ();

	public float waitInit = 1;

	public float waitSpawn = 1;


	void Start () {

		// on attend 5 sec.
		StartCoroutine (waiting());


	}
	IEnumerator waiting()
	{

		yield return new WaitForSeconds(waitInit);

		
		
	for (int i = 0; i < ennemyList.Length; i++)

	{

		if (ennemyList [i] != null) {

		

			//si l'ennemi n'est pas nul dans le tableau, on l'instancie

			GameObject EnnemyX = Instantiate (ennemyList [i], transform.position, Quaternion.identity) as GameObject;


				float posY = transform.position.y;

				posY += Random.Range (-2.0f, 2.0f);

				EnnemyX.transform.position = new Vector3(Random.Range(-5.0f, 5.0f),posY, Random.Range(-5.0f, 5.0f));

			
			
			
			// RECUPERER LE COMPOSANT RIGIDBODY DU PREFAB, ET AFFECTER UNE VELOCIT2

		//	Rigidbody body = EnnemyX.GetComponent(typeof(Rigidbody)) as Rigidbody;

			//body.velocity = transform.TransformDirection(Vector3.forward * 10);


				// STOCKER LES ENNEMIS INSTANCIES DANS UNE LISTES //

				listEnnemy.Add(EnnemyX) ;

			
			
			
				//foreach (GameObject GO in listEnnemy) {

				//Debug.Log ("list object"+GO.name);
				//}



		}

	//pause entre chaque instantiaton
			yield return new WaitForSeconds(waitSpawn);

	}

		
	
	 // loop dans le tableau public rempli directement dans l'inspecteur.




 
	
	
	}







	void Update () {
		
	}
}


