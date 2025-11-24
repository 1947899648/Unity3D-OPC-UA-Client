using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

using Opc.Ua;
using Opc.Ua.Client;
using OpcUaHelper;
using System;

public class MyOpcClient : MonoBehaviour
{
    public bool IsWork;
    public TMP_InputField OpcAdressInput;
    public TMP_InputField nodeId_read_Input;
    public TMP_InputField nodeId_sub_Input;
    public TMP_Text clientStateShow;
    public TMP_Text nodeStateShow;
    public TMP_Text changeTimeShow;
    public TMP_Text readResult;
    public TMP_Text writeResult;
    public string opcAddress = "opc.tcp://127.0.0.1:49320";
    public OpcUaClient client;
    private void Awake()
    {
        client = new OpcUaClient();       
    }
    public void ConnectOPCUAServer()
    {
        try
        {
            client.ConnectServer(OpcAdressInput.text);
            if (client.Connected)
            {
                clientStateShow.text = "connent ! ! !";    
            }
            else
            {
                clientStateShow.text = "failure";
            }
        }
        catch
        {
            clientStateShow.text = "error !";
        }      
    }
    public void DisConnectOPCUAServer()
    {
        if (client.Connected)
        {
            client.Disconnect();
            clientStateShow.text = "DisConnent ! ! !";
        }
        else
        {
            clientStateShow.text = "DisConnent already";
        }
    }
    public void ReadNodeInofrmation()
    {
        string nodeId = nodeId_read_Input.text;
        try
        {
            bool res = client.ReadNode<bool>(nodeId);
            readResult.text = res.ToString();
        }
        catch
        {
            readResult.text = "nodeId ?";
        }
    }
    public void WriteBoolValue(bool value)
    {
        string nodeId = nodeId_read_Input.text;
        try
        {
            client.WriteNode<bool>(nodeId, value);
            readResult.text = "";
            writeResult.text = "write " + value.ToString() + " ok";
        }
        catch
        {
            readResult.text = "nodeId ?";
        }
    }
    public void SubscribeNode()
    {
        string nodeId = nodeId_sub_Input.text;
        client.AddSubscription("A", nodeId, SubCallback);
        //client.AddSubscription("C", nodeId, SubCallback);
        nodeStateShow.text = "sub ok";
    }
    public void RemoveSubscribeNode()
    {
        string nodeId = nodeId_sub_Input.text;
        try
        {
            client.RemoveSubscription("A");
            nodeStateShow.text = "remove sub ok";
            changeTimeShow.text = "stop";
        }
        catch
        {
            nodeStateShow.text = "nodeId ?";
        }
    }
    private void Update()
    {
        IsWork = Convert.ToBoolean(res);
        if (isUpdateText)
        {
            nodeStateShow.text = res;
            changeTimeShow.text = changeDate;
            isUpdateText = false;
        }
    }
    bool isUpdateText = false;
    string res;
    string changeDate;
    private void SubCallback(string key, MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs args)
    {
        if (key == "A")// 如果有多个的订阅值都关联了当前的方法，可以通过key和monitoredItem来区分
        { 
            MonitoredItemNotification notification = args.NotificationValue as MonitoredItemNotification;
            if (notification != null)
            {
                res = notification.Value.WrappedValue.Value.ToString();
                changeDate = DateTime.Now.ToString("G");
                isUpdateText = true;//text.enabled = false;//text.enabled = true;
            }
        }

        if (key == "C")
        {

        }
    }
}
