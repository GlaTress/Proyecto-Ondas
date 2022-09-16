using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewGame : MonoBehaviour
{
    public InputField profileInput;

    public void Generate()
    {
        string profilename = this.profileInput.text;
        ProfileStorage.CreateNewGame(profilename);

        SceneManager.LoadScene("IslaCentral");
    }
}
