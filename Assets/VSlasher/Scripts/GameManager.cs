using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    /// <summary>
    /// The 'Preload Scene' method is mostly preferred over Singletons but I decided
    /// to keep things simple for this single scene WebXR game. Check
    /// https://stackoverflow.com/a/35891919/9261590 for how to implement this.
    /// </summary>
    public static GameManager instance;
    public static bool isPaused = true;
    public static int score = 0;

    [SerializeField] GameUI gameUI = null;
    [SerializeField] Shooter shooter = null;
    public bool isDemo { get; private set; } = true;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        //DEBUG: 
        if (Application.isEditor)
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        if (isPaused)
        {
            shooter.InitializeShooterMode();
            isPaused = false;
            gameUI.UpdateForStartGame();
        }
    }
}
