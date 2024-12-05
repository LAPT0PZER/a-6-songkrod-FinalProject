using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class End : MonoBehaviour
{
    [SerializeField] GameObject gameOver;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameOver.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
