using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleManager : MonoBehaviour
{
    [SerializeField]
    private GameObject EaglePF;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(EaglePF, new Vector2(-1, 41), Quaternion.identity);
    }

    public void spawn()
    {
        Instantiate(EaglePF, new Vector2(-2.5f, 41f), Quaternion.identity);
        Instantiate(EaglePF, new Vector2(0.5f, 41f), Quaternion.identity);
    }
}
