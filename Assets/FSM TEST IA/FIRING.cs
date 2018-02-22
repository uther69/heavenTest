using UnityEngine;
using System.Collections;

public class FIRING : MonoBehaviour
{

    public GameObject myMissile;


    public float stateTimeElapsed ;


    public float duration = 6f;

    public float fireRate = 2f;

    private float nextFireTime;
   


        //public void Launch(Transform myPosition)

        //{
        //    stateTimeElapsed += Time.deltaTime;

        //    Debug.Log("coutdown " + stateTimeElapsed);

        //    return (stateTimeElapsed >= duration);

          

        //if (myMissile)

        //    {
        //        Instantiate(myMissile, myPosition.position, Quaternion.identity);

        //        stateTimeElapsed = 0;
        //    }

        //}



    public void Launch(Transform myPosition, Quaternion myRotation)
    {
        if (Time.time > nextFireTime)
       
        {
            nextFireTime = Time.time + fireRate;
            // Set the fired flag so only Fire is only called once.


          
            if (myMissile)

            {
                Instantiate(myMissile, myPosition.position, myRotation);

                stateTimeElapsed = 0;
            }





        }

    }








    }
  



