using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Boost : MonoBehaviour
{
    public int bombCount;
    public int bombPower;
    public float speed;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ModileControl>())
        {
            collision.GetComponent<ModileControl>().bcnt += bombCount;
            collision.GetComponent<ModileControl>().bombPower += bombPower;
            collision.GetComponent<ModileControl>().speed += speed;
            Destroy(gameObject);
        }
        if (collision.GetComponent<Dog>())
        {
            collision.GetComponent<AIPath>().maxSpeed += speed;
            Destroy(gameObject);
        }
    }
}
