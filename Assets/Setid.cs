using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setid : MonoBehaviour
{
    public VoiceManagement voiceManagement;
    public int id;

    public void Assignid()
    {
        voiceManagement.Setid(id);
    }
}
