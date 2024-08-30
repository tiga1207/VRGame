using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour
{
    private NetworkManager networkManager;  // NetworkManager를 참조할 변수
    public List<Button> roomButtons;  // 버튼들을 관리할 리스트

    void Start()
    {
        networkManager = FindObjectOfType<NetworkManager>();
        if (networkManager == null)
        {
            Debug.LogError("NetworkManager가 씬에서 발견되지 않았습니다.");
            return;
        }
        if(networkManager !=null)
        {
        for (int i = 0; i < roomButtons.Count; i++)
        {
            int index = i;  // 각 버튼이 고유의 인덱스를 유지하도록 설정
            roomButtons[i].onClick.AddListener(() => networkManager.InitiliazeRoom(index));
        }
        }
    }
}
