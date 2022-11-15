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
    public float collected = 100.0f;

    // Stamina vals
    //private const int staminaCap = 100;
    //private int maxStamina;
    //private int currStamina;
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
        collected = 100.0f;
        //maxStamina = 100;
        //currStamina = 100;
    }

    // Update is called once per frame
    void Update()
    {
        collected -= drain * Time.deltaTime;
        scoreText.GetComponent<TextMeshProUGUI>().text = "COLLECTED: " + collected;
    }
}
