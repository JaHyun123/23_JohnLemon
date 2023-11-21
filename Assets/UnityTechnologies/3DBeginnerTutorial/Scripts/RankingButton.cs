using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingButton : MonoBehaviour
{
   
    public void RankingButtonClick()
    {
        GameManager.instance.GameRanking();
    }
}

