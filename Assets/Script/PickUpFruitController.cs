using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpFruitController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            Fruit fruit = GetComponent<Fruit>();

            if (fruit != null && player != null)
            {
                fruit.PickUpFruit(player);
                Destroy(gameObject);
            }
        }
    }
}
