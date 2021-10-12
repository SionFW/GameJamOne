using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    public ParticleSystem dust;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float movespeed = 7f;
    [SerializeField] private float jumpforce = 14f;

    private enum MovementState { idle, Running, Jumping, Falling }

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {

        // Player Horizontal Input 

        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * movespeed, rb.velocity.y);

        CreateDust();



        // Player Jump Input

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }



        UpdateAnimationState();
    }

    //Checking which animations are playing ?

    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.Running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.Running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle; ;

        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.Jumping;

        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.Falling;

        }

        anim.SetInteger("state", (int)state);


    }

    private bool IsGrounded()
    {
        // checking if the collions box on Player is colliding with the ground so that we can only jump when in contact ?

        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);

    }

    void CreateDust()
    {
        dust.Play();
    }

}
