using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using UnityEngine.SceneManagement;
public class MainGamePanelManager : MonoBehaviour
{

    public Button wardrobeBtn;
    public Button singleBtn;
    public Button multiBtn;
    public Button logoutBtn;
    public Button routineBtn;
    public GameObject mainGamePanel;
    public GameObject lockerRoomPanel;
    public GameObject loginPanel;
    public GameObject indivisualRoutinePanel;
    // public GameObject XrOrign;
    // public GameObject oneCamera;
    public NetworkManager networkManager;

    void Start()
    {
        if(wardrobeBtn!=null)
        {
            wardrobeBtn.onClick.AddListener(GotoWardorbePanel);
        }
        if(singleBtn!=null)
        {
            singleBtn.onClick.AddListener(SinglePlay);
        }
        if(multiBtn!=null)
        {
            multiBtn.onClick.AddListener(MultiPlay);
        }
        if(logoutBtn!=null)
        {
            logoutBtn.onClick.AddListener(Logout);
        }
        if(routineBtn!=null)
        {
            routineBtn.onClick.AddListener(CheckmyRoutine);
        }
    }

    public void Logout()
    {
        mainGamePanel.SetActive(false);
        loginPanel.SetActive(true);
    }
    public void GotoWardorbePanel()
    {
        lockerRoomPanel.SetActive(false);
        lockerRoomPanel.SetActive(true);
    }

    public void SinglePlay()
    {
        mainGamePanel.SetActive(false);
        // oneCamera.SetActive(false);
        // XrOrign.SetActive(true);
        
    }
    public void MultiPlay()
    {
        mainGamePanel.SetActive(false);
        //networkManager.InitiliazeRoom(0);
        SceneManager.LoadScene("Lobby");
        // oneCamera.SetActive(false);        
        // PhotonNetwork.LoadLevel(0);
        // XrOrign.SetActive(true);

    }
    public void CheckmyRoutine()
    {
        indivisualRoutinePanel.SetActive(true);
    }

}
