using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawnManager : MonoBehaviour
{
    public static FoodSpawnManager Instance;

    public GameObject GoodFood;
    public GameObject BadFood;
    public LayerMask objLayer;
    public LayerMask terrainLayer;

    #region Variables

    //////////////////////////////////////////////////////////
    [Header("Food Quantity")]
    //////////////////////////////////////////////////////////
    [Tooltip("Max amount of food that can be on map.")]
    public int maxFood = 3;

    [Tooltip("Number of food objects active on map.")]
    [HideInInspector] public int foodSpawnedCount = 0;

    //////////////////////////////////////////////////////////
    [Header("Spawn Timing")]
    //////////////////////////////////////////////////////////
    [Tooltip("Langth of grace period before food is spawned, if applicable.")]
    public float spawnTimeLength = 5.0f;

    [Tooltip("Current time passed since last food spawn. Will be -1 if all food is spawned.")]
    [HideInInspector] public float currTimeLength = 0.0f;

    //////////////////////////////////////////////////////////
    [Header("Spawn Boundaries")]
    //////////////////////////////////////////////////////////
    public Vector3 center = new Vector3 (0, 0, 0);
    public float x_Radius = 5;
    public float y_Max = 0;
    public float z_Radius = 5;
    public float foodLength = 1;
    public float y_distance = 1.0f;

    //////////////////////////////////////////////////////////
    [Header("Miscellaneous")]
    //////////////////////////////////////////////////////////
    [Tooltip("Percent chance of good food spawning. Out of 100.")]
    public int goodFoodSpawnChance = 30;

    #endregion

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        // If the time limit was reached, spawn food.
        if (currTimeLength > spawnTimeLength)
        {
            // Reset timer
            currTimeLength = 0.0f;

            // Generate spawn position for object
            float off = foodLength / 2;
            float spawnPosX = Random.Range(center.x -x_Radius + off, center.x + x_Radius - off);
            float spawnPosZ = Random.Range(center.z - z_Radius + off, center.z + z_Radius - off);
            Vector3 foodSpawnPos = new Vector3(spawnPosX, (y_Max * 2) + 5, spawnPosZ);

            // Check for overlaps
            bool noCollide = false;
            while (!noCollide)
            {
                RaycastHit hit;

                // Looks to see if raycast hits any food objects underneath new one
                if (Physics.Raycast(foodSpawnPos, Vector3.down, out hit, (y_Max * 2) + 10, objLayer))
                {
                    // Hit found, recalculate position
                    spawnPosX = Random.Range(center.x - x_Radius + off, center.x + x_Radius - off);
                    spawnPosZ = Random.Range(center.z - z_Radius + off, center.z + z_Radius - off);
                    foodSpawnPos = new Vector3(spawnPosX, (y_Max * 2) + 5, spawnPosZ);
                }
                else
                {
                    // No hit underneath, valid for object creation
                    noCollide = true;
                }
            }

            // Calculate height of food so it's always a fixed amount above terrain
            float terrainPos;
            RaycastHit terrHit;

            // Set hit information for where raycast from object hits terrain
            Physics.Raycast(foodSpawnPos, Vector3.down, out terrHit, (y_Max * 2) + 10, terrainLayer);
            // Set hit position to terrainPos
            terrainPos = terrHit.point.y;

            foodSpawnPos.y = terrainPos + y_distance + off;

            // Create object
            GameObject newFood;
            // Generate food type based on percent chance calculation
            int foodPicker = Random.Range(1, 101);
            if (foodPicker <= goodFoodSpawnChance)
            {
                newFood = Instantiate(GoodFood, foodSpawnPos, Quaternion.identity);
            }
            else
            {
                newFood = Instantiate(BadFood, foodSpawnPos, Quaternion.identity);
            }
            foodSpawnedCount++;

            // The food object will have its properties set in their respecitve scripts.
            // Destruction of the object also happens internally upon collection.
            // Object will also access timer and count vars and update if the queue is full.

            // If limit is reached from this pass, stall timer
            if (foodSpawnedCount == maxFood)
            {
                currTimeLength = -1.0f;
            }
        }
        // Else if the current timer is running, increment
        if (currTimeLength != -1.0f)
        {
            currTimeLength += Time.deltaTime;
        }
    }
}
