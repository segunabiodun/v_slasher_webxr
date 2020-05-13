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
    public bool isPaused = true;

    [SerializeField] GameObject startPanel = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        if (Application.isEditor)
        {
            //StartGame();
        }
    }

    public void StartGame()
    {
        if (isPaused)
        {
            startPanel.SetActive(false);
            isPaused = false;
        }
    }
}
