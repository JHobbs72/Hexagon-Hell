using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleControl : MonoBehaviour
{
    [SerializeField]
    private int health = 3;

    private PlayerControl pl;
    private EagleManager EManager;
    private LevelManager LManager;

    // Start is called before the first frame update
    void Start()
    {
        pl = FindObjectOfType<PlayerControl>();
        EManager = FindObjectOfType<EagleManager>();
        LManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health -= pl.hitStrength;
            if (health <= 0)
            {
                Destroy(gameObject);
                pl.score++;
                LManager.updateScore(pl.score);
                EManager.spawn();
            }
        }
    }
}
