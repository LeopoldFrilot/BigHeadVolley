using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject PauseCanvas;
    public bool isPaused = false;

    public void Pause()
    {
        PauseCanvas.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }
    public void Resume()
    {
        PauseCanvas.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }
}
