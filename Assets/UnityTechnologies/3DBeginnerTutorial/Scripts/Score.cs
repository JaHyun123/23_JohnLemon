using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    TMP_Text text;
    public static int coinAmount;

    void Start()
    {
        coinAmount = 0;
        if (text == null)
            text = GameObject.Find("Score").GetComponent<TMP_Text>();
        text.text = coinAmount.ToString();
    }
    private void Update()
    {
        text.text = coinAmount.ToString();
    }
}
