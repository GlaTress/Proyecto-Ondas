using UnityEngine;
using UnityEngine.SceneManagement;
public class ProfileNavigator : MonoBehaviour
{
   public void GoToNewGame()
    {
        SceneManager.LoadScene("P_NewGame");
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Scene");
    }
}
