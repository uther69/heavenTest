using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public  class scoreManager : MonoBehaviour {
	
	
	public static scoreManager instance = null;
	
	public int  Score ;
	public GameObject ScoreObject;
	private  Text textScore ;
	

	
	
	// Réactualisatoin du score / méthode pas terrible car l'instantiation
	// de la classe scoremanager dans les prefabs ennemy obligent a trouver l'objet score text a chaque hit.
	
	
	void Awake (){
		
		
	 if (instance == null)
		 
		 instance = this;
		
	 else if (instance != this)
		 
		 Destroy (gameObject);
		
		
		}
	
	
	
	
	
	void UpdateScore () {
		
		ScoreObject = GameObject.Find("score");
		
		textScore = ScoreObject.GetComponent<Text>();
		
		textScore.text = "Score: " + Score;
		
		
	}
	
	
	public void addScore(int hitPoint)
	
	{
		
		Score += hitPoint;
		
		
		UpdateScore();
		
		
		Debug.Log ("SCORE "+Score);
		
		
		
	}
	
	
	
}
