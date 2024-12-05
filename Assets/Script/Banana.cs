using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : Fruit
{
    private int getPoint;

    private void Start()
    {
        getPoint = 10;
    }
    public override void PickUpFruit(Player player)
    {
        player.FruitPoint(getPoint);
    }
}
