using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 5f;
    public float jumpStrength = 8000f;

    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRender;
    private Animator animator;

    private bool isGrounded;

    private Anims State
    {
        get { return (Anims)animator.GetInteger("state"); }
        set { animator.SetInteger("state", (int)value); }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.rigidBody = GetComponent<Rigidbody2D>();
        this.spriteRender = GetComponentInChildren<SpriteRenderer>();
        this.animator = GetComponent<Animator>();
    }

    private void Awake()
    {
        this.rigidBody = GetComponent<Rigidbody2D>();
        this.spriteRender = GetComponentInChildren<SpriteRenderer>();
        this.animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        this.CheckGround();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isGrounded && Input.GetButtonDown("Jump"))
        {
            this.Jump();
        }
        else if (Input.GetButton("Horizontal"))
        {
            this.Run();
            State = Anims.Run;
        }
        else
        {
            State = Anims.Idle;
        }
    }

    private void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, this.speed * Time.deltaTime);
        this.spriteRender.flipX = direction.x < 0.0f;
    }

    private void Jump()
    {
        this.rigidBody.AddForce(transform.up * this.jumpStrength, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        this.isGrounded = colliders.Length > 1;
    }
}

enum Anims
{
    Idle = 0,
    Run = 1,
}
