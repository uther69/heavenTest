using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "listeDemon")]



public  class listeDemon : ScriptableObject {

	
	public string Name;
	public int Life;
	
	
	public List<bluePrint_Demon> itemList;
	
	//public listeDemon (List<bluePrint_Demon> itemList)
	//{
	//	this.itemList = itemList;
	//}
	
	
	
	
	
	
}


//Example

//public class CameraLocationHolder : ScriptableObject {
	
//	public List<CameraLocation> content;
//	public CameraLocationHolder(List content)
//	{
//		this.content = content;
//	}
//}