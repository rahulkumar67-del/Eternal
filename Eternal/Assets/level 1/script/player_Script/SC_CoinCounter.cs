using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import the TextMeshPro namespace

public class SC_CoinCounter : MonoBehaviour
{
    TextMeshProUGUI counterText; // Use TextMeshProUGUI instead of Text

    // Start is called before the first frame update
    void Start()
    {
        counterText = GetComponent<TextMeshProUGUI>();
        counterText.text = "0";
        // Get the TextMeshProUGUI component
        if (counterText == null)
        {
            Debug.LogError("TextMeshProUGUI component not found on the GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Ensure counterText is not null
        if (counterText != null)
        {
            // Set the current number of coins to display
            if (counterText.text != SC_2DCoin.totalCoins.ToString())
            {
                counterText.text = SC_2DCoin.totalCoins.ToString();
            }
        }
        else
        {
            Debug.LogError("counterText is null in Update method.");
        }
    }
}
