using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GameManagerEX
{
    public Action<int> OnSetUICoin;

    #region Gold
    
    //총 Gold
    private int _coinTotal = 0;
    public int CoinTotal
    {
        get
        {
            _coinTotal = PlayerPrefs.GetInt("TotalCoin", 0);
            return _coinTotal;
        }
        set
        {
            _coinTotal += value;
            PlayerPrefs.SetInt("TotalCoin", _coinTotal);
            
            OnSetUICoin.Invoke(_coinTotal);
        }
    }
    
    // 게임내의 획득 골드
    private int _coinInGame = 0;
    public int CoinInGame
    {
        get { return _coinInGame; } 
        set { _coinInGame += value; }
    }

    public void GetGameInCoin()
    {
        Debug.Log($"현재코인 코인 {CoinTotal}");
        Debug.Log($"토탈 코인 {CoinTotal}");
    }
    
    #endregion

}
