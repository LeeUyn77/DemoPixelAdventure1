using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float dirX = 0f;

    [SerializeField]
    float speed = 7f;

    [SerializeField]
    float jumpForce = 14f;

    [SerializeField]
    LayerMask jumpableGround;

    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource collectSound;

    private Rigidbody2D rb;
    private Animator ani;
    private SpriteRenderer sprite;
    private BoxCollider2D bColl;

    private enum MovementState
    {
        idle,
        running,
        falling,
        jumping
    }

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        bColl = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded()){
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
            

        AnimationUpdateState();
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(
            bColl.bounds.center,
            bColl.bounds.size,
            0f,
            Vector2.down,
            .1f,
            jumpableGround
        );
    }

    private void AnimationUpdateState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
            state = MovementState.idle;

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
            state = MovementState.falling;

        ani.SetInteger("state", (int)state);
    }
}
