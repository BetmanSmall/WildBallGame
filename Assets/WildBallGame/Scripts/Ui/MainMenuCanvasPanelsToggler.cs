using UnityEngine;
using UnityEngine.UI;

namespace WildBallGame.Scripts.Ui {
    public class MainMenuCanvasPanelsToggler : MonoBehaviour {
        [SerializeField] private Button returnButton;
        [SerializeField] private GameObject selectLevelPanel;

        private void Start() {
            returnButton.onClick.AddListener(() => {
                selectLevelPanel.SetActive(false);
                gameObject.SetActive(true);
            });
        }
    }
}