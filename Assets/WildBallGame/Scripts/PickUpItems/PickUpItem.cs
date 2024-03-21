using UnityEngine;
using Random = UnityEngine.Random;

namespace WildBallGame.Scripts.PickUpItems {
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(ParticleSystem))]
    public class PickUpItem : MonoBehaviour {
        [SerializeField] private bool rotate = true;
        [SerializeField] private float rotationSpeed = 30f;
        [SerializeField] private AudioClip[] collectSounds;
        [SerializeField] private ParticleSystem particleSystem;
        [SerializeField] private GameObject model;

        private void Start() {
            particleSystem = GetComponent<ParticleSystem>();
        }

        private void Update() {
            if (rotate) {
                model.transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime), Space.World);
            }
        }

        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag(GlobalStringsVars.PlayerTag)) {
                Collect();
            }
        }

        private void Collect() {
            if (collectSounds != null && collectSounds.Length > 0) {
                int indexSfx = Random.Range(0, collectSounds.Length);
                AudioSource.PlayClipAtPoint(collectSounds[indexSfx], transform.position);
            }
            if (particleSystem) {
                particleSystem.Play();
            }
            model.SetActive(false);
        }
    }
}