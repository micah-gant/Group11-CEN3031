using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GoodFoodStamina : MonoBehaviour
{
    public float recovery = 10;
    public float maxChange = 5;

    void OnTriggerEnter(Collider other)
    {
        StaminaManager.Instance.currStamina = StaminaManager.Instance.currStamina + recovery;
        StaminaManager.Instance.maxStamina = StaminaManager.Instance.maxStamina + maxChange;
        Destroy(gameObject);
    }
}