using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public Action OnKeyAction = null;

    public void OnUpdate()
    {
        if (Input.anyKey && OnKeyAction != null)
            OnKeyAction.Invoke();
    }

}
