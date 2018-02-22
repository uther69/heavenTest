using UnityEngine;
using System.Collections;

public class CoroutinesExample : MonoBehaviour
{
   
     enum State
    {

        PATROL,
        HUNTING,
        RUNNING

    }


    State state;



    void Start()


    {

        state = State.PATROL;

        StartCoroutine(MyCoroutine());

        Invoke("check", 5f);

    }



    IEnumerator MyCoroutine()

    {


        switch (state)

        {

            case State.PATROL:

                //Patrol();
                Debug.Log("NUMERATOR PATROL");


                break;

            case State.HUNTING:

                Debug.Log("NUMERATOR HUNTING");


                break;

            case State.RUNNING:

                Debug.Log("NUMERATOR RUNNING");
                //   Running();

                break;


        }

        yield return null;
    

        Debug.Log("coroutine ended");
           
    }


    void check()
    {

        Debug.Log(("check"));

        state = State.HUNTING;

       


    }













}