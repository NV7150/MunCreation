using MunCommunication;
using UnityEngine;
using UnityEngine.UI;

namespace Game.MenuProp {
    public class MenuInterface : MonoBehaviour {
        [SerializeField] private RoomSelector selector;
        
        [SerializeField] private Text inputText;
        [SerializeField] private Text passText;

        [SerializeField] private Text userNameText;
        

        public void create() {
            if (passText.text.Length > 0) {
                selector.createAuthorizedRoom(inputText.text, passText.text);
            } else {
                selector.createPublicRoom(inputText.text);
            }
        }

        public void join() {
            if (passText.text.Length > 0) {
                selector.joinAuthorizedRoom(inputText.text, passText.text);
            } else {
                selector.joinPublicRoom(inputText.text);
            }
        }
        
        public void connect() {
            selector.UserName = userNameText.text;
            selector.connectServer();
        }
    }
}
