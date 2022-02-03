using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private PlayerControl pl;
    private LevelManager LManager;
    private SpriteRenderer PlayerSR;

    // Start is called before the first frame update
    void Start()
    {
        pl = FindObjectOfType<PlayerControl>();
        LManager = FindObjectOfType<LevelManager>();
        PlayerSR = pl.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Eagle"))
        {
            pl.health -= 1;
            LManager.updateHealth(pl.health);
            StartCoroutine(hit());
            if (pl.health <= 0)
            {
                //Call death script
                Destroy(gameObject);
            }
        }
    }

    IEnumerator hit()
    {
        for (int i = 0; i < 5; i++)
        {
            PlayerSR.color = Color.red;
            yield return new WaitForSeconds(.1f);
            PlayerSR.color = Color.white;
            yield return new WaitForSeconds(.1f);
        }
    }
}
