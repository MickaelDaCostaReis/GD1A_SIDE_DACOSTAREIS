using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos,starty;
    public GameObject cam;
    public float parallaxCoef;

    void Start()
    {
        startpos = transform.position.x;
        starty = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

  
    void Update()
    {
        float tmp = (cam.transform.position.x * (1 - parallaxCoef));
        float distance = (cam.transform.position.x * parallaxCoef);
        transform.position = new Vector3(startpos + distance, starty, transform.position.z);

        // déplace les backgrounds pour les "répéter"
        if (tmp > startpos + length) startpos += length;
        else if(tmp< startpos-length) startpos -= length;
    }
}
