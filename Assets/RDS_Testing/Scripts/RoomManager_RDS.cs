using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoomManager_RDS : MonoBehaviourPunCallbacks
{
    public static RoomManager_RDS instance;
    
    public GameObject player;

    [Space]
    public Transform[] spawnPoints;

    [Space] 
    public GameObject roomCam;

    [Space] 
    public GameObject nameUI;
    public GameObject connectingUI;

    public string _nickname = "unnamed";

    private void Awake()
    {
        instance = this;
    }

    public void ChangeNickname(string _name)
    {
        _nickname = _name;
    }

    public void JoinRoomButtonPressed()
    {
        Debug.Log(message: "Connecting..");
        PhotonNetwork.ConnectUsingSettings();
        
        nameUI.SetActive(false);
        connectingUI.SetActive(true);
    }

    void Start()
    {
       
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("Connected to Server!");
        PhotonNetwork.JoinLobby();
    }
    

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("We are in a lobby");
        PhotonNetwork.JoinOrCreateRoom("test",null,null);
        
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("We are connected and in a room!");
        roomCam.SetActive(false);
        SpawnPlayer();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void SpawnPlayer()
    {
        Transform spawnPoint = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];
        
        GameObject _player = PhotonNetwork.Instantiate(player.name, spawnPoint.position, Quaternion.identity);
        _player.GetComponent<PlayerSetup_RDS>().IsLocalPlayer(); 
        _player.GetComponent<Health_RDS>().isLocalPlayer = true;
        
        _player.GetComponent<PhotonView>().RPC(methodName: "SetNickname", RpcTarget.AllBuffered, _nickname);

        PhotonNetwork.LocalPlayer.NickName = _nickname;
    }
}