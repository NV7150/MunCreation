using MonobitNetwork = MonobitEngineBase.MonobitNetwork;

namespace MunCommunication {
    public enum MunConnectState {
        NONE,
        CONNECTED,
        IN_LOBBY,
        IN_ROOM
    }
    
    public static class MunComHelper {
        public static MunConnectState getState() {
            if (!MonobitNetwork.isConnect)
                return MunConnectState.NONE;
            
            if (!MonobitNetwork.inLobby)
                return MunConnectState.CONNECTED;
            
            if (!MonobitNetwork.inRoom)
                return MunConnectState.IN_LOBBY;
            
            return MunConnectState.IN_ROOM;
        }
    }
}
