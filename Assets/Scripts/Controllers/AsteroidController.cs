using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    
    
   [SerializeField] private int _hp = 3;
   [SerializeField] private int _pow = 1 ;
    private float _rot = 10.0f;
    private float _speed = 1.0f;
    [SerializeField] private int _coin =1;
    private int _maxCount = (int)Define.AsteroidsInfo.MaxCount-1;
   [SerializeField] private int _type = (int)Define.AsteroidsInfo.None;
    
    public float Speed { get { return _speed; } }
    public float Rot { get { return _rot; } }
    public int Pow { get { return _pow; } }
    public int Hp { get { return _hp; } private set { _hp = value; } }
    public int Coin { get { return _coin; } }
    public int MAXCount { get { return _maxCount; } }

    public int Type
    {
        get {return _type;}
        set
        {
            _type = value;
            switch (_type)
            {
                case 0:
                case 1:
                    _hp = 3;
                    _speed = 1.0f;
                    _rot = 10.0f;
                    _pow = 1;
                    _coin = 1;
                    break;
                case 2:
                    _hp = 10;
                    _speed = 2.0f;
                    _rot = 15.0f;
                    _pow = 2;
                    _coin = 2;
                    break;
                case 3:
                    _hp = 15;
                    _speed = 2.0f;
                    _rot = 30.0f;
                    _pow = 5;
                    _coin = 3;
                    break;
                case 4:
                    _hp = 20;
                    _speed = 0.5f;
                    _rot = 20.0f;
                    _pow = 15;
                    _coin = 10;
                    break;
            }
        }
    }

    
    private void Start()
    {
        Init();
    }

    void Init()
    { 
       

    }

    void Update()
    {
        OnUpdate();
    }

    void OnUpdate()
    {
        transform.position += Vector3.left *Time.deltaTime * Speed ;
        transform.Rotate(new Vector3(0,0,Time.deltaTime * Rot));
   
    }

   public void OnDamaged(int dmg)
    {
        Hp -= dmg;
        if (Hp <= 0)
            OnDestroyObj();
    }

    void OnDestroyObj()
    {
        // GameObject coin = Managers.Resource.Instantiate("Item/Coin");
        // coin.transform.position = gameObject.transform.position;
        // CoinScript coinScript = coin.GetComponent<CoinScript>();
        // coinScript.CoinSize = Coin;
        //
       
        GameObject explosion = Managers.Resource.Instantiate("Effect/explosion"); 
        explosion.transform.position = gameObject.transform.position;
        Destroy(explosion,1.0f);
       // explosion.GetComponent<Animator>().Play("explosionAnim");

        Managers.Object.Remove(gameObject); 
        Managers.Resource.Destroy(gameObject);
    }
    
}
