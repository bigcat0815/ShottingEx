using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Coin : UI_Scene
{
    private Text _coinText;
    private Button _pauseButton;

    public Text CoinUIText
    {
        get { return _coinText; }
        set { _coinText = value; }
    }

    enum Texts
    {
        CoinText,
    }

    enum Buttons
    {
        PauseButton,
    }
    
    void Start()
    {
        Init();
    }
    
    public override void Init()
    {
        base.Init();

        //text
        Bind<Text>(typeof(Texts));
        _coinText = GetText((int) Texts.CoinText);

        Managers.GMex.OnSetUICoin -= SetCoinText;
        Managers.GMex.OnSetUICoin += SetCoinText;
        
        //buttons
        Bind<Button>(typeof(Buttons));
        _pauseButton = GetButton((int) Buttons.PauseButton);
        _pauseButton.gameObject.BindEvent(PauseAction,Define.UIEvent.Click);
        
    }
    
    void SetCoinText(int totalCoin)
    {
        CoinUIText.text = totalCoin.ToString();
    }

    void PauseAction(PointerEventData data)
    {
        Debug.Log("Pause Action Clicked!!");
    }
}
