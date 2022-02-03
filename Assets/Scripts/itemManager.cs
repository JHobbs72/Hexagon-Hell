using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemManager : MonoBehaviour
{
    [SerializeField]
    private GameObject ApplePF;
    [SerializeField]
    private GameObject BananaPF;
    [SerializeField]
    private GameObject KiwiPF;
    [SerializeField]
    private int timeToWait;

    // Start is called before the first frame update
    void Start()
    {
        //Apples
        Instantiate(ApplePF, new Vector2(-16.5f, 2.5f), Quaternion.identity);
        Instantiate(ApplePF, new Vector2(-31.2f, 17.7f), Quaternion.identity);
        Instantiate(ApplePF, new Vector2(-7.5f, 35.2f), Quaternion.identity);
        Instantiate(ApplePF, new Vector2(6f, 3.1f), Quaternion.identity);
        Instantiate(ApplePF, new Vector2(1.8f, 26.8f), Quaternion.identity);
        Instantiate(ApplePF, new Vector2(42.7f, 37.8f), Quaternion.identity);
        Instantiate(ApplePF, new Vector2(-5.1f, 86.8f), Quaternion.identity);
        Instantiate(ApplePF, new Vector2(-30.2f, 2f), Quaternion.identity);
        Instantiate(ApplePF, new Vector2(20f, 62.9f), Quaternion.identity);
        Instantiate(ApplePF, new Vector2(15.7f, 83.8f), Quaternion.identity);

        //Bananas
        Instantiate(BananaPF, new Vector2(5.5f, 74.7f), Quaternion.identity);
        Instantiate(BananaPF, new Vector2(14.8f, 63.9f), Quaternion.identity);
        Instantiate(BananaPF, new Vector2(45.9f, 50.7f), Quaternion.identity);
        Instantiate(BananaPF, new Vector2(-23f, 7.8f), Quaternion.identity);
        Instantiate(BananaPF, new Vector2(-1.8f, 2.8f), Quaternion.identity);
        Instantiate(BananaPF, new Vector2(43f, 37.8f), Quaternion.identity);
        Instantiate(BananaPF, new Vector2(10.9f, 32.7f), Quaternion.identity);
        Instantiate(BananaPF, new Vector2(18.5f, 22.3f), Quaternion.identity);
        Instantiate(BananaPF, new Vector2(-12.2f, 44.9f), Quaternion.identity);
        Instantiate(BananaPF, new Vector2(-22.8f, 60.7f), Quaternion.identity);

        //Kiwis
        Instantiate(KiwiPF, new Vector2(-26.7f, 66.9f), Quaternion.identity);
        Instantiate(KiwiPF, new Vector2(-17.6f, 55f), Quaternion.identity);
        Instantiate(KiwiPF, new Vector2(-8f, 68.9f), Quaternion.identity);
        Instantiate(KiwiPF, new Vector2(4.9f, 51.9f), Quaternion.identity);
        Instantiate(KiwiPF, new Vector2(21.2f, 57.6f), Quaternion.identity);
        Instantiate(KiwiPF, new Vector2(36.7f, 45.7f), Quaternion.identity);
        Instantiate(KiwiPF, new Vector2(26.6f, 29f), Quaternion.identity);
        Instantiate(KiwiPF, new Vector2(16.4f, 31f), Quaternion.identity);
        Instantiate(KiwiPF, new Vector2(46.3f, 27f), Quaternion.identity);
        Instantiate(KiwiPF, new Vector2(-46.1f, 24.2f), Quaternion.identity);
        Instantiate(KiwiPF, new Vector2(-24f, 2.1f), Quaternion.identity);
    }

    public void collected(int tag, Vector3 pos)
    {
        StartCoroutine(regen(tag, pos));
    }

    IEnumerator regen(int tag, Vector3 pos)
    {
        yield return new WaitForSeconds(timeToWait);
        if (tag == 1)
        {
            Instantiate(ApplePF, pos, Quaternion.identity);
        }
        if (tag == 2)
        {
            Instantiate(BananaPF, pos, Quaternion.identity);
        }
        if (tag == 3)
        {
            Instantiate(KiwiPF, pos, Quaternion.identity);
        }
    }
}
