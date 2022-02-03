using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 25f;
    //[SerializeField]
    //private Rigidbody2D rb;

    private Rigidbody2D rb;
    private Vector2 mousePos;
    private Vector2 playerPos;
    private Vector2 direction;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerPos = new Vector2(transform.position.x, transform.position.y);
        direction = mousePos - playerPos;
        direction.Normalize();

        rb.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (   collision.gameObject.CompareTag("Terrain")
            || collision.gameObject.CompareTag("Eagle"))
        {
            Destroy(gameObject);
        }

    }
}
