using UnityEngine;
using UnityEngine.SceneManagement;

public class Placeholder_DiedUI : MonoBehaviour
{
    
    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
