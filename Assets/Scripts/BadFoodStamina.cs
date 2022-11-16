using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BadFoodStamina : MonoBehaviour
{
    public float recovery = 5;
    public float maxChange = -10;

    void OnTriggerEnter(Collider other)
    {
        StaminaManager.Instance.currStamina = StaminaManager.Instance.currStamina + recovery;
        StaminaManager.Instance.maxStamina = StaminaManager.Instance.maxStamina + maxChange;
        Destroy(gameObject);
    }
}