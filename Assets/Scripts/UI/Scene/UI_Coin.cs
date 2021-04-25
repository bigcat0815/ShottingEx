using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Coin : UI_Scene
{
    private Text _coinText;

    public Text CoinUIText
    {
        get { return _coinText; }
        set { _coinText = value; }
    }

    enum Texts
    {
        CoinText,
    }
    
    void Start()
    {
        Init();
    }
    
    public override void Init()
    {
        base.Init();
        Bind<Text>(typeof(Texts));
        _coinText = GetText((int) Texts.CoinText);

        Managers.GMex.OnSetUICoin -= SetCoinText;
        Managers.GMex.OnSetUICoin += SetCoinText;
    }

    void SetCoinText(int totalCoin)
    {
        CoinUIText.text = totalCoin.ToString();
    }
}
