
using UnityEngine;

public class ContinueGame : MonoBehaviour
{
    public GameObject panel;

    public void continueGame(){
        Time.timeScale = 1f;
        panel.SetActive(false);
    }
}
