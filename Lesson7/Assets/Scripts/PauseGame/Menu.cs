using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public void OpenMenu(){
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

}
