using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strawberry : Fruit
{
    private float speedMultiplier = 1.5f;
    private float duration = 5.0f;
    public override void PickUpFruit(Player player)
    {
        player.FruitPoint(speedMultiplier,duration);
    }
}
