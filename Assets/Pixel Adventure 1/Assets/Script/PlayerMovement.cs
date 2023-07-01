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

    private Rigidbody2D rb;
    private Animator ani;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        AnimationUpdateState();
    }

    private void AnimationUpdateState()
    {
        if (dirX > 0f)
        {
            ani.SetBool("Running", true);
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            ani.SetBool("Running", true);
            sprite.flipX = true;
        }
        else
            ani.SetBool("Running", false);
    }
}
