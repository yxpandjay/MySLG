using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleFieldManager : Photon.PunBehaviour {

    public GameObject testPeople;
    private bool CanStartInstance = false;
    

    private void OnLevelWasLoaded(int level)
    {
        Debug.Log("OnLevelWasLoaded 已进入。3秒后准备尝试实例化");
        CanStartInstance = true;
    }

    private void Update()
    {   

        if( CanStartInstance &&Time.timeSinceLevelLoad > 3)
        {
            CanStartInstance = !CanStartInstance;
            InstanceCube();
        }

    }

    private void InstanceCube()
    {
        Debug.Log("初始化Test Cube");
        Vector3 startPos = new Vector3( Random.Range(0,3) , Random.Range(0, 3),Random.Range(0, 3)) + testPeople.transform.position;
        PhotonNetwork.Instantiate(testPeople.name, startPos, Quaternion.identity, 0);
    }

}
