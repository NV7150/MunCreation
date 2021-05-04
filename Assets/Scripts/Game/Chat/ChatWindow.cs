using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Chat {
    public class ChatWindow : MonoBehaviour {
        [SerializeField] private Text textWindow;

        public void updateChatWindow(List<string> chats) {
            string allChat = chats.Aggregate("", 
                (current, chat) => current + (chat + "\n"));

            textWindow.text = allChat;
        }
    }
}
