using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 7.0f;
    void Start()
    {
        Managers.Input.OnKeyAction -= OnKeyInput;
        Managers.Input.OnKeyAction += OnKeyInput;

        Vector3 worldPos = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        print(worldPos);

    }

    
    void Update()
    {
        
    }

    void OnKeyInput()
    {
        if (Input.GetKey(KeyCode.W)) { transform.position += Vector3.up * Time.deltaTime * _speed; }
        if (Input.GetKey(KeyCode.S)) { transform.position += Vector3.down * Time.deltaTime * _speed; }
        if (Input.GetKey(KeyCode.A)) { transform.position += Vector3.left  * Time.deltaTime * _speed; }
        if (Input.GetKey(KeyCode.D)) { transform.position += Vector3.right * Time.deltaTime * _speed; }

        /*float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(x, y, 0).normalized;
        transform.position += dir * Time.deltaTime * _speed;*/
        
    }
}
