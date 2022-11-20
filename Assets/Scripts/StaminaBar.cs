using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] StaminaManager staminaManager;

    public Slider staminaBar;


    void Start()
    {
        staminaBar.maxValue = staminaManager.maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        staminaBar.value = staminaManager.currStamina;
        Debug.Log(staminaManager.currStamina);
    }
}
