using UnityEngine;

namespace BHSCamp.UI
{
    public class HundlerLevelsMenu : MonoBehaviour
    {
        [Header("Menus")]
        [SerializeField] private GameObject _levelsMenu;

        public void ShowLevelMenu() => _levelsMenu.SetActive(true);
    }
}
