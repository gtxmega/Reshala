using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Logics.UIMenu
{
    public class LevelItemUI : MonoBehaviour
    {
        [SerializeField] private Image _levelSprite;
        [SerializeField] private TMP_Text _lockText;
        [SerializeField] private GameObject _lockGameObject;

        private int _levelID;
        private LevelMenuUI _levelMenu;

        public void SetLevelMenuUI(LevelMenuUI levelMenu)
            => _levelMenu = levelMenu;

        public void SetLevelID(int levelID)
            => _levelID = levelID;

        public void Lock()
            => _lockGameObject.SetActive(true);

        public void Unlock()
            => _lockGameObject.SetActive(false);

        public void SetLevelSprite(Sprite display)
            => _levelSprite.sprite = display;

        public void OnClick()
        {
            _levelMenu.OnSelectLevel(_levelID);
        }
    }
}