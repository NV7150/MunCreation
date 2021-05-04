using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.Chat {
    public class ChatInput : MonoBehaviour {
        [SerializeField] private Text inputText;
        [SerializeField] private ChatDataSpace chatDataSpace;
        
        public void sendChat() {
            chatDataSpace.sendChat(inputText.text);
        }
    }
}
