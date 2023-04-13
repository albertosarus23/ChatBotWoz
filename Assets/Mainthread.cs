using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mainthread : MonoBehaviour
{
    public bool level1;
    // this level2 means is player able to access level 2
    public bool level2;
    [SerializeField]
    private Player_progress[] progress;

    // Update is called once per frame
    void Update()
    {
        // real time retrive if the player has reached level 2
        try
        {
            // find all the Player progress
            progress = GameObject.Find("PlayerProgress").GetComponents<Player_progress>();
            if (progress.Length == 1)
            {
                level2 = progress[0].progress[0];
            }
            else
            {
                level2 = progress[1].progress[0];
                print(2);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
