using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager 
{
    
    private List<GameObject> _gameObjects = new List<GameObject>();

    public void Add(GameObject go)
    {
        _gameObjects.Add(go);        
    }

    public void Remove(GameObject go)
    {
        _gameObjects.Remove(go);
    }

    //Todo 
    // 해당 객체의 위치를 찾아서 유도무기등 다양하게 활용 될 수 있다.
    
    /*public GameObject Find(Vector3Int cellPos)
    {
        foreach (GameObject obj in _gameObjects)
        {
            CreatureController cc = obj.GetComponent<CreatureController>();
            
            if (cc == null) continue;

            if (cc.CellPos == cellPos)
                return obj;
        }
        return null;
    }

    public GameObject Find(Func<GameObject, bool> condition)
    {
        foreach (GameObject obj in _gameObjects)
        {
            if (condition.Invoke(obj))
                return obj;
        }
        return null;
    }*/
    
    
    public void Clear()
    {
        _gameObjects.Clear();
        
    }
}
