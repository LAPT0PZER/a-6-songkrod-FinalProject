using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int health = 10;
    public int Health => health;

    float jumpForce = 10.0f;
    public float JumpForce => jumpForce;

    float speed = 5.0f;
    public float Speed => speed;

    float originalSpeed;
    float speedBoostDuration = 0.0f;
    float speedBoostTimer = 0.0f;
    bool isSpeedBoostActive = false;

    void Start()
    {
        originalSpeed = speed;
    }

    void Update()
    {
        
    }

    void UpdateSpeedBoostTimer()
    {
        if (isSpeedBoostActive)
        {
            speedBoostTimer += Time.deltaTime;
            Debug.Log("+++Speed Boost...");
            if (speedBoostTimer >= speedBoostDuration)
            {
                speed = originalSpeed;
                isSpeedBoostActive = false;
                Debug.Log("Speed boost ended. Speed reset.");

            }
        }
    }

    public void FruitPoint(int healthIncrease)
    {
        health += healthIncrease;
        Debug.Log($"Health increased by {healthIncrease}. New health: {health}");
    }

    public void FruitPoint(float jumpMultipier)
    {
        jumpForce += jumpMultipier;
        Debug.Log($"Strength  increased by {jumpMultipier * 100}%. New Strength: {jumpForce}");
    }

    public void FruitPoint(float speedMultiplier, float duration)
    {
        speed *= speedMultiplier;
        isSpeedBoostActive = true;
        speedBoostDuration = duration;
        speedBoostTimer = 0.0f;
        Debug.Log($"Speed boosted by {speedMultiplier * 100}% for {duration} seconds.");
    }

}
