using UnityEngine;
namespace WildBallGame.Scripts.PlayerInput {
    public class PlayerDeath : MonoBehaviour {
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private GameObject modelSphere;
        [SerializeField] private ParticleSystem particleSystem;
        public static PlayerDeath Instance;

        private void Start() {
            Instance = this;
            rigidbody = GetComponent<Rigidbody>();
        }

        public void PlayerDeathInvoke() {
            rigidbody.isKinematic = true;
            modelSphere.SetActive(false);
            particleSystem.Play();
        }
    }
}