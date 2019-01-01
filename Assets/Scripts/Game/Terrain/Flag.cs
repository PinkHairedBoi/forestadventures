using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            GetComponentInChildren<Animator>().SetBool("triggered", true);
            FindObjectOfType<GameController>().EndGame();
        }
    }
}
