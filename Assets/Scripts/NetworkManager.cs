using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

[System.Serializable ]
public class DefaultRoom
{
    public string Name; // 방이름
    public int sceneIndex; // 방 인덱스
    public int maxPlayer; // 최대 플레이어

}
public class NetworkManager : MonoBehaviourPunCallbacks
{
    public List<DefaultRoom> defaultRooms;

    public GameObject roomUI;
    public void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("try connect to server");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Server.");
        base.OnConnectedToMaster();
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("We joined the lobby");
        roomUI.SetActive(true);
    } 

    public void InitiliazeRoom(int defaultRoomInnex) //방(네트워크) 설정
    {
        DefaultRoom roomSettings = defaultRooms[defaultRoomInnex];

        //방 로드
        PhotonNetwork.LoadLevel(roomSettings.sceneIndex);

        //방생성
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = (byte)roomSettings.maxPlayer;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;

        PhotonNetwork.JoinOrCreateRoom(roomSettings.Name, roomOptions,TypedLobby.Default);

    }

    public override void OnJoinedRoom()
    {
        Debug.Log("joined a Room");
        base.OnJoinedRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)//플레이어 입장시
    {
        Debug.Log("A new player entered room");
        base.OnPlayerEnteredRoom(newPlayer);
    }
}
