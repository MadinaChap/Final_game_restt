using System;
using UnityEngine;

namespace BHSCamp
{
    [RequireComponent(typeof(AudioSource))]
    public class EnemySound : MonoBehaviour
    {
        [SerializeField] private AudioClip _gribSound;
        [SerializeField] private AudioClip _flySound;
        private AudioSource _audioSource;
        private Renderer _renderer;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _renderer = GetComponent<Renderer>();
            if (_audioSource == null)
            {
                Debug.LogError("AudioSource component is missing on this GameObject.");
            }
        }

        public void PlayGribSound()
        {
            if (_gribSound != null && _renderer.isVisible)
            {
                _audioSource.PlayOneShot(_gribSound);
                Debug.Log("Playing Grib Sound");
            }
            else
            {
                Debug.LogWarning("Grib Sound is not assigned or the enemy is not visible.");
            }
        }

        public void PlayFlySound()
        {
            if (_flySound != null && _renderer.isVisible)
            {
                _audioSource.PlayOneShot(_flySound);
                Debug.Log("Playing Fly Sound");
            }
            else
            {
                Debug.LogWarning("Fly Sound is not assigned or the enemy is not visible.");
            }
        }
    }
}
