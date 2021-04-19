using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_Space : BackGround_Base
{
    enum Objects
    {
        bg1,
        bg2,
        star1,
        star2,
        star3
    }

    void Start()
    {
        Init();   
    }

    public override void Init()
    {
        Bind(typeof(Objects));
    }
    
    void Update()
    {
        Moving(_objects[0], _speed,BGType.MainBG);
        Moving(_objects[1], _speed,BGType.MainBG);
        Moving(_objects[2], _speed,BGType.SubBG);
        Moving(_objects[3], _speed,BGType.SubBG);
        Moving(_objects[4], _speed,BGType.SubBG);
    }
    
}
