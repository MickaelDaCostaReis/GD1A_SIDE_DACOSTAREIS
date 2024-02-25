using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private RangedAttack rangedatk;
    

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            rangedatk = collision.GetComponent<RangedAttack>();
            rangedatk.enabled = true;
            gameObject.SetActive(false);
        }
    }
}
