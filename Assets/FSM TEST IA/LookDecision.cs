using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Look")]
public class LookDecision : Decision
{

    public bool switchTemp;



    public override bool Decide(ENNEMY_BODY body)
    {
        bool targetVisible = Look(body);
        return targetVisible;
    }



    private bool Look(ENNEMY_BODY body)

    {


        RaycastHit hit;


        if (Physics.SphereCast(body.transform.position, 25f, body.transform.forward, out hit, body.lookRange))


        //// CHANGEMENT D'ETAT DU FSM PARENT / 

        {


            if (hit.collider.CompareTag("demon"))

            {
                Debug.Log("ATTACK this ENNEMY  " + hit.transform.gameObject.tag);

               // body.target.position = hit.point;


               body.target = hit.transform;

                return true;

            }

          
        }


        else


            Debug.Log(" PATROLLING");

        return false;


    }

}





