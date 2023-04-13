using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Target : MonoBehaviour
{
    
    private Collider2D _collider;
    public int id;
    public int counter;
    public TextMeshProUGUI text;
    
    void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Birds")
        {
            Drag drag = col.gameObject.GetComponent<Drag>();
            GameObject bird = col.gameObject;
            // resume the original position if not correct
            if (id != drag.id)
            {
                // do nothing
                
            }
            else
            {
                // if correct
                
                // destroy the bird object
                drag.Destoryitself();
                // decrement the counter
                this.counter--;
                updateCounter();
            }
            
            
        }
    }
    // Update the counter
    void updateCounter()
    {
        this.text.text = this.counter.ToString();
    }
}
