using UnityEngine;
namespace WildBallGame.Scripts.LevelScripts {
    public class EnableTriggerObject : MonoBehaviour {
        [SerializeField] private GameObject gameObjectToActive;

        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player")) {
                gameObjectToActive.SetActive(true);
            }
        }
    }
}