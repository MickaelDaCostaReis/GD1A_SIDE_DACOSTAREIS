using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//PAS UTILISÉ




public class Projectile : MonoBehaviour
{
    private float direction;
    [SerializeField] private float speed;
    private bool contact;
    private Animator animation;
    private float despawntimer;
    [SerializeField] private BoxCollider2D bcld;
   
    void Start()
    {
        //bcld = GetComponent<BoxCollider2D>(); fait buguer pour une raison mystique :)
        animation = GetComponent<Animator>();
    }

    void Update()
    {
        despawntimer += Time.deltaTime;
        if (despawntimer > 3) gameObject.SetActive(false);
        if (contact) return;
        // MOUVEMENT DU COUTEAU
        float movementspeed=speed *Time.deltaTime * direction;
        transform.Translate(movementspeed,0,0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
        contact = true;
        bcld.enabled=false;
       
    }
    public void SetDirection(float direction)
    {
        // INVERSE LE SCALE EN FONCTION DE LA DIRECTION DU TIR
        despawntimer = 0;
        this.direction = direction;
        gameObject.SetActive(true);
        contact=false;
        bcld.enabled=true;
        float localScalex=transform.localScale.x;
        if(Mathf.Sign(localScalex) != direction )
            localScalex *= -1;
        transform.localScale = new Vector3(localScalex, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
