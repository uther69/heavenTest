using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/State")]


// contient les listes d'actions à executer, ainsi que les conditions 
// enclenchant les changements d'états. Execute les actions et les test décisions durant updateState
// qui est executé dans le Main body.

public class STATE : ScriptableObject
{

    public ACTION[] actions;
  
    // public Transition[] transitions;

    public Transition[] transitions;




    public Color sceneGizmoColor = Color.grey;



    public void UpdateState(ENNEMY_BODY body)
    {
        DoActions(body);
      CheckTransitions(body);
    }




    private void DoActions(ENNEMY_BODY body)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Act(body);

        }





    }

    private void CheckTransitions(ENNEMY_BODY body)
    {
        for (int i = 0; i < transitions.Length; i++)
        {
            bool decisionSucceeded = transitions[i].decision.Decide(body);

            if (decisionSucceeded)
            {
                body.TransitionToState(transitions[i].trueState);
            }
            else
            {
                body.TransitionToState(transitions[i].falseState);
            }
        }
    }



}