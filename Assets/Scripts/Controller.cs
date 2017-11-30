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
    public Transform pig;
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
            isGrounded = false;
            rb2d.AddForce(transform.up * 500);
        }
        if (Input.GetKey(KeyCode.A) && back)
        {
            rb2d.position = Vector2.SmoothDamp(rb2d.position, new Vector2(rb2d.position.x - 50, rb2d.position.y), ref vel, Time.fixedDeltaTime, 10, Time.fixedDeltaTime);
            //rb2d.AddForce(transform.right * -10);
            //rb2d.MovePosition(new Vector2(rb2d.position.x - 10 * Time.deltaTime, rb2d.position.y));
        }
        if (Input.GetKey(KeyCode.S) && back)
        {
            rb2d.AddForce(transform.up * -100);
            //rb2d.MovePosition(new Vector2(rb2d.position.x, rb2d.position.y - 10 * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.D) && back)
        {
            rb2d.position = Vector2.SmoothDamp(rb2d.position, new Vector2(rb2d.position.x + 10, rb2d.position.y), ref vel, Time.fixedDeltaTime, 10, Time.fixedDeltaTime);
            //rb2d.AddForce(transform.right * 10);
            //rb2d.MovePosition(new Vector2(rb2d.position.x + 10 * Time.deltaTime, rb2d.position.y));
        }
        if (Input.GetKeyDown(KeyCode.Space) && back)
        {
            ani.SetBool("isFighting", true);
            Instantiate(pig, new Vector3(transform.position.x+10F, transform.position.y), transform.rotation);
        }
        if (Input.GetMouseButtonDown(0) && notGo && !isGrounded && back)
        {
            notGo = false;
            back = false;
            pre = rb2d.position;
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (!notGo && !isGrounded)
        {
            rb2d.position = Vector2.SmoothDamp(rb2d.position, target, ref vel, 0.1F, 1000, Time.fixedDeltaTime);
        }
        if (notGo && !back)
        {
            rb2d.position = Vector2.SmoothDamp(rb2d.position, pre, ref vel, 0.1F, 1000, Time.fixedDeltaTime);
        }
        if (!back && rb2d.position.x <= pre.x+0.5)
        {
            back = true;
        }
        if (rb2d.position.x >= target.x-0.5)
        {
            notGo = true;
        }
    }
}
