using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ACTION : ScriptableObject
{
    public abstract void Act(ENNEMY_BODY body);
}