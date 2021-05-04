using System;
using Game.Systems;
using MonobitEngineBase;
using UnityEngine;

namespace Game.Character {
    public class CharacterSpawner : MonoBehaviour {
        [SerializeField] private GameObject character;
        [SerializeField] private PlayerCamera playerCamera;

        private void Start() {
            createAndSetCamera();
        }

        void createAndSetCamera() {
            var player = MonobitNetwork.Instantiate(
                character.name
                , Vector3.zero
                , Quaternion.identity
                , 0
            );
            playerCamera.Player = player;
        }
    }
}
