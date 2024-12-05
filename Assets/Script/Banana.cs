using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : Fruit
{
    private int healthIncrease;

    private void Start()
    {
        healthIncrease = 20;
    }
    public override void PickUpFruit(Player player)
    {
        player.FruitPoint(healthIncrease);
    }
}
