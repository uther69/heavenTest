using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class path_manager : MonoBehaviour {
	
	
	public List<GameObject> nodeList ;
	
	//TE temp pour referencement target // A FINIR
	
	
	public GameObject myDemon;
	
	public float distanceNode;
	
	public bool pathActive;
	
	public GameObject target;
	
	int index;
	
	
	GameObject currentNode;
	
	
	void Awake()
	
	{
				
		
	}
	
	
	
	
	void OnEnable (){
		
		//reinitialisation de l'index quand l'objet sera enable
		
		Debug.Log("RE INITIALISATION");
		
		index = 0;
		
		Invoke ("initialisation",0f);
		
		
		//initialisation();
		
	}
	
	
	
	
	
	
	void initialisation(){
		
		
		pathActive = true;
		
		//transform.rotation = Quaternion.Euler(0,0,40);
		
		
		
		nodeList = new List<GameObject>();
		
		foreach (Transform child in transform)
		
		{
			
			nodeList.Add(child.gameObject);
			
			
		}
		
		
		
		currentNode = nodeList[0];
		
	//-initialisation du path
		
		index = 0;
		
		
		target.transform.position = currentNode.transform.position;
		
		print("position" + target.transform.position+"   "+currentNode.transform.position);
		
	}
	
	

	



	void nextNode()
	
	{
		
		if( index == nodeList.Count)
			
			
			index =0;
			
		else
		
			index +=1;
		
		
		currentNode = nodeList[index];
		target.transform.position = currentNode.transform.position;
	}
	
	
	void Update()
	
	{
		if (currentNode)
			
		{
		
		
		distanceNode = Vector3.Distance(myDemon.transform.position,currentNode.transform.position);
		
		if (distanceNode  < 9f)
			
		{	nextNode();
			
			//Debug.Log("NEXT NODE");
		}
		
			
			
		}
		
		
			
	}


	
	// Implement OnDrawGizmos if you want to draw gizmos that are also pickable and always drawn.
	protected void OnDrawGizmos()
	{
		
		for (int i = 0; i < nodeList.Count; i++) {
			
			
			int j  = nodeList.Count-1;
			
			
			
			if (i>0)
				
			{
				
				
				Debug.DrawLine(nodeList[i-1].transform.position,nodeList[i].transform.position,Color.green);	
					
					
			}	
			
			
				
				Debug.DrawLine(nodeList[j].transform.position,nodeList[0].transform.position,Color.green);	
				
				
			
		}
		
		
	}





	
	//private string textAreaString = "text area";
	
	//void OnGUI () {
		
	//	textAreaString = GUI.TextArea (new Rect (25, 25, 100, 30), textAreaString);
	//}
	
	
	
		
		
}
