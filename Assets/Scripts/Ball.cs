using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public Rigidbody2D Rigidbody2D;

    [SerializeField] private int _Speed = 5;

    private Vector2 _StartSpeed;

    public event Action onTouchBottom;
    public event Action onTouchUpper;

    private void Start()
    {
        Restart();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        var currentVelocity = Rigidbody2D.velocity;
        currentVelocity = currentVelocity.normalized * _StartSpeed.magnitude;
        Rigidbody2D.velocity = currentVelocity;
    }

    private void Restart()
    {
        var x = Random.value > 0.5f ? _Speed : -_Speed;
        var y = Random.value > 0.5f ? _Speed : -_Speed;
        _StartSpeed = new Vector2(x, y);
        Rigidbody2D.velocity = _StartSpeed;
        Rigidbody2D.position = Vector3.zero;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        AudioManager.instance.PlaySoundByName("Hit");
        // if (other.gameObject.tag == "Player")
        if (other.gameObject.name == "Bottom")
        {
            onTouchBottom?.Invoke();
            Restart();
            AudioManager.instance.PlaySoundByName("ScoresDown");
        }
        if (other.gameObject.name == "Upper")
        {
            onTouchUpper?.Invoke();
            Restart();
            AudioManager.instance.PlaySoundByName("ScoresUp");
        }

    }
}
