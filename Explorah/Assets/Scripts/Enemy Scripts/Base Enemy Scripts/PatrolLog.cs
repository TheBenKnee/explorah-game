using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolLog : Log
{
    public virtual void OnEnable()
    {
        base.OnEnable();
        anim.SetAnimParameter("wakeUp", true);
    }
}
