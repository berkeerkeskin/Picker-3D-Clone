using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinished : MonoBehaviour
{
    [SerializeField] private GameObject scoreCanvas, levelFinishedCanvas;
    private bool _isLevelFinished;
    private void Awake()
    {
        levelFinishedCanvas.SetActive(false);
    }

    private void Update()
    {
        if (_isLevelFinished)
        {
            if (Input.GetButtonDown("Jump"))
            {
                levelFinishedCanvas.SetActive(false);
                scoreCanvas.SetActive(true);
                Player.MagnetPlayer.isPlayerStopped = false;
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
            scoreCanvas.SetActive(false);
            levelFinishedCanvas.SetActive(true);
            _isLevelFinished = true;
        }
    }
}
