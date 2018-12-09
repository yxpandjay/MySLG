using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginManager : Photon.PunBehaviour{

    public string _gameVersion = "0.1";
    public GameObject WatingText;

	void Start () {
        WatingText.SetActive(false);
        Debug.Log("开始LOGIN");
        PhotonNetwork.ConnectUsingSettings(_gameVersion);
        PhotonNetwork.automaticallySyncScene = true;
      
	}

    public void JoinRoom()
    {
        Debug.Log("尝试加入房间");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
    {
        Debug.Log("加入房间失败  尝试创建房间");
        PhotonNetwork.CreateRoom(null);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("创建房间成功");
        WatingText.SetActive(true);
        //JoinRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("加入房间成功");
        int curPlayerNum = PhotonNetwork.countOfPlayers;
        Debug.Log("当前玩家数:" + curPlayerNum);
    }

    public override void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
    {
        //base.OnPhotonPlayerConnected(newPlayer);
        int curPlayerNum = PhotonNetwork.countOfPlayers;
        Debug.Log("当前玩家数:" + curPlayerNum);
        if( curPlayerNum >= 1)
        {
            if (PhotonNetwork.isMasterClient)
            {
                PhotonNetwork.LoadLevel("BattleField");
            }
        }


    }

}
