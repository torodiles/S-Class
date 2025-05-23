using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    public void ExitGame()
    {
        Application.Quit();
    }
}
