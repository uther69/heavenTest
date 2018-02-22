using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayCastTest : MonoBehaviour {


    public GameObject Path_Target;
    public GameObject Avoid_Target;

    private GameObject current_Target;

    public float dampRotation = 0.5f;

    private float detectionDistance = 15f;

    public LayerMask mask = 9;

   public  Vector3 m_Min, m_Max, m_Center, m_Extents;

    float m_Size;

    RaycastHit hit;

    public float myHitX;


    private Vector3 newTarget;


    public float speed = 1f;


	// Use this for initialization
	
    void Start () {


        current_Target = Path_Target;


        InvokeRepeating("evitement",3f,1f);
		
	}
	
	

    // Update is called once per frame

	void Update () {

        Move();


        Turn(current_Target);


    } //update





    void Turn(GameObject myTarget)
    {


        Vector3 Pos = myTarget.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(Pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, dampRotation * Time.deltaTime);

        print("target pos"+Pos); 

        Debug.Log("TURNING");

    }




    void Move()
    {

        transform.position += transform.forward * Time.deltaTime * speed;
    }






    void evitement()

    {

        #region DETECTION OBSTACLE TEMPORAIRE

        Physics.Raycast(transform.position, transform.forward, out hit, detectionDistance,mask);

        Debug.DrawRay(transform.position, transform.forward * detectionDistance, Color.cyan);


        myHitX = hit.point.x;



        if (hit.collider)

        {
            m_Center = hit.collider.bounds.center;

            m_Extents = hit.collider.bounds.extents;
           
            m_Min = hit.collider.bounds.min;
            m_Max = hit.collider.bounds.max;


            if (myHitX > m_Min.x && myHitX < m_Center.x)

            {

                //  Debug.Log("POSITON LEFT ABSOLU");

                newTarget.x = m_Min.x - hit.collider.bounds.extents.x;
                newTarget.z = m_Center.z;
                Avoid_Target.transform.position = new Vector3(newTarget.x, transform.position.y, newTarget.z);



                current_Target = Avoid_Target;


            }

            else


            {
                //  TO TO = Debug.Log("POSITON RIGHT ABSOLU");


            }


        }

        else


        {

            Debug.Log("NO HIT");

            // SORTIE DE L'EVITEMENT DOBSTACLE 
            //EXCUTION DE LA POURSUITE DU PATH "NORMAL", IA ATTAQUE / PATROL / 
            current_Target = Path_Target;


        }

    }
    #endregion




        void OnDrawGizmos()
    {

        Gizmos.color = Color.cyan;
        Gizmos.DrawCube(newTarget, new Vector3(1, 1, 1));


    }


}
