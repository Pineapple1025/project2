using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;
using UnityEditor.SceneTemplate;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class MaSta : MonoBehaviour
{
    int[,] machineStatus = new int[4, 10];
    float requestInterval = 10.0f; 
    float lastRequestTime = 0.0f; 
    public class TeamData
    {
        public string GroupID;
        public Dictionary<string, bool> status;
    }

    [System.Serializable]
    public class StatusData
    {
        public TeamData test1;
        public TeamData test2;
        public TeamData test3;
        public TeamData test4;
    }
    void Start()
    {
        
    }


    void Update()
    {
        // 間隔10秒發送請求
        if (Time.time - lastRequestTime >= requestInterval)
        {
            // call 發送請求的 func
            SendReq();

            // 更新現在時間
            lastRequestTime = Time.time;
        }
    }
    void SendReq()
    {
        WebClient client1 = new WebClient();
        client1.DownloadDataCompleted += new DownloadDataCompletedEventHandler(HistoryData);
        client1.DownloadDataAsync(new Uri("http://127.0.0.1:5000/status"));
    }
    void HistoryData(object sender, DownloadDataCompletedEventArgs e)
    {
        if (e.Error == null)
        {
            print("連線成功");
            
            byte[] data = e.Result;
            string content = Encoding.UTF8.GetString(data);

            UpdateMachineStatus(content);
        }
        else
        {
            print("Error: " + e.Error.Message);
        }
    }
    
    void UpdateMachineStatus(string content)  
    {
        Debug.Log("UpdateMachineStatus called");
        StatusData statusData = JsonUtility.FromJson<StatusData>(content);
        Debug.Log(statusData);
        if (statusData != null && statusData.test1 != null && statusData.test1.status != null)
        {

            machineStatus[0, 0] = statusData.test1.status["M1"] ? 1 : 0;
            machineStatus[0, 1] = statusData.test1.status["M2"] ? 1 : 0;
            machineStatus[0, 2] = statusData.test1.status["M3"] ? 1 : 0;
            machineStatus[0, 3] = statusData.test1.status["M4"] ? 1 : 0;
            machineStatus[0, 4] = statusData.test1.status["M5"] ? 1 : 0;
            machineStatus[0, 5] = statusData.test1.status["M6"] ? 1 : 0;
            machineStatus[0, 6] = statusData.test1.status["M7"] ? 1 : 0;
            machineStatus[0, 7] = statusData.test1.status["M8"] ? 1 : 0;
            machineStatus[0, 8] = statusData.test1.status["M9"] ? 1 : 0;
            machineStatus[0, 9] = statusData.test1.status["M10"] ? 1 : 0;

            machineStatus[1, 0] = statusData.test2.status["M1"] ? 1 : 0;
            machineStatus[1, 1] = statusData.test2.status["M2"] ? 1 : 0;
            machineStatus[1, 2] = statusData.test2.status["M3"] ? 1 : 0;
            machineStatus[1, 3] = statusData.test2.status["M4"] ? 1 : 0;
            machineStatus[1, 4] = statusData.test2.status["M5"] ? 1 : 0;
            machineStatus[1, 5] = statusData.test2.status["M6"] ? 1 : 0;
            machineStatus[1, 6] = statusData.test2.status["M7"] ? 1 : 0;
            machineStatus[1, 7] = statusData.test2.status["M8"] ? 1 : 0;
            machineStatus[1, 8] = statusData.test2.status["M9"] ? 1 : 0;
            machineStatus[1, 9] = statusData.test2.status["M10"] ? 1 : 0;

            machineStatus[2, 0] = statusData.test3.status["M1"] ? 1 : 0;
            machineStatus[2, 1] = statusData.test3.status["M2"] ? 1 : 0;
            machineStatus[2, 2] = statusData.test3.status["M3"] ? 1 : 0;
            machineStatus[2, 3] = statusData.test3.status["M4"] ? 1 : 0;
            machineStatus[2, 4] = statusData.test3.status["M5"] ? 1 : 0;
            machineStatus[2, 5] = statusData.test3.status["M6"] ? 1 : 0;
            machineStatus[2, 6] = statusData.test3.status["M7"] ? 1 : 0;
            machineStatus[2, 7] = statusData.test3.status["M8"] ? 1 : 0;
            machineStatus[2, 8] = statusData.test3.status["M9"] ? 1 : 0;
            machineStatus[2, 9] = statusData.test3.status["M10"] ? 1 : 0;

            machineStatus[3, 0] = statusData.test4.status["M1"] ? 1 : 0;
            machineStatus[3, 1] = statusData.test4.status["M2"] ? 1 : 0;
            machineStatus[3, 2] = statusData.test4.status["M3"] ? 1 : 0;
            machineStatus[3, 3] = statusData.test4.status["M4"] ? 1 : 0;
            machineStatus[3, 4] = statusData.test4.status["M5"] ? 1 : 0;
            machineStatus[3, 5] = statusData.test4.status["M6"] ? 1 : 0;
            machineStatus[3, 6] = statusData.test4.status["M7"] ? 1 : 0;
            machineStatus[3, 7] = statusData.test4.status["M8"] ? 1 : 0;
            machineStatus[3, 8] = statusData.test4.status["M9"] ? 1 : 0;
            machineStatus[3, 9] = statusData.test4.status["M10"] ? 1 : 0;
        }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Debug.Log("Machine " + i + " Status " + machineStatus[i, j]);
                }
            }

        }
    }
        
         


