using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EscapeMenu : MonoBehaviour
{
    public Button escape;
    public Button menu;
    public bool EscapeMenuOpen;

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(EscapeMenuOpen == false){
                EscapeMenuOpen = true;
                escape.gameObject.SetActive(true);
                menu.gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
            else{
                EscapeMenuOpen = false;
                escape.gameObject.SetActive(false);
                menu.gameObject.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }

    public void Escape(){
        Application.Quit();
    }
    public void Menu(){
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
}
