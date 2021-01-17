using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AppSettings : MonoBehaviour
{
    public enum ScreenName
    {
        Menu, Game, Lose, Win
    }

    [Serializable]
    public class UIScreen
    {
        public ScreenName Name;
        public GameObject Screen;
    }

    public TextMeshProUGUI[] ScoreTexts;
    public TextMeshProUGUI TotalScoreText;
    public GameObject GamePrefab;

    [Space]
    public int ScoresToWin = 1;
    public UIScreen[] Screens;

    private GameObject _Game;
    private Ball _Ball;
    private int _Scores;

    public int TotalScores
    {
        get
        {
            return PlayerPrefs.GetInt("TotalScores", 0);
        }
        private set
        {
            PlayerPrefs.SetInt("TotalScores", value);
        }
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        // StartGame();
        // UpdateScores();
        SwitchUI(ScreenName.Menu);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        _Scores = 0;
        UpdateScores();

        if (_Game != null) Destroy(_Game);

        _Game = Instantiate(GamePrefab, Vector3.zero, Quaternion.identity);
        _Ball = FindObjectOfType<Ball>();

        _Ball.onTouchUpper += () => ChangeScores(1);
        _Ball.onTouchBottom += () => ChangeScores(-1);

        SwitchUI(ScreenName.Game);
        AudioManager.instance.PlaySoundByName("Click");
    }

    public void GoToMenu()
    {

        if (_Game != null) Destroy(_Game);
        SwitchUI(ScreenName.Menu);
        AudioManager.instance.PlaySoundByName("Click");
        TotalScoreText.text = "total scores: " + TotalScores.ToString();
    }

    public void GameLose()
    {
        if (_Game != null) Destroy(_Game);
        SwitchUI(ScreenName.Lose);
        AudioManager.instance.PlaySoundByName("Click");
    }

    public void GameWin()
    {
        if (_Game != null) Destroy(_Game);
        SwitchUI(ScreenName.Win);
        AudioManager.instance.PlaySoundByName("Click");
    }

    #region Private

    private void SwitchUI(ScreenName screenName)
    {
        for (int i = 0; i < Screens.Length; i++)
        {
            var item = Screens[i];
            item.Screen.SetActive(item.Name == screenName);

        }
    }

    private void ChangeScores(int value)
    {
        if (value > 0)
        {
            TotalScores += value;
        }
        _Scores += value;
        if (_Scores <= 0)
        {
            _Scores = 0;
            GameLose();
        }
        if (_Scores >= ScoresToWin)
        {
            GameWin();
        }
        UpdateScores();
    }

    private void UpdateScores()
    {
        foreach (var item in ScoreTexts)
        {
            item.text = _Scores.ToString();
        }
        // ScoreText = GameObject.Find("ScoresText").GetComponent<TextMeshProUGUI>();
    }

    #endregion
}
