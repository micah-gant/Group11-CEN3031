using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StaminaSystem : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        StaminaManager.Instance.collected = StaminaManager.Instance.collected + 5;
        Destroy(gameObject);
    }
}