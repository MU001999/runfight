using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Controller : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public Vector2 vel;
    public Vector2 pre;
    public Vector2 target;
    public Transform pp;
    public Animator ani;
    public bool isGrounded;
    public bool notGo;
    public bool back;

    // Use this for initialization
    void Start()
    {
        isGrounded = true;
        notGo = true;
        back = true;
        vel = new Vector2();
        rb2d = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        this.name = "player";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        if (Input.GetKeyDown(KeyCode.W) && isGrounded && back)
        {
            ani.SetBool("isFighting", false);
            ani.SetBool("isJumping", true);
            isGrounded = false;
            rb2d.velocity = new Vector2(rb2d.velocity.x, 30F);
        }

        if (isGrounded && back)
        {
            ani.SetBool("isAir", true);
        }
        
        if (Input.GetKey(KeyCode.A) && back)
        {
            ani.SetBool("isRuning", true);
            rb2d.velocity = new Vector2(-8F, rb2d.velocity.y);
        }
        if (Input.GetKey(KeyCode.S) && back)
        {
            rb2d.AddForce(transform.up * -100);
        }
        if (Input.GetKey(KeyCode.D) && back)
        {
            ani.SetBool("isRuning", true);
            rb2d.velocity = new Vector2(+8F, rb2d.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && back)
        {
            ani.SetBool("isFighting", true);
            Instantiate(pp, new Vector3(transform.position.x+4F, transform.position.y, transform.position.z), Quaternion.identity);
        }
        if (Input.GetMouseButtonDown(0) && notGo && !isGrounded && back)
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (target.x >= rb2d.position.x + 16F && target.y >= 2F)
            {
                notGo = false;
                back = false;
                pre = rb2d.position;
                ani.SetBool("isGoing", true);
            }
        }
        if (!notGo && !isGrounded)
        {
            rb2d.position = Vector2.SmoothDamp(rb2d.position, target, ref vel, 0.1F, 1000, Time.fixedDeltaTime);
        }
        if (notGo && !back)
        {
            ani.SetBool("isBacking", true);
            rb2d.position = Vector2.SmoothDamp(rb2d.position, pre, ref vel, 0.05F, 1000, Time.fixedDeltaTime);
        }
        if (!back && rb2d.position.x <= pre.x+0.5)
        {
            back = true;
            ani.SetBool("isGoing", false);
            ani.SetBool("isBacking", false);
        }
        if (rb2d.position.x >= target.x-1)
        {
            notGo = true;
        }
        if (Math.Abs(rb2d.velocity.x) <= 0.05F && isGrounded)
        {
            ani.SetBool("isRuning", false);
        }
        rb2d.gravityScale = back ? 10F : 0.01F;
    }
}
