using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : DamageOnContact
{

    [SerializeField] public string[] attackable;
    protected PlayerAttack thisDaddy;
    [SerializeField] protected bool hasDaddy;
    [SerializeField] protected bool isDaddy;

    void Awake()
    {
        if(hasDaddy)
        {
            thisDaddy = this.transform.parent.GetComponentInParent<PlayerAttack>();
            attackable = thisDaddy.attackable;
            damageAmount = thisDaddy.damageAmount;
        }
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if(!isDaddy)
        {
            for (int i = 0; i < attackable.Length; i++)
            {
                if (other.gameObject.CompareTag(attackable[i]))
                {
                    Health temp = other.gameObject.GetComponent<Health>();
                    if (temp)
                    {
                        ApplyDamage(temp, damageAmount);
                    }
                }
            }
        }
    }

}
