using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grape : Fruit
{
    private float jumpMultipier = 5f;
    public override void PickUpFruit(Player player)
    {
        player.FruitPoint(jumpMultipier);
    }
}