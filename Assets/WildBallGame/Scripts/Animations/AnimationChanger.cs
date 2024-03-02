using UnityEngine;
using Random = UnityEngine.Random;
namespace WildBallGame.Scripts.Animations {
    public class AnimationChanger : MonoBehaviour {
        [SerializeField] private Animator animator;
        [SerializeField] private string animatorString = "ChangeAnimation";
        [SerializeField] private int animatorAnimsClipsSize = 7;

        private void Start() {
            animator = GetComponentInChildren<Animator>();
        }

        public void ChangeCubeAnimation() {
            int index = Random.Range(0, animatorAnimsClipsSize);
            animator.SetInteger(animatorString, index);
        }
    }
}