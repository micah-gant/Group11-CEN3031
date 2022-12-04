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
    [Tooltip("Limit for largest possible value of maxStamina.")]
    public float staminaCap = 120.0f;

    [Tooltip("Limit for smallest possible value of maxStamina.")]
    public float staminaFloor = 30.0f;

    [Tooltip("Current largest stamina value for player. Changed by type of food collected.")]
    public float maxStamina = 100.0f;

    [Tooltip("Current stamina of player.")]
    public float currStamina = 100.0f;

    [Tooltip("Rate of stamina drain.")]
    private float drain = 1.0f;
    #endregion

    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        currStamina -= drain * Time.deltaTime;
        
        // If current stamina overshoots, clamp
        if (currStamina > maxStamina)
        {
            currStamina = maxStamina;
        }

        // If max stamina overshoots, clamp
        if (maxStamina > staminaCap)
        {
            maxStamina = staminaCap;
        }

        // If max stamina undershoots, clamp
        if (maxStamina < staminaFloor)
        {
            maxStamina = staminaFloor;
        }
        scoreText.GetComponent<TextMeshProUGUI>().text = "STAMINA: " + (currStamina) + " OUT OF " + maxStamina;
    }
}
