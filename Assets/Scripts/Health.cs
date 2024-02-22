using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    [SerializeField] private float maxhealth;
    public float currenthealth;

    private void Start()
    {
        currenthealth = maxhealth;
    }
    public void takeDamage(float damage)
    {
        currenthealth = Mathf.Clamp(currenthealth - damage, 0, maxhealth);
        if (currenthealth > 0)
        {

        }
        else
        {
            //joueur mort
        }
    }
}