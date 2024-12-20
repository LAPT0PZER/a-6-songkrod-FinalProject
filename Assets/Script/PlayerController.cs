﻿﻿using UnityEngine;
using System.Collections;

public class PlayerController : Player {

    bool facingRight = true;

    Rigidbody2D r2d;
    //Animator anim;

    public bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    [SerializeField] GameObject win;

    // Use this for initialization
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        originalSpeed = Speed;
    }

    void Update()
    {
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            r2d.AddForce(new Vector2(0, JumpForce));
        }
        UpdateSpeedBoostTimer();
        UpdatePointText();

        if (Point >= 100)
        {
            Time.timeScale = 0f;
            win.SetActive(true);
        }
    }

    void FixedUpdate()
    {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        //anim.SetBool("Ground", grounded);

        //anim.SetFloat("vSpeed", r2d.velocity.y);

        float move = Input.GetAxis("Horizontal");

        //anim.SetFloat("Speed", Mathf.Abs(move));

        r2d.velocity = new Vector2(move * Speed, r2d.velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}