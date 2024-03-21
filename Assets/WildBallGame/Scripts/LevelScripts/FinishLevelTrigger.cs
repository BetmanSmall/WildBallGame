using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using WildBallGame.Scripts.Ui;
namespace WildBallGame.Scripts.LevelScripts {
    public class FinishLevelTrigger : MonoBehaviour {
        [SerializeField] private bool itIsLastLevel;
        [SerializeField] private ParticleSystem particleSystem;
        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag(GlobalStringsVars.PlayerTag)) {
                if (itIsLastLevel) {
                    particleSystem.Play();
                    GameOverCanvas.Instance.OpenWinPanel();
                    StartCoroutine(WaitAndChangeLevel());
                } else {
                    ChangeLevel();
                }
            }
        }

        private IEnumerator WaitAndChangeLevel() {
            yield return new WaitForSecondsRealtime(2f);
            SceneManager.LoadScene(0);
        }

        private void ChangeLevel() {
            int sceneCountInBuildSettings = SceneManager.sceneCountInBuildSettings;
            Scene activeScene = SceneManager.GetActiveScene();
            int nextBuildIndexScene = activeScene.buildIndex + 1;
            if (nextBuildIndexScene >= sceneCountInBuildSettings) {
                nextBuildIndexScene = 0;
            }
            SceneManager.LoadScene(nextBuildIndexScene);
        }
    }
}