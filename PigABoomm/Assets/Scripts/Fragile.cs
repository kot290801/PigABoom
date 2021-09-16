using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fragile : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public GameObject boom;
    public float boomRate;
    private float br;
    private int power = 1;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            power = GameObject.FindGameObjectWithTag("Player").GetComponent<ModileControl>().bombPower;
        }
    }

    private void Update()
    {
        gameObject.transform.Translate(Vector3.up * speed * Time.deltaTime, Space.Self);
        br += Time.deltaTime;
        if (br >= boomRate && power > 0)
        {
            Instantiate(boom, gameObject.transform.position, Quaternion.identity);
            br = 0;
            power--;
        }

        if (power == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
