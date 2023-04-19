using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pacman;

    public Transform pellets;
    
    
    public int score { get; private set; }
    
    public int lives { get; private set; }


    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        SetScore(0);
        SetLives(3);
        NewRound();
    }

    private void NewRound()
    {
        foreach (Transform pellet in this.pellets)
        {
            pellets.gameObject.SetActive(true);
        }
        
        ResetState();
    }

    private void ResetState()
    {
        this.pacman.gameObject.SetActive(true);

    }

    private void GameOver()
    {
        this.pacman.gameObject.SetActive(false);
    }
    
    private void SetScore(int score)
    {
        this.score = score;
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
    }


    public void GhostEaten()
    {
        SetScore(this.score + 200);
    }

    public void PacmanEaten()
    {
        
    }
}
