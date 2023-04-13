using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockAnimate : MonoBehaviour
{
    public PointerMovement pointerMovement;
    public bool level1 = false;
    public bool level2 = false;
    public bool forbid = false;
    public bool resume = false;
    public bool level2pressed = false;

    // Update is called once per frame
    void Update()
    {
        if (level1)
        {
            // invoke 
            pointerMovement.ClockAnimate(1);
            StartCoroutine(WaitForSeconds());
        }

        if (level2)
        {
            pointerMovement.ClockAnimate(2);
            level2pressed = true;
            StartCoroutine(WaitForSeconds());
        }

        if (forbid)
        {
            // call the forbid animation
            forbidAnimate();
        }

        if (resume)
        {
            if (level2pressed)
            {
                pointerMovement.ClockResumeAni(2);
            }
            else
            {
                pointerMovement.ClockResumeAni(1);
            }
           
        }
    }
    
    void forbidAnimate()
    {
        StartCoroutine(signAppear());
    }
    
    IEnumerator WaitForSeconds()
    {
        // terminate the process, clear all boolean
        yield return new WaitForSeconds(2f);
        level2 = false;
    }
    
    IEnumerator WaitFor1Second()
    {
        yield return new WaitForSeconds(1f);
        forbid = false;
        resume = false;
        level2pressed = false;
    }

    IEnumerator signAppear()
    {
        yield return new WaitForSeconds(.5f);
        pointerMovement.ForbidAppearAni();
        StartCoroutine(signDisappear());
    }

    IEnumerator signDisappear()
    {
        yield return new WaitForSeconds(2.5f);
        StopCoroutine(signAppear());
        yield return new WaitForSeconds(.5f);
        resume = true;
        pointerMovement.ForbidDisappearAni();
        StartCoroutine(WaitFor1Second());
    }

    
    
    
}
