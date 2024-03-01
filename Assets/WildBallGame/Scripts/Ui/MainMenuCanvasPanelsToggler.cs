using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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