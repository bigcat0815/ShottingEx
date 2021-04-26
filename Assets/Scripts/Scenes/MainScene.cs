using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : BaseScene
{

 
    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Main;
        Managers.Map.LoadMap(1);
        
        //UI
        UI_Main scene = Managers.UI.ShowSceneUI<UI_Main>();
        
        //플레이어
        GameObject player = Managers.Resource.Instantiate("Creatures/Player/Player");
        player.name = "Player";
        Managers.Object.Add(player);

    }

    public override void Clear()
    {
        
    }
}
