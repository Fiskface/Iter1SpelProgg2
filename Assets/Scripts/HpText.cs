using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HpText : MonoBehaviour
{
    private TextMeshProUGUI TMP;
    
    void Start()
    {
        TMP = GetComponent<TextMeshProUGUI>();
    }
    
    void Update()
    {
        TMP.text = $"HP: {StaticValues.lives}";
    }
}
