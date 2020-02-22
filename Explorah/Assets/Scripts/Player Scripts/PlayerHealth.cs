using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] private FlashColor flash;
    [SerializeField] private FloatValue maxHealthValue;
    [SerializeField] private FloatValue currentHealthValue;
    [SerializeField] private Notification updateHeartsUI;
    [SerializeField] private GameObject deathEffect;
    private StateMachine thisStateMachine;

    private void Start()
    {
        thisStateMachine = this.transform.parent.GetComponent<StateMachine>();
        SetHealth((int)maxHealthValue.value);
        currentHealthValue.value = maxHealthValue.value;
        updateHeartsUI.Raise();
    }

    public override void Damage(int damage)
    {
        base.Damage(damage);
        currentHealthValue.value -= damage;
        updateHeartsUI.Raise();
        if(currentHealth > 0)
        {
            if (flash)
            {
                flash.StartFlash();
            }
        }
        else
        {
            Die();
        }
    }

    public void Die()
    {
        thisStateMachine.ChangeState(GenericState.dead);
        Instantiate(deathEffect, transform.position, transform.rotation);
        this.transform.parent.gameObject.SetActive(false);
    }

    public void increaseMaxHealth()
    {
        maxHealthValue.value++;
    }
}