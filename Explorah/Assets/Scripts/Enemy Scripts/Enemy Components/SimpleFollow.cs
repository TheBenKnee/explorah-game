using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFollow : Movement
{

    [SerializeField] protected string targetTag;
    protected Transform target;
    [SerializeField] protected float chaseRadius;
    [SerializeField] protected float attackRadius;
    protected float targetDistance;

    // Start is called before the first frame update
    public override void Awake()
    {
        base.Awake();
        target = GameObject.FindGameObjectWithTag(targetTag).GetComponent<Transform>();
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        targetDistance = Vector3.Distance(transform.position, target.position);
        if (targetDistance < chaseRadius && targetDistance > attackRadius)
        {
            Vector2 temp = (Vector2)(target.position - transform.position);
            Motion(temp);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }
} 