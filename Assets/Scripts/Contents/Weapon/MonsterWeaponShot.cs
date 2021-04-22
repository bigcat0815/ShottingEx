using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWeaponShot : BaseWeaponShot
{
    
    protected override void Init()
    {
        
    }


    protected override void OnUpdate()
    {
        transform.position += Vector3.left *Time.deltaTime * Speed ;
    }

 
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerController pc = other.gameObject.GetComponent<PlayerController>();
            GameObject go = Managers.Resource.Instantiate("Weapon/Effect/PlayerShotEffects");
            go.transform.position = other.gameObject.transform.position;
            Destroy(go,1.0f);
            pc.OnDamged(Pow);
            
        }
    }
}
