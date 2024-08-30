using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;  
public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    private GameObject spawnedPlayerPrefab;
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        MakePlayerSpawn();
    }

    // public override void OnJoinedLobby()
    // {
    //     base.OnJoinedLobby();
    //     MakePlayerSpawn();

    // }
    // public override void OnLeftLobby()
    // {
    //     base.OnLeftLobby();
    //     PhotonNetwork.Destroy(spawnedPlayerPrefab);
    // }

    public void MakePlayerSpawn()
    {
        spawnedPlayerPrefab=PhotonNetwork.Instantiate("Network Player",transform.position,transform.rotation);

    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }
}
