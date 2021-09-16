using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModileControl : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private float hz;
    private float vt;
    public Sprite[] sprites;
    private SpriteRenderer sr;
    public GameObject bomb;
    public GameObject defeatedPig;
    public int bombPower = 1;
    public int bombCount = 1;
    public int bcnt;
    public Text bombCounter;
    public VariableJoystick variableJoystick;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        bcnt = bombCount;
    }

    private void Update()
    {
        bombCounter.text = "X" + bcnt;
        
        if (variableJoystick.Horizontal > 0 && variableJoystick.Horizontal > variableJoystick.Vertical)
        {
            sr.sprite = sprites[0];
        }
        else if (variableJoystick.Horizontal < 0 && variableJoystick.Horizontal < variableJoystick.Vertical)
        {
            sr.sprite = sprites[1];
        }
        else if (variableJoystick.Vertical > 0)
        {
            sr.sprite = sprites[2];
        }
        else if (variableJoystick.Vertical < 0)
        {
            sr.sprite = sprites[3];
        }

        if (Input.GetKeyDown(KeyCode.Space) && bcnt > 0)
        {
            Instantiate(bomb, gameObject.transform.position, Quaternion.identity);
            bcnt--;
        }
    }

    public void Bomb()
    {
        if (bcnt > 0)
        {
            Instantiate(bomb, gameObject.transform.position, Quaternion.identity);
            bcnt--;
        }
    }

    void FixedUpdate()
    {
        Vector2 vc = Vector2.up * variableJoystick.Vertical + Vector2.right * variableJoystick.Horizontal; //передвижение
        rb.velocity = vc * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<TimeDeleter>())
        {
            Instantiate(defeatedPig, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Dog>())
        {
            Instantiate(defeatedPig, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
