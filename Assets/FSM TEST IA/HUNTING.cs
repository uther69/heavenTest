using UnityEngine;
using System.Collections;


[CreateAssetMenu(menuName = "PluggableAI/HUNTING")]


public class HUNTING : ACTION
{

    private Quaternion myRotation;


    public override void Act (ENNEMY_BODY body)
    {


        Debug.Log("RUN TEST HUNTING");


       

        body.firing.Launch(body.transform, body.transform.rotation);


       


    }










    //public IEnumerator Tracking()

    //{
    //    while (hunt_target)

    //    {
    //        target.transform.position = hunt_target.transform.position;

    //        yield return null;

    //    }

    //}


  


}




