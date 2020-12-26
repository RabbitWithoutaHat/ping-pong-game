using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int _Speed = 5;

    private Vector2 _StartSpeed;

    public event Action onTouchBottom;
    public Rigidbody2D Rigidbody2D;
    // Start is called before the first frame update
    private void Start()
    {
        _StartSpeed = new Vector2(_Speed, _Speed);
        Rigidbody2D.velocity = _StartSpeed;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        var currentVelocity = Rigidbody2D.velocity;
        currentVelocity = currentVelocity.normalized * _StartSpeed.magnitude;
        Rigidbody2D.velocity = currentVelocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // if (other.gameObject.tag == "Player")
        if (other.gameObject.name == "Bottom")
        {
            // if (onTouchBottom != null)
            // {
            //     onTouchBottom(); 
            // }
            onTouchBottom?.Invoke();
        }

    }
}
