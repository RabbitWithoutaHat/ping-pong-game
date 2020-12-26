using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Rigidbody2D Rigidbody2D;
    public TextMeshProUGUI TextMeshProUGUI;

    public int Scores = 0;
    private void Start()
    {
        Rigidbody2D = gameObject.GetComponent<Rigidbody2D>();

        TextMeshProUGUI.text = Scores.ToString();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        var worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Rigidbody2D.MovePosition(worldMousePosition);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // if (other.gameObject.tag == "Player")
        if (other.gameObject.GetComponent<Ball>() != null)
        {
            Scores++;
            TextMeshProUGUI.text = Scores.ToString();
        }

    }
}
