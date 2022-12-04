using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BadFoodStamina : MonoBehaviour
{
    public float recovery = 5;
    public float maxChange = -10;

    // Despawn properties
    public float despawnTime = 7.0f;
    private float currTime = 0.0f;

    void Update()
    {
        // If time in game exceeds despawn limit, delete object
        if (currTime > despawnTime)
        {
            // If stalled, set to 0
            if (FoodSpawnManager.Instance.currTimeLength == -1.0f)
            {
                FoodSpawnManager.Instance.currTimeLength = 0.0f;
            }
            FoodSpawnManager.Instance.foodSpawnedCount = FoodSpawnManager.Instance.foodSpawnedCount - 1;
            Destroy(gameObject);
        }
        else
        {
            currTime += Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Update stamina
        StaminaManager.Instance.currStamina = StaminaManager.Instance.currStamina + recovery;
        StaminaManager.Instance.maxStamina = StaminaManager.Instance.maxStamina + maxChange;

        // Update food object spawn information
        FoodSpawnManager.Instance.currTimeLength = 0.0f;
        FoodSpawnManager.Instance.foodSpawnedCount = FoodSpawnManager.Instance.foodSpawnedCount - 1;
        Destroy(gameObject);
    }
}