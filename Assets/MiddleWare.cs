using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;

public class MiddleWare : MonoBehaviour
{
    // public int count = 0;
    public string sendStr ="";
    public bool recvFlag = false;
    public string recvStr;
    [SerializeField] TextMeshProUGUI recvText;
    [SerializeField] Client _client;
    public VoiceManagement voicemanage;
    
    
    public void Updaterecv(string incomeStr)
    {
        if (recvFlag)
        {
            if (!incomeStr.Equals(""))
            {
                //count++;
                recvText.text = "Lola is speaking...";
                recvStr = incomeStr;
                int id = CompareString(recvStr)-1;
                try
                {
                    Debug.Log(id);
                    voicemanage.VoiceManage(id);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    recvText.text = "Researcher: please restart";
                    throw;
                }
            }
        }

        recvFlag = false;

    }

    public int CompareString(string input)
    {
        switch (input)
        {
            case "1.1":
                Console.WriteLine("1.1 receive");
                return 1;
            case "1.2":
                return 2;
            case "1.3":
                return 3;
            case "1.4":
                return 4;
            case "1.5":
                return 5;
            case "2.1":
                return 6;
            case "2.2":
                return 7;
            case "2.3":
                return 8;
            case "2.4":
                return 9;
            case "2.5":
                return 10;
            case "3.1":
                return 11;
            case "3.2":
                return 12;
            case "3.3":
                return 13;
            case "3.4":
                return 14;
            case "3.5":
                return 15;
        }

        return 0;
        // error return 0
    }
    public string ExtractRepeatingSubstring(string input, int repeatCount)
    {
        int length = input.Length / repeatCount;
        string substring = input.Substring(0, length);
        
        return substring;
    }
}
