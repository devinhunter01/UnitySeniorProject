using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;

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


    [HideInInspector]
    public int kills = 0;
    [HideInInspector]
    public int deaths = 0;

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

    public void JoinButton() //This exists for now as a workaround to coming to this scene through the menu to avoid trying to connect to 2 servers. I'll try cleaning this up later to instantiate everything properly.
    {
        nameUI.SetActive(false);
        roomCam.SetActive(false);
        SpawnPlayer();
    }
    
    public void SetHashes()
    {
        try
        {
            Hashtable hash = PhotonNetwork.LocalPlayer.CustomProperties;

            hash["kills"] = kills;
            hash["deaths"] = deaths;

            PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
        }
        catch 
        {
            // do nothing
        }
    }
}