using UnityEngine;
using UnityEngine.SceneManagement;

namespace WildBallGame.Scripts.Ui {
    public class GameOverCanvas : MonoBehaviour {
        [SerializeField] private GameObject mainGameOverPanel;
        [SerializeField] private GameObject losePanel;
        [SerializeField] private GameObject winPanel;
        public static GameOverCanvas Instance;

        private void Start() {
            Instance = this;
            mainGameOverPanel.SetActive(false);
        }

        public void OpenLosePanel() {
            mainGameOverPanel.SetActive(true);
            losePanel.SetActive(true);
            winPanel.SetActive(false);
        }

        public void OpenWinPanel() {
            mainGameOverPanel.SetActive(true);
            winPanel.SetActive(true);
            losePanel.SetActive(false);
        }

        public void OnRestartBtn() {
            SceneManager.LoadScene(0);
        }
    }
}