using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinished : MonoBehaviour
{
    private GameObject _scoreCanvas, _levelFinishedCanvas;
    private bool _isLevelFinished;
    private void Awake()
    {
        Initialization();
    }

    private void Start()
    {
        _levelFinishedCanvas.SetActive(false);
    }

    private void Update()
    {
        if (_isLevelFinished)
        {
            if (Input.GetButtonDown("Jump"))
            {
                _levelFinishedCanvas.SetActive(false);
                _scoreCanvas.SetActive(true);
                Player.MagnetPlayer.isPlayerStopped = false;
                if (CanvasManager.Canvas.currentLevelNumber > 1 && CanvasManager.Canvas.currentLevelNumber % 3 == 1)
                {
                    SceneManager.LoadScene(0);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Stop Player
            Player.MagnetPlayer.isPlayerStopped = true;
            //Change Screen
            _scoreCanvas.SetActive(false);
            _levelFinishedCanvas.SetActive(true);
            _isLevelFinished = true;
        }
    }

    void Initialization()
    {
        _scoreCanvas = GameObject.FindGameObjectWithTag("ScoreCanvas");
        _levelFinishedCanvas = GameObject.FindGameObjectWithTag("LevelFinishedCanvas");
    }
}
