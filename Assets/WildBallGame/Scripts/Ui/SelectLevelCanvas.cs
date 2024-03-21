using System.Collections.Generic;
using Eflatun.SceneReference;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace WildBallGame.Scripts.Ui {
    public class SelectLevelCanvas : MonoBehaviour {
        [SerializeField] private GameObject scrollViewContent;
        [SerializeField] private GameObject buttonPrefab;
        [SerializeField] private List<SceneReference> sceneReferences;

        private void Start() {
            foreach (SceneReference sceneReference in sceneReferences) {
                Scene loadedScene = sceneReference.LoadedScene;
                if (loadedScene.isLoaded) {
                    continue;
                }
                if (sceneReference.State.Equals(SceneReferenceState.Regular)) {
                    GameObject buttonInScrollView = Instantiate(buttonPrefab, scrollViewContent.transform);
                    TMP_Text tmpText = buttonInScrollView.GetComponentInChildren<TMP_Text>();
                    if (tmpText != null) {
                        tmpText.text = sceneReference.Name;
                    }
                    Button button = buttonInScrollView.GetComponent<Button>();
                    button.onClick.AddListener(() => {
                        SceneManager.LoadScene(sceneReference.BuildIndex);
                    });
                }
            }
        }
    }
}