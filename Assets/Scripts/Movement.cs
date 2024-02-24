using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;
    private float wallJumpCd;

    [SerializeField] private float speed;
    [SerializeField] private float jumpingPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        // Inputs :
        horizontal = Input.GetAxis("Horizontal");

        Flip();

        //Jump
        JumpConditions();
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    // vrai si le joueur touche le sol
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    // vrai si le joueur touche un mur qu'il regarde
    private bool IsonWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    //Inverse le scale du sprite, flip le joueur
    
    private void Flip()
    {
        if (horizontal > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontal < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        else if (IsonWall() && !IsGrounded())
        { 
            rb.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 32, 16);
        }
    }

    private void JumpConditions()
    {

        // Divise par deux la vélocité si le bouton jump est relâché
        
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        
        if (wallJumpCd > 0.2f)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            if (IsonWall() && !IsGrounded())
            {
                rb.gravityScale = 0;
                rb.velocity = Vector2.zero;
            }
            else
                rb.gravityScale = 4;

            if (Input.GetButton("Jump"))
                Jump();
        }
        else
        {
            wallJumpCd += Time.deltaTime;
        }
    }
} 
