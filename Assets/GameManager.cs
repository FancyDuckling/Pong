using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int scorePlayer1, scorePlayer2;
    public ScoreText scoreTextLeft, scoreTextRight;

    public void OnScoreZoneReached(int id) // id identify wich score zone was hit
    {
        if (id == 1)
        {
            scorePlayer1++;
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }
        if (id == 2)
        {
            scorePlayer2++;
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.Play(); 
        }

        UpdateScores();
    }

    private void UpdateScores()
    {
        scoreTextLeft.SetScore(scorePlayer1);
        scoreTextRight.SetScore(scorePlayer2);
    }
}
