using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemCollection : MonoBehaviour
{
    [SerializeField]
    private float instantKillTime = 5f;

    private PlayerControl pl;
    private LevelManager LManager;
    private itemManager item;

    private bool instantKillActive = false;

    // Start is called before the first frame update
    void Start()
    {
        pl = GetComponent<PlayerControl>();
        LManager = FindObjectOfType<LevelManager>();
        item = FindObjectOfType<itemManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (instantKillActive)
        {
            if (instantKillTime > 0)
            {
                instantKillTime -= Time.deltaTime;
                displayTime(instantKillTime);
            }
            else
            {
                instantKillTime = 0;
                instantKillActive = false;
                pl.hitStrength = 1;
                displayTime(instantKillTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            instantKillActive = true;
            instantKillTime = 5f;
            pl.hitStrength = 3;
            item.collected(1, pl.transform.position);
        }
        if (collision.gameObject.CompareTag("Banana"))
        {
            pl.health = 10;
            LManager.updateHealth(5);
            item.collected(2, pl.transform.position);
        }
        if (collision.gameObject.CompareTag("Kiwi"))
        {
            pl.score++;
            LManager.updateScore(pl.score);
            item.collected(3, pl.transform.position);
        }
    }

    private void displayTime(float time)
    {
        float seconds = Mathf.FloorToInt(time % 60);
        LManager.setTimeRemaining(seconds);
    }
}
