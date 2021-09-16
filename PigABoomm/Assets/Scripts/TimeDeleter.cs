using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDeleter : MonoBehaviour
{
    public float timer;
    private float tm;
    private CircleCollider2D bx;
    private float tbd;

    private void Start()
    {
        bx = gameObject.GetComponent<CircleCollider2D>();
    }
    void Update()
    {
        tm += Time.deltaTime;
        tbd += Time.deltaTime;
        if (tm >= timer)
        {
            Destroy(gameObject);
        }

        if (tbd >= 0.1)
        {
            bx.enabled = false;
        }
    }
}
