using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    public float jumpforce;
    public float playerspeed;
    public Vector2 jumpheight;
    private bool isOnGround;
    public float positionRadius;
    public LayerMask ground;
    public Transform playerpos;



    private void Start()
    {
        Collider2D[] colliders = transform.GetComponentsInChildren<Collider2D>();
        for(int i=0;i<colliders.Length;i++)
        {
            for(int k=i+1;k<colliders.Length;k++)
            {
                Physics2D.IgnoreCollision(colliders[i], colliders[k]);
            }
        }
    }

    private void Update()
    {
        if(Input.GetAxisRaw("Horizontal")!=0)
        {
            if(Input.GetAxisRaw("Horizontal")>0)
            {
                anim.Play("walk");
                rb.AddForce(Vector2.right * playerspeed*Time.deltaTime);
            }
            else
            {
                anim.Play("walkback");
                rb.AddForce(Vector2.left * playerspeed * Time.deltaTime);

            }
        }
        else
        {
            anim.Play("idle");
        }

        isOnGround = Physics2D.OverlapCircle(playerpos.position, positionRadius, ground);
        if(isOnGround==true && Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("jumping");
            rb.AddForce(Vector2.up * jumpforce * Time.deltaTime);
        }

    }
}
