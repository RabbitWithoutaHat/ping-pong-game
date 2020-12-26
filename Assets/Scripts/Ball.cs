using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int _Speed = 5;

    private Vector2 _StartSpeed;
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
}
