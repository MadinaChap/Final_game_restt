using UnityEngine;
using UnityEngine.SceneManagement;

public class ReastartGame : MonoBehaviour
{
    public void ReastartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        Time.timeScale = 1f;
    }
}
