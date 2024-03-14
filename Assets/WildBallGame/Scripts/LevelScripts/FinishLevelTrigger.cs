using UnityEngine;
using UnityEngine.SceneManagement;
namespace WildBallGame.Scripts.LevelScripts {
    public class FinishLevelTrigger : MonoBehaviour {
        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag(GlobalStringsVars.PlayerTag)) {
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
}