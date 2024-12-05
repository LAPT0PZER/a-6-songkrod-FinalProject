using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    int point = 0;
    public int Point {  get => point; set { point = value; } }

    float jumpForce = 100.0f;
    public float JumpForce {  get => jumpForce; set { jumpForce = value; } }

    float speed = 5.0f;
    public float Speed { get =>  speed; set { speed = value; } }

    protected float originalSpeed;
    float speedBoostDuration = 0.0f;
    float speedBoostTimer = 0.0f;
    bool isSpeedBoostActive = false;

    [SerializeField] TextMeshProUGUI pointText;
    protected void UpdateSpeedBoostTimer()
    {
        if (isSpeedBoostActive)
        {
            speedBoostTimer += Time.deltaTime;
            Debug.Log("+++Speed Boost...");
            if (speedBoostTimer >= speedBoostDuration)
            {
                Speed = originalSpeed;
                isSpeedBoostActive = false;
                Debug.Log("Speed boost ended. Speed reset.");
            }
        }
    }

    public void FruitPoint(int getPoint)
    {
        Point += getPoint;
        Debug.Log($"Get Point {getPoint} Points. Total Point: {Point}");
        UpdatePointText();
    }

    public void FruitPoint(float jumpMultipier)
    {
        JumpForce *= jumpMultipier;
        Debug.Log($"JumpMultiplier boosted by {jumpMultipier * 100}%. New JumpForce: {JumpForce}");
    }

    public void FruitPoint(float speedMultiplier, float duration)
    {

        Speed *= speedMultiplier;
        isSpeedBoostActive = true;
        speedBoostDuration = duration;
        speedBoostTimer = 0.0f;
        Debug.Log($"Speed boosted by {speedMultiplier * 100}% for {duration} seconds.");
    }

    public void UpdatePointText()
    {
        pointText.text = $"{Point}/100 Points";
    }
}
