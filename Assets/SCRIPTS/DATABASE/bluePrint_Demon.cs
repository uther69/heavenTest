using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]     

// caractéristiques des Démons

public class bluePrint_Demon 
{

		public string DemonName = "Demon name"; 
	
		public string genreTag;
	
		public int Life ;
	
		public float Speed;
	
		public float sensorRadius ;
	
		public float distanceLine ;
	
		public int maxHitContact ;
	
		public int maxHitDistance ;
	
		public GameObject explosion;
	
		public int Score ;
	
	public List<TargetClass> TargetList;
	
	// ou ranking des cibles. on attaque cible en dessous de soi. Avec des bonus et des exceptions.
	
	public List<BonusClass> bonusList;
	
	public List<string> ability;
	
		
		
	
	[System.Serializable]      

	public class TargetClass
	
	{	
		public string TagName;
		public int Damage;
		
	}
	
	[System.Serializable]      
	public class BonusClass
	
	{	
		public string ennemyName;
		public int Damage;
		
	}
	
	
	
	
	
	
}