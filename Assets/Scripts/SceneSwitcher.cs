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
        DestroySingletons();
        SceneStatics.winner = 0;
        SceneManager.LoadScene(0);
    }
    public void LoadVersus()
    {
        SceneManager.LoadScene(4);
    }
    public void LoadWinScreen()
    {
        DestroySingletons();
        SceneManager.LoadScene("Win");
    }
    public void LoadLoseScreen()
    {
        DestroySingletons();
        SceneManager.LoadScene("Lose");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void DestroySingletons()
    {
        var singleton = FindObjectOfType<Singleton>();
        if (singleton)
        {
            Destroy(singleton.gameObject);
        }
    }
}
