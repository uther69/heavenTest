using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ENNEMY_BODY : MonoBehaviour


{

    // CARACTERISTIQUES PHYSIQUES ISSUS D'UN SCRIPTABLE OBJECT ------

    // OU MEME ASSET CREE DIRECTEMENT PA UN SCRIPTABLE OBJECT

   
    //Action en cours

    public STATE currentState;

    [HideInInspector] public float stateTimeElapsed;



    public EnemyStats ennemystats;

   
    public float lookRange;

    public Transform target;  // le composant transform de tracking , réactualisé selon les cas (ennemi ou GO target)
    public GameObject GOtarget; // le GameObject utilisé pour le tracking des paths

   
    public STATE remainState;


    public FIRING firing;




    void Awake()
   

    {
        firing = GetComponent<FIRING>();


        lookRange = ennemystats.lookRange;



  
    }


    void Update()
    {
      
        currentState.UpdateState(this);
    }


 

    public void TransitionToState(STATE nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
          
           // OnExitState();
        }
    }


    // Timer pour les actions avec délai type shooting 

   
    public bool CheckIfCountDownElapsed(float duration)
    {
        stateTimeElapsed += Time.deltaTime;

        Debug.Log("coutdown "  +stateTimeElapsed);
       
        return (stateTimeElapsed >= duration);
      
        OnExitState();

    }



    private void OnExitState()
    {
        stateTimeElapsed = 0;
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 25f);
    }





}
















       





