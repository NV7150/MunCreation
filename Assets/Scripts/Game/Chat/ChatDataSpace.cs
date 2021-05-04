using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Chat {
    public class ChatDataSpace : MonoBehaviour {

        [SerializeField] private UnityEvent<string> onChatSent;
        [SerializeField] private ChatWindow window;

        private readonly List<string> _chats = new List<string>();

        public void receiveChat(string chat) {
            _chats.Add(chat);
            window.updateChatWindow(new List<string>(_chats));
        }

        public void sendChat(string chat) {
            onChatSent.Invoke(chat);
        }
        
    }
}
