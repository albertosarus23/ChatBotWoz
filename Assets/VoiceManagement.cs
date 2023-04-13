using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceManagement : MonoBehaviour
{
    [SerializeField] private AudioSource asOnPlay;
    // [SerializeField] private AudioSource _audio1;

    public List<AudioClip> _aduioList = new List<AudioClip>();

    void Start()
    {
        // audioSource = _audio1;
    }

    public void StopPlaying()
    {
        // if researcher presses 's' key, then the sound playing will stop
        if (Input.GetKeyDown(KeyCode.S))
        {
            asOnPlay.Stop();
        }
    }
    
    public void RePlaying()
    {
        // if researcher presses 'r' key, then the sound playing will play again
        if (Input.GetKeyDown(KeyCode.R))
        {
            asOnPlay.Stop();
        }
    }
    public void PausePlaying()
    {
        // if researcher presses 'p' key, then the sound playing will pause
        if (Input.GetKeyDown(KeyCode.P))
        {
            asOnPlay.Pause();
        }
    }
    
    public void VoiceManage(int num)
    {
        if (!(num >= _aduioList.Count))
        {
            asOnPlay.clip = _aduioList[num];
            asOnPlay.Play();
        }
    }

    void Update()
    {
        StopPlaying();
        PausePlaying();
        RePlaying();
    }
}
