﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazusoController : MonoBehaviour {

    public float speed;
    float Distance_;
    Vector3 playerPos;
    Vector3 newXPos;
    private Rigidbody2D rb;
    private float nextActionTime = 0.0f;
    public float period = .5f;
    public Animator animator;
    public ParticleSystem explosion;
    public bool facingLeft = true;


    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator.SetBool("isRunning", false);
    }

    void Update()
    {
        GameObject player = God.playerObject;
        playerPos = player.transform.position;
        newXPos = new Vector3(playerPos.x, playerPos.y, 0);

        float xVel = rb.velocity.x;
        float yVel = rb.velocity.y;
        animator.SetFloat("yVel", Mathf.Abs(yVel));

        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            rb.velocity = new Vector2(rb.velocity.x, 10);
        }

        if (player)
        {
            //Following Player
            Distance_ = Vector3.Distance(gameObject.transform.position, player.transform.position);
            if (Distance_ <= 10f)
            {
                animator.SetBool("isRunning", true);
                transform.position = Vector3.MoveTowards(transform.position, newXPos, speed);
            }
            else
                animator.SetBool("isRunning", false);
        }

        if (facingLeft == false && xVel > 0)
        {
           Flip();
        }
        else if (facingLeft == false && xVel < 0)
        {
            Flip();
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            Explode();
        }
    }

    void Explode()
    {
        Instantiate(explosion, transform.GetChild(0).transform.position, transform.rotation);
        explosion.Play();
    }

    void Flip()
    {
        facingLeft = !facingLeft;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
