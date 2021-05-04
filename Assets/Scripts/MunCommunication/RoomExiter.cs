using MonobitEngineBase;
using UnityEngine;

namespace MunCommunication {
    public class RoomExiter : MonoBehaviour {

        public void exitRoom() {
            MonobitNetwork.LeaveRoom();
        }
    }
}
