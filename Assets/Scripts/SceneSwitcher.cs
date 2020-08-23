using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ReloadGame()
    {
        var singletons = FindObjectsOfType<Singleton>();
        if (singletons.Length > 0)
        {
            foreach (Singleton singleton in singletons)
            {
                Destroy(singleton.gameObject);
            }
        }
        SceneStatics.winner = 0;
        SceneManager.LoadScene(0);
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
