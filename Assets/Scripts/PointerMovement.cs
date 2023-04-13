using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerMovement : MonoBehaviour
{
    public GameObject hourPointer;
    public GameObject minutePointer;
    public GameObject forbidden;

    private int hourMove;
    private int minuteMove;

    // original 
    private Vector3 oriHourRotate = new Vector3(0,0,0);
    private Vector3 oriMinRotate = new Vector3(0,0,0);
    private Vector2 forbidOri = new Vector2(0, -9.5f);
    private Vector2 forbidTo = new Vector2(0, 0);
    private Vector3 hourRotate;
    private Vector3 minuteRotate;
    
    public void ClockAnimate(int level)
    {
        LevelConverter(level);
        // it will be faster for high level
        hourPointer.transform.Rotate(hourRotate,Time.deltaTime*40*level);
        minutePointer.transform.Rotate(minuteRotate,Time.deltaTime*20*level);
    }
    private void LevelConverter(int level)
    {
        hourMove = -level * 6;
        minuteMove = -level * 72;
        hourRotate = new Vector3(0f, 0f, hourMove);
        minuteRotate = new Vector3(0f, 0f, minuteMove);
    }
    
    // forbid appears
    public void ForbidAppearAni()
    {
        forbidden.transform.position = Vector2.MoveTowards(forbidden.transform.position, forbidTo, Time.deltaTime*10);
    }
    
    // forbid disappears
    public void ForbidDisappearAni()
    {
        forbidden.transform.position = Vector2.MoveTowards(forbidden.transform.position, forbidOri, Time.deltaTime*10);
    }
    
    // clock resume
    public void ClockResumeAni(int level)
    {
        // reversely rotate the clock
        LevelConverter(-level);
        // it will be faster for high level
        hourPointer.transform.Rotate(hourRotate,Time.deltaTime*40*level);
        minutePointer.transform.Rotate(minuteRotate,Time.deltaTime*20*level);
    }
}
