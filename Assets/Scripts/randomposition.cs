using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomposition : MonoBehaviour
{
    // Start is called before the first frame update
    public float minY = 0.0f;
    public float minX = 6.0f;
    private float maxY = 12.0f;
    private float maxX = 20.0f;
    public GameObject[] birdarray;
    private Vector3 newposition;
    public int id;
    
    void Start()
    {
        switch (id)
        {
            case 1:
                Scene1();
                break;
            case 2:
                Scene2();
                break;
        }
    }

    void Scene1()
    {
        float distnaceX = (maxX - minX) / 8.0f ;
        float distanceY = (maxY - minY) / 8.0f;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                float indiYPadding = Random.Range(0.2f, 0.5f);
                float initXPadding = Random.Range(-0.5f, -2f);
                float newXrand = Random.Range(1.1f, 1.6f);
                float newYrand = Random.Range(1.0f, 1.2f);
                newposition = new Vector3(initXPadding-8.0f+minX + j * distnaceX*newXrand,indiYPadding+minY+i*newYrand*distanceY-2.0f,0.0f);
                birdarray[i * 4 + j].transform.position = newposition;
            }
        }
    }

    void Scene2()
    {
        float distnaceX = (maxX - minX) / 5.6f ;
        float distanceY = (maxY - minY) / 6.6f;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                float indiYPadding = Random.Range(0.4f, 0.7f);
                float initXPadding = Random.Range(-0.5f, -2f);
                float newXrand = Random.Range(1.2f, 1.6f);
                float newYrand = Random.Range(.8f, 1.2f);
                newposition = new Vector3(initXPadding-11.0f+minX + j * distnaceX*newXrand,indiYPadding+minY+i*newYrand*distanceY-3.0f,0.0f);
                birdarray[i * 4 + j].transform.position = newposition;
            }
        }
    }
    
}
