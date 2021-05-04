using MunCommunication;
using UnityEngine;

namespace Game.MenuProp {
    public class MenuSettings : MonoBehaviour {
        [SerializeField] private RoomSelector selector;
        
        // Start is called before the first frame update
        void Start() {
            selector.EncryptTool = new SimpleEncryptor();
        }
    }
}
