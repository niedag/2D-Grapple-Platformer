using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame
    private Rigidbody2D playerBody;
    private BoxCollider2D coll; 
    private Animator anim;
    private SpriteRenderer sprite;

    private GrappleHook gh;

    private float dirX = 0f;
    private float dirY = 0f;


    private enum MovementState { idle, running, jumping, falling }

    [SerializeField] private LayerMask jumpableGround; 
    [SerializeField] private float moveSpeed = 7f; //SerializeField makes it possible to modify the variables temporarily from the Inspector panel
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private int jumpCounter = 2;

    //can also use public float to make it visible in Inspector

    private void Start() 
    {
        playerBody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        gh = GetComponent<GrappleHook>();
    }

    // Update is called once per frame.... smooth movement when 
    private void Update()
    {
        //float dirX = Input.GetAxis("Horizontal"); more sliding, no control of body once in air
        dirX = Input.GetAxisRaw("Horizontal"); //more responsive, no sliding
        //dirY = Input.GetAxisRaw("Veritcal");
        playerBody.velocity = new Vector2(dirX * moveSpeed, playerBody.velocity.y);



        if (Input.GetButtonDown("Jump") && IsGrounded()) {
            playerBody.velocity = new Vector2(playerBody.velocity.x, jumpForce); //vector 3 for 3D games, vector2 for two dimensions 
        }
        UpdateAnimationState();
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x, -25);
        }
    }
    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running; //running left 
            sprite.flipX = false;
        } else if (dirX < 0f)
        {
            state = MovementState.running; //running right
            sprite.flipX = true;

        } else
        {
           state = MovementState.idle;
        }

        if (playerBody.velocity.y > 0.0001f)
        {
            state = MovementState.jumping; //set animation state to jumping
        }
        else if (playerBody.velocity.y < -0.0001f)
        {
            state = MovementState.falling;
        }
            anim.SetInteger("state", (int)state);
    }

    private void FixedUpdate()
    {
        if(gh.retracting)
        {
            playerBody.velocity = Vector2.zero;
        }
    }


    private bool IsGrounded()
    {
      return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}