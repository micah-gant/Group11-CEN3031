using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StaminaManager : MonoBehaviour
{
    public static StaminaManager Instance;

    #region Variables

    // Display vals
    public TextMeshProUGUI scoreText;

    // Stamina vals
    public float staminaCap = 120.0f;
    public float maxStamina = 100.0f;
    public float currStamina = 100.0f;
    private float drain = 1.0f;
    #endregion

    // Have starting stamina initialized
    // In update, have stamina decreasing at a steady rate
    // Collection of food (collectible) can alter curr or max stamina
    // Bad food restores 5 stamina but drops max
    // Good food restores 10 stamina and recovers to max stamina

    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        currStamina -= drain * Time.deltaTime;
        if (currStamina > maxStamina)
        {
            currStamina = maxStamina;
        }
        if (maxStamina > staminaCap)
        {
            maxStamina = staminaCap;
        }
        scoreText.GetComponent<TextMeshProUGUI>().text = "STAMINA: " + (currStamina)*1.0f + " OUT OF " + maxStamina;
    }
}
