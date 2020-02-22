using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : LogFollow
{
    public Transform[] path;
    public int currentPoint;
    public Transform currentGoal;
    public float roundingDistance;

    protected override void FixedUpdate()
    {
        targetDistance = Vector3.Distance(transform.position, target.position);
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if (thisStateMachine.myState != GenericState.stun || thisStateMachine.myState != GenericState.dead)
            {
                Vector2 temp = (Vector2)(target.position - transform.position);
                thisAnim.changeAnim(temp);
                Motion(temp);    
            }
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            if (Vector3.Distance(transform.position, path[currentPoint].position) > roundingDistance)
            {
                Vector2 temp = (Vector2)(path[currentPoint].position - transform.position);
                thisAnim.changeAnim(temp);
                Motion(temp);
            }
            else
            {
                Vector2 temp = Vector2.zero;
                Motion(temp);
                ChangeGoal();
            }
        }
    }

    private void ChangeGoal()
    {
        if (currentPoint == path.Length - 1)
        {
            currentPoint = 0;
            currentGoal = path[0];
        }
        else
        {
            currentPoint++;
            currentGoal = path[currentPoint];
        }
    }
}