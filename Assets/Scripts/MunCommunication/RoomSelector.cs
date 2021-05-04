using System.Collections;
using System.Collections.Generic;
using MonobitEngine;
using UnityEngine;
using UnityEngine.Events;

using MonobitNetwork = MonobitEngine.MonobitNetwork;

namespace MunCommunication {
    public class RoomSelector : MunMonoBehaviour {
        [SerializeField] private UnityEvent<List<RoomData>> onEnterLobby;
        [SerializeField] private UnityEvent onEnterRoom;

        [SerializeField] private string serverName;
        [SerializeField] private string defaultUserName;

        private EncryptTool _encryptTool;
        public EncryptTool EncryptTool{
            set => _encryptTool = value;
        }

        public string UserName {
            get => MonobitNetwork.playerName;
            set => 
                MonobitNetwork.playerName = 
                    value.Length > 0 ? value : defaultUserName;
        }

        private void Awake() {
            MonobitNetwork.playerName = defaultUserName;
        }

        //This callback is called when the lobby info is received.
        public override void OnLobbyDataUpdate() {
            onEnterLobby.Invoke(new List<RoomData>(MonobitNetwork.GetRoomData()));
        }
        
        public override void OnJoinedRoom() { 
            onEnterRoom.Invoke();
        }

        public void connectServer() {
            MonobitEngine.MonobitNetwork.autoJoinLobby = true;

            MonobitNetwork.ConnectServer(serverName);
        }

        public void createPublicRoom(string roomName) {
            if (!MonobitNetwork.inLobby)
                return;
            
            MonobitNetwork.CreateRoom(roomName);
        }
        
        public void joinPublicRoom(string roomName) {
            if (!MonobitNetwork.inLobby)
                return;
            
            MonobitNetwork.JoinRoom(roomName);
        }
        
        Hashtable generateAuthTable(string roomName, string password) {
            var customParam = new Hashtable();

            var hashedStr = _encryptTool.encryptString(password);

            customParam["name"] = roomName;
            customParam["password"] = hashedStr;


            return customParam;
        }
        
        public void createAuthorizedRoom(string roomName, string password) {
            var setting = generateAuthTable(roomName, password);

            var roomSetting = new RoomSettings {
                roomParameters = setting
                , isVisible = false
            };

            //generate encrypted room name to protect from unexpected access with JoinRoom()
            var hashedStr = _encryptTool.encryptString(roomName + password);

            MonobitNetwork.CreateRoom(hashedStr, roomSetting, LobbyInfo.Default);
        }

        public void joinAuthorizedRoom(string roomName, string password) {
            var setting = generateAuthTable(roomName, password);

            MonobitNetwork.JoinRandomRoom(setting, 0);
        }
    }
}
