using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace BHSCamp.UI
{
    public class WorldsChooser : MonoBehaviour
    {
        [Header("Levels Data")]
        [SerializeField] private LevelPreviewData[] _levels;

        [FormerlySerializedAs("_levelPreview")]
        [Header("UI fields")] 
        [SerializeField] private Image _preview;
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private Button _playButton;
        [SerializeField] private Image _lock;

        [SerializeField] private GameObject worldsLevelsMenu;

        [SerializeField] private GameObject wallsLevelsMenu;

        private int _currentLevelIndex = 0;

        private void OnEnable()
        {
            ShowLevel(_currentLevelIndex);
            _playButton.onClick.AddListener(OpenLevelMenu);
        }
        private void OnDisable(){
            _playButton.onClick.RemoveListener(OpenLevelMenu);
        }

        private void ShowLevel(int index)
        {
            LevelPreviewData level = _levels[index];
            _preview.sprite = level.Preview;
            _nameText.text = level.Name;
            _playButton.gameObject.SetActive(true);
            _lock.enabled = false;
        }

        public void ShowPreviousLevel() => ShowLevel(
            _currentLevelIndex = (_currentLevelIndex - 1 + _levels.Length) % _levels.Length
        );

        public void ShowNextLevel() => ShowLevel(
            _currentLevelIndex = (_currentLevelIndex + 1) % _levels.Length
        );

        private void OpenLevelMenu(){
            if(_currentLevelIndex == 0){
                worldsLevelsMenu.SetActive(true);
                wallsLevelsMenu.SetActive(false);
            }
            else if(_currentLevelIndex == 1){
                wallsLevelsMenu.SetActive(true);
                worldsLevelsMenu.SetActive(false);
            }
        }
    }
}