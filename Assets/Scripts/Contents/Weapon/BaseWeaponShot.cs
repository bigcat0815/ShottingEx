﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public abstract class BaseWeaponShot : MonoBehaviour
{
    
    private float _speed = 10.0f;
    public virtual float Speed { get { return _speed; } set { _speed = value; } }
    
    
    void Start()
    {
        Init();
        BaseDestroy();

    }
    void Update()
    {
        OnUpdate();
    }

    protected abstract void Init();
    
    protected virtual void OnUpdate() 
    {
        transform.position += Vector3.right *Time.deltaTime * Speed ;
    }

    protected virtual void BaseDestroy()
    {
        if (gameObject != null)
        {
            Object.Destroy(gameObject,2.0f);;
        }
    }
}
