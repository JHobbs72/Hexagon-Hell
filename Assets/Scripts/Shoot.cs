using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private Transform FirePoint;
    [SerializeField]
    private GameObject bulletPF;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bulletPF, FirePoint.position, FirePoint.rotation);
        }
        
    }
}
