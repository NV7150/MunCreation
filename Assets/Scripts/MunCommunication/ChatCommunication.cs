using System;
using Game.Chat;
using MonobitEngine;
using UnityEngine;
using UnityEngine.Events;
using MonobitNetwork = MonobitEngineBase.MonobitNetwork;

namespace MunCommunication {
    public class ChatCommunication : MonobitEngine.MonoBehaviour {
        [SerializeField] private MonobitView view;
        [SerializeField] private UnityEvent<string> onReceiveChat;

        [MunRPC]
        public void receiveChat(string sender, string chat) {
            onReceiveChat.Invoke(sender + ":" + chat);
        }
        
        public void sendChat(string chat) {
            view.RPC(
                nameof(receiveChat)
                , MonobitTargets.All
                , MonobitNetwork.playerName
                , chat
                );
            
        }
    }
}
