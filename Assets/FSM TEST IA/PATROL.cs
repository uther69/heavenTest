using UnityEngine;
using System.Collections;


[CreateAssetMenu(menuName = "PluggableAI/PATROL")]



public class PATROL : ACTION
{


    public override void Act(ENNEMY_BODY body)
    {

        body.target = body.GOtarget.transform;

         Debug.Log("RUN TEST PATROL");


      


    }


}




