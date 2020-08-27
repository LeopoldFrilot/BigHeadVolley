using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ReloadGame()
    {
        var singleton = FindObjectOfType<Singleton>();
        if (singleton)
        {
            Destroy(singleton.gameObject);
        }
        SceneStatics.winner = 0;
        SceneManager.LoadScene(0);
    }
    public void LoadVersus()
    {
        SceneManager.LoadScene("Head Ball Volley Game");
    }
    public void LoadWinScreen()
    {
        var singleton = FindObjectOfType<Singleton>();
        if (singleton)
        {
            Destroy(singleton.gameObject);
        }
        SceneManager.LoadScene("Win");
    }
    public void LoadLoseScreen()
    {
        var singleton = FindObjectOfType<Singleton>();
        if (singleton)
        {
            Destroy(singleton.gameObject);
        }
        SceneManager.LoadScene("Lose");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
