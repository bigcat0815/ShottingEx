using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public abstract class BackGround_Base : MonoBehaviour
{
    protected List<GameObject> _objects = new List<GameObject>();
    protected float _speed = 1.5f;

    protected enum BGType
    {
        MainBG,
        SubBG
    }
    
    public abstract void Init();
    
    protected virtual void Bind(Type type)
    {
        string[] names = Enum.GetNames(type);
        GameObject[] obj = new  GameObject[names.Length];
        
        for (int i = 0; i < names.Length; i++)
        {
            obj[i] = Util.FindChild(gameObject, names[i], true);
            _objects.Add(obj[i]);
        }
    }
    
    protected virtual void Moving(GameObject gameObject, float speed ,BGType type,int bgNums =2)
    {
        if (type == BGType.MainBG)
            bgNums = 2;
        else if(type == BGType.SubBG)
            bgNums = 3;

        SpriteRenderer spr = gameObject.GetComponent<SpriteRenderer>();
        
        gameObject.transform.position += Vector3.left * Time.deltaTime * speed;
        Vector3 pos = gameObject.transform.position;
        if (pos.x + spr.bounds.size.x / 2 < -8)
        {
            float size = spr.bounds.size.x * bgNums;
            pos.x += size;
            gameObject.transform.position = pos;
        }
    }
}
