﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager 
{
    
    public void LoadMap(int mapId)
    {
        DestroyMap();

        string mapName = "background_" + mapId.ToString("000");
        GameObject go = Managers.Resource.Instantiate($"Map/{mapName}");
        go.name = "@Map";
        
    }

    public void DestroyMap()
    {
        GameObject map = GameObject.Find("@Map");
        if (map != null)
        {
            GameObject.Destroy(map);
        }
    }
}
