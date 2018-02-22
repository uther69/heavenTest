using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "PluggableAI/Actions/Patrol")]




public class PatrolAction : MonoBehaviour




{
   

    public  void Act(StateController controller)
    {
        Patrol(controller);
    }




    private void Patrol(StateController controller)
    {
      
        Debug.Log("Patrol");









    }
}