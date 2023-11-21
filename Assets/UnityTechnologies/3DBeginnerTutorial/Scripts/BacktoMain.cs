using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacktoMain : MonoBehaviour
{
    public void BackButtonClick()
    {
        GameManager.instance.GameMenu();
    }
}

