using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindArea : MonoBehaviour
{
    public GameObject angryArea;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        angryArea.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        angryArea.SetActive(true);
    }
}
