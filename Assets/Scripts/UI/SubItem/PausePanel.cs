using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanel : UI_Base
{
    private Button _mainMenuButton;
    private Button _resumeButton;
    
    private string _name;
    
    enum Texts
    {
        MainMenuText,
        ResumeText,
    }
    
    enum Buttons
    {
        ResumeButton,
        MainMenuButton
    }
    
    enum GameObjects
    {
        PausePanel,
    }

    void Start()
    {
        Init();
    }
    
    public override void Init()
    {
        
        Bind<GameObject>(typeof(GameObjects));
        GameObject pausePanel = Get<GameObject>((int) GameObjects.PausePanel);
        
        Bind<Button>(typeof(Buttons));
        _resumeButton = GetButton((int) Buttons.ResumeButton);
        _resumeButton.gameObject.BindEvent( (PointerEventData data)=>
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
            
        },Define.UIEvent.Click);
        
        _mainMenuButton = GetButton((int) Buttons.MainMenuButton);
        _mainMenuButton.gameObject.BindEvent( (PointerEventData data)=>
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
            SceneManager.LoadScene("Scenes/Main");

        },Define.UIEvent.Click);
        
        /*Bind<GameObject>(typeof(GameObjects));

        GetGameObject((int) GameObjects.ItemNameText).GetComponent<Text>().text = _name;
        
        GetGameObject((int) GameObjects.ItemIcon).AddUIEvent((PointerEventData data) =>
        {
            Debug.Log($"아이템 클릭 :{_name}");   
        });*/
    }

    public void SetInfo(string name)
    {
        _name = name;
    }

}
