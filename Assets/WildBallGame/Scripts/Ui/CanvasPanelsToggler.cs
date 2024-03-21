using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace WildBallGame.Scripts.Ui {
    public class CanvasPanelsToggler : MonoBehaviour {
        [SerializeField] private Button pauseButton;
        [SerializeField] private Button returnButton;
        [SerializeField] private GameObject selectLevelPanel;

        private void Start() {
            Scene activeScene = SceneManager.GetActiveScene();
            if (activeScene.buildIndex != 0) {
                selectLevelPanel.SetActive(false);
                returnButton.gameObject.SetActive(false);
                pauseButton.onClick.AddListener(() => {
                    selectLevelPanel.SetActive(!selectLevelPanel.activeSelf);
                });
            } else {
                pauseButton.gameObject.SetActive(false);
            }
            if (FindObjectOfType<EventSystem>() == null) {
                new GameObject("RunTimeGenerateEventSystem").AddComponent<EventSystem>().AddComponent<StandaloneInputModule>();
            }
        }
    }
}