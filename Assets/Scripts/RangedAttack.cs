using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RangedAttack : MonoBehaviour
{
    [SerializeField] private Animator animation;
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] knifes;
    private float atkCD;
    private float atkDuration =Mathf.Infinity;

    

    void Update()
    {
        if (Input.GetButtonDown("Fire2") && atkDuration>atkCD)       
            Throwing();
        
        atkDuration += Time.deltaTime;
    }

    private void Throwing()
    {
        animation.SetTrigger("Throw"); 
        atkDuration = 0;

        knifes[TakeKnife()].transform.position = firepoint.position;
        knifes[TakeKnife()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int TakeKnife()
    {
        for (int i = 0; i < knifes.Length; i++)
        {
            if (!knifes[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
