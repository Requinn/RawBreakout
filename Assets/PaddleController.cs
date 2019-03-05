using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : Block
{
    private Vector3 _movement = new Vector3(1, 0, 0);
    private float _speed = .03f;
    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > -2.2f && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))) {
            transform.position += _movement * -_speed;
        }
        if (transform.position.x < 2.2f && (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))) {
            transform.position += _movement * _speed;
        }
    }
}
