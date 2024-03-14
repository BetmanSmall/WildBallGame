using UnityEngine;
using WildBallGame.Scripts.PlayerInput;
using WildBallGame.Scripts.Ui;
namespace WildBallGame.Scripts.LevelScripts {
    public class TrapPlayerDeathTrigger : MonoBehaviour {
        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag(GlobalStringsVars.PlayerTag)) {
                PlayerDeath.Instance.PlayerDeathInvoke();
                GameOverCanvas.Instance.OpenLosePanel();
            }
        }
    }
}