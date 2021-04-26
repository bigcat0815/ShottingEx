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

    enum GameObjects
    {
        //ItemPanel,
        PausePanel,
    }
    
    void Start()
    {
        Init();
    }
    
    public override void Init()
    {
        base.Init();

        //2. GameObjects - visual만 제어
        Bind<GameObject>(typeof(GameObjects));
        GameObject pausePanel = Get<GameObject>((int) GameObjects.PausePanel);
        pausePanel.SetActive(false);
        
        //text
        Bind<Text>(typeof(Texts));
        _coinText = GetText((int) Texts.CoinText);

        Managers.GMex.OnSetUICoin -= SetCoinText;
        Managers.GMex.OnSetUICoin += SetCoinText;
        
        //buttons
        Bind<Button>(typeof(Buttons));
        _pauseButton = GetButton((int) Buttons.PauseButton);
        _pauseButton.gameObject.BindEvent(PauseAction,Define.UIEvent.Click);
        
       
        
        //1. GameObjects - subItem 관계가 있을때;
        //현재 화면이 앵커가 잘 붙지 않아 일단 보류
        /*Bind<GameObject>(typeof(GameObjects));
        GameObject itemPanel = Get<GameObject>((int) GameObjects.ItemPanel);
        foreach (Transform child in itemPanel.transform)
        {
            Managers.Resource.Destroy(child.gameObject);
        }*/
        
      
    }
    
    void SetCoinText(int totalCoin)
    {
        CoinUIText.text = totalCoin.ToString();
    }

    void PauseAction(PointerEventData data)
    {
        
        GameObject pausePanel = Get<GameObject>((int) GameObjects.PausePanel);
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        
        PausePanel pauseScript = pausePanel.GetOrAddComponent<PausePanel>();
        
        
        /* //1. GameObject item 보류
        GameObject itemPanel = Get<GameObject>((int) GameObjects.ItemPanel);
        foreach (Transform child in itemPanel.transform)
        {
            Managers.Resource.Destroy(child.gameObject);
        }
        
        GameObject _pauseItem = Managers.UI.MakeSubItem<PausePanel>(itemPanel.transform).gameObject;
        _pauseItem.transform.SetParent(itemPanel.transform);
        Time.timeScale = 0;
        */
        
        /*Debug.Log($"itemPanel Pos : {itemPanel.transform.position}");
        Debug.Log($"_pauseItem Pos : {_pauseItem.transform.position}");
       _pauseItem.transform.position = new Vector3(0, 0, 0);
       itemPanel.transform.position = new Vector3(0, 0, 0);*/
        //_pauseItem.SetActive(true);
        
        //PausePanel pauseScript = pauseItem.GetOrAddComponent<PausePanel>();


    }
    
}
