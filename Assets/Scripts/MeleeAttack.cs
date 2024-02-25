using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{

    private Animator animation;
    [SerializeField] private BoxCollider2D range;
    void Start()
    {
        animation = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animation.SetTrigger("MeleeAttack");
        }
    }

    void ActivateHitbox()
    {
        range.gameObject.SetActive(true);
    }

    void DeactivateHitbox()
    {
        range.gameObject.SetActive(false);
    }
}
