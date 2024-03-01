using System;
using Newtonsoft.Json;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CanvasPanelsToggler : MonoBehaviour {
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button returnButton;
    [SerializeField] private GameObject selectLevelPanel;

    private void Start() {
        Scene activeScene = SceneManager.GetActiveScene();
        Debug.Log("CanvasPanelsToggler::Start(); -json- activeScene:" + JsonConvert.SerializeObject(activeScene));
        if (activeScene.buildIndex != 0) {
            selectLevelPanel.SetActive(false);
            returnButton.gameObject.SetActive(false);
            Debug.Log("CanvasPanelsToggler::Start(); -- pauseButton:" + pauseButton);
            pauseButton.onClick.AddListener(() => {
                Debug.Log("CanvasPanelsToggler::Start(); -onClick- selectLevelPanel.activeSelf:" + selectLevelPanel.activeSelf);
                selectLevelPanel.SetActive(!selectLevelPanel.activeSelf);
            });
        } else {
            pauseButton.gameObject.SetActive(false);
        }
        if (FindObjectOfType<EventSystem>() == null) {
            new GameObject("RunTimeGenerateEventSystem").AddComponent<EventSystem>().AddComponent<StandaloneInputModule>();
        }
    }

    public void OnClickTest(Button button) {
        Debug.Log("CanvasPanelsToggler::OnClickTest(); -- button:" + button);
    }
}