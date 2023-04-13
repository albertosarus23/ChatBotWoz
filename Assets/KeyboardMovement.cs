using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{
    [SerializeField] bool _enterClicked = false;
    [SerializeField] bool _typingClicked = false;
    public float initz;
    private Vector3 initposition; 
    private Vector3 hiddenPosition;

    void Start()
    {
        initz = transform.position.z;
        initposition = new Vector3(-0.07000663f,-3.153409f,initz);
        hiddenPosition = new Vector3(-0.07000663f,-9.090909f,initz);
        // initially it was in the hidden position
        this.transform.position = hiddenPosition;
        Debug.Log(transform.position.x +"&"+ transform.position.y+"&"+ transform.position.z);
    }


    public void EnterClicked()
    {
        _enterClicked = true;
    }

    public void TypingClicked()
    {
        _typingClicked = true;
    }
    public void DisAppearAni()
    {
        //Debug.Log(1);
        this.transform.position = Vector3.MoveTowards(this.transform.position, hiddenPosition, Time.deltaTime*6);
    }

    public void AppearAni()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, initposition, Time.deltaTime*6);
    }

    void Update()
    {
        
        // for disappear animation
        if (_enterClicked)
        {
            DisAppearAni();
            StartCoroutine(KeyboardDisappear());
        }
        
        // for appear animation
        if (_typingClicked)
        {
            AppearAni();
            StartCoroutine(KeyboardAppear());
        }

        
    }

    IEnumerator KeyboardDisappear()
    {
        yield return new WaitForSeconds(1f);
        _enterClicked = false;
    }
    
    IEnumerator KeyboardAppear()
    {
        yield return new WaitForSeconds(1f);
        _typingClicked = false;
    }
}
