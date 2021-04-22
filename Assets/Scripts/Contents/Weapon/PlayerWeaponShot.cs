using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponShot : BaseWeaponShot
{
    protected override void Init()
    {
        Speed = 15.0f;
        Pow = 5;
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Asteroid")
        {
            AsteroidController ac = other.gameObject.GetComponent<AsteroidController>();
            GameObject go = Managers.Resource.Instantiate("Weapon/Effect/PlayerShotEffects");
            go.transform.position = other.gameObject.transform.position;
            Destroy(go,1.0f);
            ac.OnDamaged(Pow);
            
        }
        
        else if (other.gameObject.tag == "Monster")
        {
            MonsterController ec = other.gameObject.GetComponent<MonsterController>();
            
            GameObject go = Managers.Resource.Instantiate("Weapon/Effect/PlayerShotEffects");
            go.transform.position = other.gameObject.transform.position;
            Destroy(go,1.0f);
            ec.OnDamged(Pow);
        }
        
        Managers.Resource.Destroy(gameObject);
    }
    
    
}
