using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 7.0f;
    
    //이동제한
    private Vector3 _min, _max;
    private Vector2 _coliderHalfSize;
    
    void Start()
    {
        Managers.Input.OnKeyAction -= OnKeyInput;
        Managers.Input.OnKeyAction += OnKeyInput;

        _min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        _max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
         Vector2 boxSize = gameObject.GetComponent<BoxCollider2D>().bounds.size;
        _coliderHalfSize = new Vector2(boxSize.x/2 , boxSize.y /2);

    }

    
    void Update()
    {
           
    }

    void OnKeyInput()
    {
        /*if (Input.GetKey(KeyCode.W)) { transform.position += Vector3.up * Time.deltaTime * _speed; }
        if (Input.GetKey(KeyCode.S)) { transform.position += Vector3.down * Time.deltaTime * _speed; }
        if (Input.GetKey(KeyCode.A)) { transform.position += Vector3.left  * Time.deltaTime * _speed; }
        if (Input.GetKey(KeyCode.D)) { transform.position += Vector3.right * Time.deltaTime * _speed; }*/
        
        /*if (Input.GetKey(KeyCode.W)) { transform.Translate(Vector3.up * Time.deltaTime * _speed); }
        if (Input.GetKey(KeyCode.S)) { transform.Translate(Vector3.down * Time.deltaTime * _speed); }
        if (Input.GetKey(KeyCode.A)) { transform.Translate(Vector3.left  * Time.deltaTime * _speed); }
        if (Input.GetKey(KeyCode.D)) { transform.Translate(Vector3.right * Time.deltaTime * _speed); }*/
        

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(x, y, 0).normalized;
        transform.position += dir * Time.deltaTime * _speed;

        float newX = Mathf.Clamp(transform.position.x, _min.x + _coliderHalfSize.x +0.5f, _max.x - _coliderHalfSize.x -0.2f);
        float newY = Mathf.Clamp(transform.position.y, _min.y + _coliderHalfSize.y +0.3f, _max.y - _coliderHalfSize.y -0.2f);
        transform.position = new Vector3(newX, newY, transform.position.z);
        
    }
}
