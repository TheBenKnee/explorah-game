using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    [Header("Animation Variable")]
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //Setup animator
        anim = GetComponent<Animator>();
    }

    //Function to smash the pot
    public void Smash()
    {
        //Begin pot breaking animation
        anim.SetBool("smash", true);
        //Begin actual pot breaking
        StartCoroutine(breakCo());
    }

    //Function to actually break the pot
    IEnumerator breakCo()
    {
        //Wait until the pot is broken (animation wise)
        yield return new WaitForSeconds(.3f);
        //Delete pot
        this.gameObject.SetActive(false);
    }
}
