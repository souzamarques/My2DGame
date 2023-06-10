using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public TextMeshProUGUI healthText;

    // Awake is called before the Start
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLives(int value)
    {
        healthText.text = "x" + value.ToString();
    }
}
