using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;
    public float parallaxCoef;

    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

  
    void Update()
    {
        float tmp = (cam.transform.position.x * (1 - parallaxCoef));
        float distance = (cam.transform.position.x * parallaxCoef);
        // pas sûr de ça, a tester aled
        transform.position = new Vector3(startpos + distance, transform.position.x, transform.position.z);
        if (tmp > startpos + length) startpos += length;
        else if(tmp< startpos-length) startpos -= length;
    }
}
