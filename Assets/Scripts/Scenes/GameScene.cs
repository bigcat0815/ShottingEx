using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameScene : BaseScene
{
    private float ScreenMaxRight;
    private int _asteroidMaxCount =0;
    int _asteroidCount =0;

    private Coroutine _coAsteroidTime;
    private bool _isAsteroid = false;
    protected override void Init()
    {
        base.Init();
        
        //맵
        SceneType = Define.Scene.Game;
        Managers.Map.LoadMap(1);

        //카메라범위
        ScreenMaxRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0)).x;
        
        //UI
        Managers.UI.ShowSceneUI<UI_Coin>();
        
        //플레이어
        GameObject player = Managers.Resource.Instantiate("Creatures/Player/Player");
        player.name = "Player";
        Managers.Object.Add(player);
        
        
        
       //소행성
        _asteroidMaxCount = (int)Define.AsteroidsInfo.MaxCount;
        _asteroidCount = 1;
      

        /*int check = Random.Range(0, 1);
        int enemyCount = 3;
        
        if (check == 0)
        {
            for (int i = 0; i < 2; i++)
            {
                GameObject asteroid = Managers.Resource.Instantiate("Creatures/Other/Asteroid_001");
                asteroid.name = $"Asteroid01_{i+1}";

                Vector3 pos = new Vector3()
                {
                    x = Random.Range(ScreenMaxRight+2, 12),
                    y = Random.Range(-4, 4)
                };
                AsteroidController ac = asteroid.GetComponent<AsteroidController>();
                ac.transform.position = pos;
                ac.Type = 3;
                Managers.Object.Add(asteroid);
            }
        }
        else
        {
            for (int i = 0; i < enemyCount; i++)
            {
                int randomEnemy = Random.Range(0, enemyCount);
                GameObject monster = Managers.Resource.Instantiate($"Creatures/Enemies_{randomEnemy}");
                monster.name = $"Enemies_{i}";

                Vector3 pos = new Vector3()
                {
                    x = Random.Range(ScreenMaxRight+2, 12),
                    y = Random.Range(-4, 4)
                };
              
                
                Managers.Object.Add(monster);
            }
        }*/


        //Managers.UI.ShowSceneUI<UI_Inven>();
        //Dictionary<int, Data.Stat> dict = Managers.Data.StatDict;
        //gameObject.GetOrAddComponent<CursorController>();

        //GameObject player = Managers.Game.Spawn(Define.WorldObject.Player, "UnityChan");
        //Camera.main.gameObject.GetOrAddComponent<CameraController>().SetPlayer(player);

        ////Managers.Game.Spawn(Define.WorldObject.Monster, "Knight");
        //GameObject go = new GameObject { name = "SpawningPool" };
        //SpawningPool pool = go.GetOrAddComponent<SpawningPool>();
        //pool.SetKeepMonsterCount(2);
    }

    private void Update()
    {
        if (_isAsteroid == false)
        {
            _isAsteroid = true;
            _coAsteroidTime = StartCoroutine("AsteroidMake", _asteroidCount);
        }
        
    }

    IEnumerator AsteroidMake(int countNum = 1)
    {
        int typeObj = Random.Range(1, _asteroidMaxCount);
        
        for (int i = 0; i < countNum; i++)
        {
            string typeName = "Asteroid_" + typeObj.ToString("000");
            GameObject asteroid = Managers.Resource.Instantiate($"Creatures/Other/{typeName}");
            asteroid.name = $"Asteroid_{typeName}";

            Vector3 pos = new Vector3()
            {
                x = Random.Range(ScreenMaxRight+2, 12),
                y = Random.Range(-4, 4)
            };
            AsteroidController ac = asteroid.GetComponent<AsteroidController>();
            ac.transform.position = pos;
            ac.Type = typeObj; 
            
            Managers.Object.Add(asteroid);
        }

        yield return new WaitForSeconds(3.0f);
        _coAsteroidTime = null;
        _isAsteroid = false;
    }

    public override void Clear()
    {
        
    }
    
    
}
