using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI TMP;
    
    // Start is called before the first frame update
    void Start()
    {
        TMP = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        TMP.text = $"{StaticValues.score}";
    }
}
