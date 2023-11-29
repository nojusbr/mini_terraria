using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public float moveSpeed = 3;
    public float jumpForce = 5f;
    public float cooldown = 2f;
    public float timer;


    Rigidbody2D rb;
    SpriteRenderer renderer;
    public Transform player;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    { 
        if (player != null)
        { 
            Vector3 direction = player.position - transform.position;
            direction.Normalize();
            transform.Translate(direction * moveSpeed * Time.deltaTime);
            
            if (Time.time >= timer && isGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.deltaTime);
                timer = Time.time + cooldown;
            }
        } 
    }

    bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
        return hit.collider != null;
    }


}
