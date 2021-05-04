using UnityEngine;

namespace Game.Systems {
    public class PlayerCamera : MonoBehaviour {
        [SerializeField] private Vector3 distFromPlayer = new Vector3(0, 3, 5);
        private GameObject _player;

        public GameObject Player {
            get => _player;
            set {
                _player = value;
                var selfTrans = transform;
                var position = _player.transform.position;
                
                selfTrans.parent = _player.transform;
                selfTrans.position = position + distFromPlayer;
                selfTrans.LookAt(position);
            }
        }
    }
}
