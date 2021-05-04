using System;
using MunCommunication;
using UnityEngine;

namespace Game.MenuProp {
    public class MenuControl : MonoBehaviour {
        private MunConnectState _lastState;

        [SerializeField] private GameObject connectionForm;
        [SerializeField] private GameObject roomForm;

        private void Start() {
            updateControl(MunConnectState.NONE);
        }

        // Update is called once per frame
        void Update() {
            checkState();
        }

        void checkState() {
            var currState = MunComHelper.getState();
            if (currState == _lastState)
                return;
            
            updateControl(currState);
            _lastState = currState;
        }

        void updateControl(MunConnectState state) {
            connectionForm.SetActive(false);
            roomForm.SetActive(false);
            switch (state) {
                case MunConnectState.NONE: 
                    connectionForm.SetActive(true);
                    break;
                case MunConnectState.IN_LOBBY:
                    roomForm.SetActive(true);
                    break;
                
                case MunConnectState.IN_ROOM: goto case default;
                case MunConnectState.CONNECTED: goto case default;
                default: break;
            }
            
        }
    }
}
