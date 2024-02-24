using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Transform pointA, pointB, enemy;
    private float speed;
    private Vector3 Scale;

    private void Awake()
    {
        Scale = enemy.localScale;
    }
    private void Update()
    {
        moving(1);
    }

    private void moving(int direction)
    {
       // enemy.localScale = new Vector3(Mathf.Abs(Scale.x)*direction, Scale.y, Scale.z);  
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime *direction * speed, enemy.position.y, enemy.position.z);
    }
}
