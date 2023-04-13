using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Drag : MonoBehaviour
{
    private bool _moveallowed;

    private bool _retpos = false;

    private Collider2D _collider;

    private Vector3 _initPos;

    public int id;

    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<Collider2D>();
        // get the initial position of the bird

        // hang up for 0.5 sec until program is invoked to retrieve th
        StartCoroutine(WaitForSeconds());
    }
    
    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(0.5f);
        
        _initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            // if user has touched the screen
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            
            // check touch phase
            // if the player has touched the screen for
            if (touch.phase == TouchPhase.Began)
            {
                Collider2D touchCollider = Physics2D.OverlapPoint(touchPosition);
                // if the user is touching the birds
                if (_collider == touchCollider)
                {
                    _moveallowed = true;
                }
            }
            
            // if the player is moving fingers on screen
            if (touch.phase == TouchPhase.Moved)
            {
                // if the player has clicked the bird and then the bird can be moved
                if (_moveallowed)
                {
                    // set the bird position to the current finger position
                    transform.position = new Vector3(touchPosition.x,touchPosition.y,0);
                }
            }
            
            // if fingers movements stop
            if (touch.phase == TouchPhase.Ended)
            {
                // disable all the touch
                _moveallowed = false;
                // returnOrigin();
                _retpos = true;
            }
        }

        if (_retpos)
        {
            returnOrigin();
        }
        
    }

    // move back to the init position
    public void returnOrigin()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(_initPos.x,_initPos.y), Time.deltaTime);
    }

    // function to destroy itself
    public void Destoryitself()
    {
        Destroy(gameObject);
    }
}
