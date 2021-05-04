using System;
using UnityEngine;

namespace Game.Character {
    public class PlayerMover : MonoBehaviour {

        [SerializeField] private string verticalButton = "Vertical";
        [SerializeField] private string horizontalButton = "Horizontal";

        [SerializeField] private string verticalAnimParam = "Speed";
        [SerializeField] private string horizontalAnimParam = "Direction";

        [SerializeField] private float speed = 1.5f;
        [SerializeField] private float rotSpeed = 1.5f;
        
        private Rigidbody _rig;
        private Animator _animator;


        private void Awake() {
            _rig = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
        }

        
        // Update is called once per frame
        void FixedUpdate() {
            processMove();
        }
        private void Update() {
            processAnime();
        }
        
        Vector2 getInput() {
            return new Vector2(Input.GetAxis(verticalButton), Input.GetAxis(horizontalButton));
        }
        
        void processMove() {
            var axis = getInput();
            verticalMove(axis.x);
            horizontalMove(axis.y);
        }

        void verticalMove(float axis) {
            _rig.AddForce(transform.forward * (speed * axis));
        }
        void horizontalMove(float axis) {
            transform.Rotate(Vector3.up * (rotSpeed * axis));
        }
        
        void processAnime() {
            var axis = getInput();
            
            _animator.SetFloat(verticalAnimParam, axis.x);
            _animator.SetFloat(horizontalAnimParam, axis.y);
        }
    }
}
