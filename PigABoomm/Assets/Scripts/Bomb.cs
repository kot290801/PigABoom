using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject boom;
    public float timer = 2;
    private float tm;


    void Update()
    {
        tm += Time.deltaTime;
        if (tm >= timer)
        {
            Instantiate(boom, gameObject.transform.position, Quaternion.identity);
            if (GameObject.FindGameObjectWithTag("Player"))
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<ModileControl>().bcnt++;
            }
            Destroy(gameObject);
        }
    }
}
