using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newPropulsion : MonoBehaviour {
	
	
	
	public float dampRotation = 0.5f;
	
	float dampAvoid = 80f;
	
	public float speed = 6f;
	
	float detectionDistance  = 5f;
	
	float deltaSpace =2f;
	
	 float myRotation;
	
	public enum Boussole {nord,sud,est,ouest};
	
	public Boussole myBoussole ;
	
	public LayerMask mask ;
	
	public GameObject target ;

    public Vector3 Offset;

	
	RaycastHit hit;

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	
	void Update () {
		
		Move();

        Avoid_Wall();

		Orientation();
		
	}
	
	
	void Turn(){
		
		
		Vector3 Pos = target.transform.position  -transform.position;
		Quaternion rotation = Quaternion.LookRotation(Pos);
		transform.rotation = Quaternion.Slerp(transform.rotation,rotation,dampRotation*Time.deltaTime);



      
}
	
	
	void Move(){
		
		transform.position += transform.forward *Time.deltaTime * speed;
	}
	
	
	void Orientation(){
		
		
		  myRotation = transform.eulerAngles.y;
		
		//	Debug.Log ("Boussole  "+ myBoussole + "ROTATION" + myRotation);
		
		
		if (myRotation>0f & myRotation <45f || myRotation>315f & myRotation <360f)
			
		{myBoussole = Boussole.nord;}
		
		else if (myRotation>46f & myRotation <135f)
			
		{myBoussole  = Boussole.est;}
		
		else if (myRotation>136f & myRotation <225f)
			
		{myBoussole  = Boussole.sud;}
		
			
		else if (myRotation>226f & myRotation <314f)
			
		{myBoussole  = Boussole.ouest;}
		
		
	}
	
		
    void Avoid_Wall(){
		
		
		
		
		 Offset= Vector3.zero;
		
		Vector3 OffsetV = Vector3.zero;
		

		Vector3 Left = transform.position - transform.right*deltaSpace;
		Vector3 Right = transform.position + transform.right*deltaSpace;
		Vector3 Up = transform.position + transform.up*deltaSpace;
		Vector3 Down = transform.position - transform.up*deltaSpace;


        Vector3 Center = transform.position;
		
		
		Debug.DrawRay(Center,transform.forward*detectionDistance,Color.cyan);
		//Debug.DrawRay(Right,transform.forward*detectionDistance,Color.cyan);
		//Debug.DrawRay(Up,transform.forward*detectionDistance,Color.cyan);
		//Debug.DrawRay(Down,transform.forward*detectionDistance,Color.cyan);
		

       // ---------------------------EVITEMENT HORIZONTAL POUR LA TOUR---------------------------//
		
		
        if (Physics.SphereCast(Center,5f,transform.forward,out hit,detectionDistance,mask))


          

		{

            if (myBoussole == Boussole.nord)

            {

                if (hit.point.x < hit.transform.position.x)


                { Offset += Vector3.down; Debug.Log("LEFT CORNER"); }


                else { Offset += Vector3.up; }


            }

            //---------------------------------------------------------------

            else if (myBoussole == Boussole.sud)

            {

                if (hit.point.x < hit.transform.position.x)

                { Offset += Vector3.up; } else { Offset += Vector3.down; }
            }

				
			
			
            //---------------------------------------------------------------
			else if (myBoussole == Boussole.est)
				
				
				
			{

                if( hit.point.z < hit.transform.position.z)
				
                {Offset +=Vector3.up;} else {Offset +=Vector3.down;}
			
			}	
            //---------------------------------------------------------------
			
			else if (myBoussole == Boussole.ouest)
				
				
				
			{if (hit.point.z < hit.transform.position.z)


                { Offset += Vector3.down; } else { Offset += Vector3.up; }
				
			}	
			
            // DEVIATION VERTICALE POUR UN PONT
			
				
		
			
		}
		
		
					
        // si la sphereCast active = OFFSET non nul > on pivot
		
		if (Offset != Vector3.zero)
			
		transform.Rotate(Offset *dampAvoid*Time.deltaTime);
			
		
        //  si la sphereCast  = 0 / pas detection > fonction TURN pour le pathfinding
		
		else if (Offset == Vector3.zero)
		
		Turn();
			
		
		}	



    void OnGUI()

    {
        GUILayout.TextArea(myBoussole.ToString());


        GUILayout.TextArea(Offset.ToString());

    }

   

	
// END CLASS
	
}
