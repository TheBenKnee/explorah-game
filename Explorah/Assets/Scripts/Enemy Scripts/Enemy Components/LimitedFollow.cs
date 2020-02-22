using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitedFollow : LogFollow
{
    [SerializeField] private Collider2D boundary;

    protected override void FixedUpdate()
    {
        targetDistance = Vector3.Distance(transform.position, target.position);
        if (targetDistance < chaseRadius && targetDistance > attackRadius && boundary.bounds.Contains(target.transform.position))
        {
            thisAnim.SetAnimParameter("wakeUp", true);
            Vector2 temp = (Vector2)(target.position - transform.position);
            thisAnim.changeAnim(temp);
            Motion(temp);
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius || !boundary.bounds.Contains(target.transform.position))
        {
            Vector2 temp = Vector2.zero;
            Motion(temp);
            thisAnim.SetAnimParameter("wakeUp", false);
        }
    }
}
