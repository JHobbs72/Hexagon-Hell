using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private float jumpPower;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Vector2 jumpBoxDir;
    [SerializeField]
    private LayerMask ground;
    [SerializeField]
    public int health = 10;

    private float xVal = 0f;

    private Rigidbody2D player1RB;
    private Animator anim;
    private BoxCollider2D col;
    private SpriteRenderer sprite;
    private LevelManager LManager;

    public int hitStrength = 1;
    public int score = 0;

    private enum playerAnimation { idle, run, fall, jump }

    // Start is called before the first frame update
    void Start()
    {
        player1RB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        LManager = FindObjectOfType<LevelManager>();
        LManager.updateHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        xVal = Input.GetAxis("Horizontal");
        player1RB.velocity = new Vector2(xVal * moveSpeed, player1RB.velocity.y);

        if (Input.GetButtonDown("Jump") && isOnGround())
        {
            player1RB.velocity = new Vector2(player1RB.velocity.x, jumpPower);
        }

        updateAnimation();
    }

    private bool isOnGround()
    {
        return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, 0.1f, ground);
    }

    private void updateAnimation()
    {
        playerAnimation animationState;

        if (xVal > 0f)
        {
            animationState = playerAnimation.run;
            sprite.flipX = false;
        }
        else if (xVal < 0f)
        {
            animationState = playerAnimation.run;
            sprite.flipX = true;
        }
        else
        {
            animationState = playerAnimation.idle;
        }

        if (player1RB.velocity.y > 0.1f)
        {
            animationState = playerAnimation.jump;
        }
        else if (player1RB.velocity.y < -0.1f)
        {
            animationState = playerAnimation.fall;
        }

        anim.SetInteger("animationState", (int)animationState);
    }
}
