using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    
    public enum Scene
    {
        Unknown,
        Login,
        Lobby,
        Game,
        Main,
    }

    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount,
    }

    public enum UIEvent
    {
        Click,
        Drag,
    }
    
    public enum AsteroidsInfo
    {
        None,
        Asteroid_001,
        Asteroid_002,
        Asteroid_003,
        Asteroid_004,
        MaxCount
    }
}
