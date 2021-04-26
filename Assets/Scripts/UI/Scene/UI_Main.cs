using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class UI_Main : UI_Scene
{
    enum Buttons
    {
        StartButton,
        QuitButton
    }
    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        
        Bind<Button>(typeof(Buttons));
        GameObject start = GetButton((int) Buttons.StartButton).gameObject;
        GameObject quit = GetButton((int) Buttons.QuitButton).gameObject;
        
        start.BindEvent(Start);
        quit.BindEvent((PointerEventData data) =>
        {
            Application.Quit();
        });
        
    }

    void Start(PointerEventData data)
    {
        SceneManager.LoadScene("Scenes/Game");
    }
    
}
