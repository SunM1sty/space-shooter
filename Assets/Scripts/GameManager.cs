using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _scoreText;

    [SerializeField] 
    private GameObject gameoverScreen;

    private int _score;

    private void Start()
    {
        StartGame();
    }

    public void IncreaseScore()
    {
        _score++;
        _scoreText.text = _score.ToString();
    }

    public void GameOver()
    {
        gameoverScreen.SetActive(true);
    }

    public void StartGame()
    {
        gameoverScreen.SetActive(false);
    }
}
