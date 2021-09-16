using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;

public class DogSpawner : MonoBehaviour
{
    public int waveNomber;
    public int dogs;
    public Text dogCounter;
    public GameObject dog;
    private bool doge;
    public float nextWaveTimer;
    private float tm;

    
    void Update()
    {
        if (dogs <= 0)
        {
            tm += Time.deltaTime;
            if (GameObject.FindGameObjectWithTag("Player"))
            {
                GameObject.FindGameObjectWithTag("Player").transform.position = new Vector2(-9f, -0.5f);
            }
        }

        if (tm > nextWaveTimer)
        {
            waveNomber++;
            doge = true;
            tm = 0;
        }

        if (doge == true && dogs < waveNomber)
        {
            float rand = Random.Range(-3.7f, 2.7f);
            Vector2 randV = new Vector2(8.6f, rand);
            GameObject newDog = Instantiate(dog, randV, Quaternion.identity);
            dogs++;
            tm = 0;
        }

        if (dogs == waveNomber)
        {
            doge = false;
        }

        dogCounter.text = "" + dogs;
    }
}
