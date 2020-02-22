using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogFollow : SimpleFollow
{
    protected AnimatorController thisAnim;
    protected StateMachine thisStateMachine;

    public override void Awake()
    {
        base.Awake();
        thisAnim = GetComponent<AnimatorController>();
        thisStateMachine = GetComponent<StateMachine>();
    }

    protected override void FixedUpdate()
    {
        targetDistance = Vector3.Distance(transform.position, target.position);
        if (targetDistance < chaseRadius && targetDistance > attackRadius)
        {
            if (thisStateMachine.myState != GenericState.stun || thisStateMachine.myState != GenericState.dead)
            {
                thisAnim.SetAnimParameter("wakeUp", true);
                Vector2 temp = (Vector2)(target.position - transform.position);
                thisAnim.changeAnim(temp - (Vector2)transform.position);
                Motion(temp);
            }
        }
        else if(Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            Vector2 temp = Vector2.zero;
            Motion(temp);
            thisAnim.SetAnimParameter("wakeUp", false);
        }
    }
}
