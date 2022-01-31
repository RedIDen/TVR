using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 5f;
    public float jumpStrength = 8000f;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode shoot;

    public GameObject upperBody;
    public GameObject lowerBody;
    public GameObject bloodEffect;
    public Transform diePoint;
    public ShotGunScript weapon;

    private Rigidbody2D rigidBody;
    private Animator animator;

    private bool isGrounded;
    private bool isDead;
    private bool isTurndeRight = true;

    private Anims State
    {
        get { return (Anims)animator.GetInteger("state"); }
        set { animator.SetInteger("state", (int)value); }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.rigidBody = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(this.shoot))
        {
            this.Shoot();
        }
        else if (Input.GetKeyDown(this.jump))
        {
            this.Jump();
        }
        else if (Input.GetKey(this.right))
        {
            this.Run(true);
            State = Anims.Run;
        }
        else if (Input.GetKey(this.left))
        {
            this.Run(false);
            State = Anims.Run;
        }
        else
        {
            State = Anims.Idle;
        }
    }

    private void Run(bool isGoingRight)
    {
        var axis = isGoingRight ? 1 : -1;
        Vector3 direction = transform.right * axis;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, this.speed * Time.deltaTime);
        if (axis > 0.0f && !this.isTurndeRight || axis < 0.0f && this.isTurndeRight)
        {
            this.isTurndeRight = !isTurndeRight;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.y);
        }
    }

    private void Jump()
    {
        if (this.isGrounded)
        {
            this.rigidBody.AddForce(transform.up * this.jumpStrength, ForceMode2D.Impulse);
            this.isGrounded = false;
        }
    }

    private void Shoot()
    {
        if (this.weapon.Shoot())
        {
            var force = transform.localScale.x < 0 ? transform.right * 20 : -transform.right * 20;
            this.rigidBody.AddForce(force, ForceMode2D.Impulse);
            this.animator.Play("run");
        }
    }

    public void Die(float angle)
    {
        if (!isDead)
        {
            isDead = true;
            Instantiate(bloodEffect, diePoint.transform.position, Quaternion.Euler(0, 90 + angle, 0));
            Instantiate(upperBody, diePoint.transform.position, diePoint.transform.rotation).transform.localScale = transform.localScale;
            Instantiate(lowerBody, diePoint.transform.position, diePoint.transform.rotation).transform.localScale = transform.localScale;
        }

        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            this.isGrounded = true;
        }
    }
}

enum Anims
{
    Idle = 0,
    Run = 1,
}
