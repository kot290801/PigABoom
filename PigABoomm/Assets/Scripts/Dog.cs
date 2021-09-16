using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Dog : MonoBehaviour
{
    private SpriteRenderer sr;
    public Sprite[] sprites;
    private float oldX;
    private float oldY;
    public Transform target;
    public float randomPositionRate;
    private float rtm;
    private bool angry;
    public GameObject defeatedDog;
    public GameObject[] boosts;


    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        gameObject.GetComponent<AIPath>().maxSpeed += (0.1f * GameObject.FindGameObjectWithTag("DogSpawner").GetComponent<DogSpawner>().waveNomber);
    }

    private void Update()
    {
        if (angry == false)
        {
            rtm += Time.deltaTime;
        }

        if (angry == true)
        {
            target.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        }
        else if (angry == false && rtm > randomPositionRate)
        {
            float randX = Random.Range(-10f, 9f);
            float randY = Random.Range(-4.5f, 3.75f);
            target.transform.position = new Vector2(randX, randY);
            rtm = 0;
        }

        float newX = transform.position.x;
        float speedX = (newX - oldX);
        oldX = transform.position.x;
        float newY = transform.position.y;
        float speedY = (newY - oldY);
        oldY = transform.position.y;

        if (speedY > speedX && speedY > 0)
        {
            if (angry == false)
            {
                sr.sprite = sprites[2];
            }
            else
            {
                sr.sprite = sprites[6];
            }
        }
        else if (speedY < 0 && speedY < speedX)
        {
            if (angry == false)
            {
                sr.sprite = sprites[3];
            }
            else
            {
                sr.sprite = sprites[7];
            }
        }
        else if (speedX > 0)
        {
            if (angry == false)
            {
                sr.sprite = sprites[0];
            }
            else
            {
                sr.sprite = sprites[4];
            }
        }
        else if (speedX < 0)
        {
            if (angry == false)
            {
                sr.sprite = sprites[1];
            }
            else
            {
                sr.sprite = sprites[5];
            }
        }
    }

    /*void FixedUpdate()
    {
        float newX = transform.position.x;
        float speedX = (newX - oldX);
        oldX = transform.position.x;
        float newY = transform.position.y;
        float speedY = (newY - oldY);
        oldY = transform.position.y;

        if (speedY > speedX && speedY > 0)
        {
            if (angry == false)
            {
                sr.sprite = sprites[2];
            }
            else
            {
                sr.sprite = sprites[6];
            }
        }
        else if (speedY < 0 && speedY < speedX)
        {
            if (angry == false)
            {
                sr.sprite = sprites[3];
            }
            else
            {
                sr.sprite = sprites[7];
            }
        }
        else if (speedX > 0)
        {
            if (angry == false)
            {
                sr.sprite = sprites[0];
            }
            else
            {
                sr.sprite = sprites[4];
            }
        }
        else if (speedX < 0)
        {
            if (angry == false)
            {
                sr.sprite = sprites[1];
            }
            else
            {
                sr.sprite = sprites[5];
            }
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<TimeDeleter>())
        {
            Instantiate(defeatedDog, gameObject.transform.position, Quaternion.identity);
            int rand = Random.Range(0, boosts.Length);
            Instantiate(boosts[rand], gameObject.transform.position, Quaternion.identity);
            GameObject.FindGameObjectWithTag("DogSpawner").GetComponent<DogSpawner>().dogs--;
            Destroy(gameObject);
        }

        if (collision.GetComponent<ModileControl>())
        {
            angry = true;
            rtm = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<ModileControl>())
        {
            angry = false;
        }
    }
}
