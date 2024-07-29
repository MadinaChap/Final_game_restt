
using UnityEngine;

public class pause : MonoBehaviour
{
    public GameObject panel;

    public void Pause()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audios){
            if(a.isPlaying){
                a.Pause();
            }
        }
    }
}
