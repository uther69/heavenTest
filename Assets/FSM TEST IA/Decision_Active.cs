using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/object_Active")]
public class Decision_Active : Decision
{




    public override bool Decide(ENNEMY_BODY body)
    {
        bool chaseTargetIsActive = body.target.gameObject.activeSelf;
        return chaseTargetIsActive;
    }



   
}





