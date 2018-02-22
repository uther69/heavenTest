using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class demon:MonoBehaviour {

	
	public string myName; 
	

	
	// accès a liste des démons (a mettre dans l'inspecteur)
	
	public listeDemon myDemons;
	 
	public bluePrint_Demon Data;  
	
	
	
	
	
	void Awake () {
		
		
		print("DEMON AWAKE");
		
		// parsing de la table des démons / trouver l'item = name prefab > accès aux data de la librairie
		
	
		for(int f = 0; f < myDemons.itemList.Count; f++)
		{
			//Debug.Log (myDemons.itemList[f].DemonName);
			
			if (myDemons.itemList[f].DemonName == myName)
				
			{
				
				Data = myDemons.itemList[f];
				
				//	Debug.Log("FOUNDED" + f + "  name  "+Data.TargetList[0].TagName );
				
				
				break;
				
			}
			
		}
		
		// création des components de liste Ability 
		
	
		for(int f = 0; f < Data.ability.Count; f++)
		
		{
			
			if (Data.ability[f] != null)
				
			{
				
				
				
				string myAbility = Data.ability[f];
				
				//Debug.Log("FOUNDED" + compoName );
				
				
				gameObject.AddComponent(System.Type.GetType(myAbility)); 
						
			}
			
		}
		
	}
	

	// ----------------Calcul des dommages de points de vie------------------------ 
	
	
	public void hitDamage (int Damage)
	
	{

		Data.Life -= Damage; 

		//Debug.Log ("Newlife after been hited" + myAbility.Life);
		
		
		if (Data.Life <= 0)
		{
			
		
		Debug.Log ("KABOOM !!!!!");
		
		
		Instantiate (Data.explosion,transform.position,transform.rotation);
		
		
		// modification du score en appelant la fonction addscore du score manager
		
		//myscoremanager.addScore(addScore);
			
		scoreManager.instance.addScore(Data.Score);
			
			
		}
		
		
		
		
		
		
	}
	

	


	

}
