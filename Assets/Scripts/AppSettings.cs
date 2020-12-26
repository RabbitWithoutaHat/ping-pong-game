using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppSettings : MonoBehaviour
{
    public GameObject GabePrefab;
    private GameObject _Game;
    private Ball _Ball;
    void Start()
    {
        Application.targetFrameRate = 60;
        RestartGame();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }
    public void RestartGame()
    {
        if (_Game != null)
        {
            Destroy(_Game);
        }
        _Game = Instantiate(GabePrefab, Vector3.zero, Quaternion.identity);
        _Ball = FindObjectOfType<Ball>();

        _Ball.onTouchBottom += RestartGame;
    }
}
