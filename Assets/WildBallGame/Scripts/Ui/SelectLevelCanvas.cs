using System.Collections.Generic;
using Eflatun.SceneReference;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SelectLevelCanvas : MonoBehaviour {
    [SerializeField] private GameObject scrollViewContent;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private List<SceneReference> sceneReferences;

    private void Start() {
        Scene activeScene = SceneManager.GetActiveScene();
        Debug.Log("SelectLevelCanvas::Start(); -json- activeScene:" + JsonConvert.SerializeObject(activeScene));
        foreach (SceneReference sceneReference in sceneReferences) {
            Scene loadedScene = sceneReference.LoadedScene;
            Debug.Log("SelectLevelCanvas::Start(); -json- loadedScene:" + JsonConvert.SerializeObject(loadedScene));
            if (loadedScene.isLoaded) {
                continue;
            }
            Debug.Log("SelectLevelCanvas::Start(); -- sceneReference.Name:" + sceneReference.Name);
            Debug.Log("SelectLevelCanvas::Start(); -- sceneReference.Path:" + sceneReference.Path);
            Debug.Log("SelectLevelCanvas::Start(); -- sceneReference.BuildIndex:" + sceneReference.BuildIndex);
            Debug.Log("SelectLevelCanvas::Start(); -- sceneReference.State:" + sceneReference.State);
            Debug.Log("SelectLevelCanvas::Start(); -- sceneReference.UnsafeReason:" + sceneReference.UnsafeReason);
            if (sceneReference.State.Equals(SceneReferenceState.Regular)) {
                GameObject buttonInScrollView = Instantiate(buttonPrefab, scrollViewContent.transform);
                TMP_Text tmpText = buttonInScrollView.GetComponentInChildren<TMP_Text>();
                if (tmpText != null) {
                    tmpText.text = sceneReference.Name;
                }
                Button button = buttonInScrollView.GetComponent<Button>();
                button.onClick.AddListener(() => {
                    Debug.Log("SelectLevelCanvas::Start(); -- sceneReference:" + sceneReference);
                    Debug.Log("SelectLevelCanvas::Start(); -- sceneReference.Name:" + sceneReference.Name);
                    SceneManager.LoadScene(sceneReference.BuildIndex);
                });
            }
        }
    }
}