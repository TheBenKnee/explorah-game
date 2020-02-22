using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : Damage
{

    [Header("Projectile Variables")]
    public GameObject projectile;
    public float fireDelay;
    private float fireDelaySeconds;
    private bool canFire = true;

    [Header("Target Variables")]
    [SerializeField] private string targetTag;
    protected float targetDistance;
    private Transform target;
    [SerializeField] private float attackRadius;

    [Header("Components")]
    protected StateMachine thisStateMachine;
    protected AnimatorController thisAnim;

    // Start is called before the first frame update
    void Awake()
    {
        thisAnim = GetComponent<AnimatorController>();
        thisStateMachine = GetComponent<StateMachine>();
        target = GameObject.FindGameObjectWithTag(targetTag).GetComponent<Transform>();
    }

    private void Update()
    {
        if (canFire == false)
        {
            fireDelaySeconds -= Time.deltaTime;
            if (fireDelaySeconds <= 0)
            {
                canFire = true;
                fireDelaySeconds = fireDelay;
            }
        }
    }
    public void FixedUpdate()
    {
        targetDistance = Vector3.Distance(transform.position, target.position);
        if (targetDistance <= attackRadius)
        {
            if (thisStateMachine.myState != GenericState.stun || thisStateMachine.myState != GenericState.dead)
            {
                if (canFire)
                {
                    Vector3 tempVector = target.transform.position - transform.position;
                    GameObject current = Instantiate(projectile, transform.position, Quaternion.identity);
                    current.GetComponent<Projectile>().Launch(tempVector);
                    canFire = false;
                    thisStateMachine.ChangeState(GenericState.walk);
                    thisAnim.SetAnimParameter("wakeUp", true);
                }
            }
        }
        else if (Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            thisAnim.SetAnimParameter("wakeUp", false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
