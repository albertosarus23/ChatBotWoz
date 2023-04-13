using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Management : MonoBehaviour
{
    public GameObject smallLeft;
    public GameObject smallRight;
    public GameObject bigRight;

    // method to make UI box active
    public void SetSmallLeftactive()
    {
        smallLeft.SetActive(true);
    }
    
    public void SetSmallRightactive()
    {
        smallRight.SetActive(true);
    }
    
    public void SetBigRightactive()
    {
        bigRight.SetActive(true);
    }
    
    // method to make UI box deactive
    
    public void DeactiveSmallLeft()
    {
        smallLeft.SetActive(false);
    }
    
    public void DeactiveSmallRight()
    {
        smallRight.SetActive(false);
    }
    
    public void DeactiveBigRight()
    {
        bigRight.SetActive(false);
    }
}
