using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Typing : MonoBehaviour
{
    private Vector2 hiddenPos;

    private Vector2 appearPos;

    private bool _toHidden;
    private bool _toAppear;


    // Start is called before the first frame update
    void Start()
    {
        appearPos = this.transform.position;
        Debug.Log(appearPos.y);
        hiddenPos = new Vector2(hiddenPos.x, -210f);
    }

    public void toHidden()
    {
        _toHidden = true;
    }

    public void toAppear()
    {
        _toAppear = true;
    }

    void Update()
    {
        if (_toAppear)
        {
            this.transform.position = appearPos;
            _toAppear = !_toAppear;
        }
        
        if (_toHidden)
        {
            this.transform.position = hiddenPos;
            _toHidden = !_toHidden;
        }
    }
    
}
