using UnityEngine;
using System;
using TMPro;
using Opc.Ua;
using Opc.Ua.Client;
using OpcUaHelper;

/// <summary>
/// 需引入OpcUaHelper库，详情可参考以下Github链接
/// https://github.com/dathlin/OpcUaHelper.git
/// 本脚本仅用于展示Opc Ua通信的关键方法：服务器的连接/中断、节点值的读取/写入、节点内容变化事件的订阅与解除等
/// </summary>
public class MyOpcClient : MonoBehaviour
{
    #region 字段
    /// <summary>
    /// OPC UA 客户端是否运行
    /// </summary>
    public bool IsWork;

    /// <summary>
    /// OPC UA 服务器地址 输入框
    /// </summary>
    public TMP_InputField OpcAdressInput;

    /// <summary>
    /// 需要读取节点地址 输入框
    /// </summary>
    public TMP_InputField nodeId_read_Input;

    /// <summary>
    /// 需要订阅节点地址 输入框
    /// </summary>
    public TMP_InputField nodeId_sub_Input;

    /// <summary>
    /// 客户端状态信息显示
    /// </summary>
    public TMP_Text clientStateShow;

    /// <summary>
    /// 节点状态信息显示
    /// </summary>
    public TMP_Text nodeStateShow;

    /// <summary>
    /// 节点内容变化时间内容显示
    /// </summary>
    public TMP_Text changeTimeShow;

    /// <summary>
    /// 节点读取结果输出显示
    /// </summary>
    public TMP_Text readResult;

    /// <summary>
    /// 节点值写入结果输出显示
    /// </summary>
    public TMP_Text writeResult;

    /// <summary>
    /// 默认的OPC UA 服务器 地址 信息（读者可自行调整）
    /// </summary>
    public string opcAddress = "opc.tcp://127.0.0.1:49320";

    /// <summary>
    /// 基于OpcUaHelper的OPC UA客户端对象
    /// </summary>
    public OpcUaClient client;

    private bool isUpdateText = false;
    private string res;
    private string changeDate;
    #endregion

    #region Mono
    private void Awake()
    {
        client = new OpcUaClient();
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
    #endregion

    #region 核心方法-连接-中断-主动读-主动写
    /// <summary>
    /// 连接OPC UA服务器
    /// </summary>
    public void ConnectOPCUAServer()
    {
        try
        {
            client.ConnectServer(OpcAdressInput.text);
            clientStateShow.text = client.Connected ? "connent" : "failure";
        }
        catch
        {
            clientStateShow.text = "error";
        }
    }

    /// <summary>
    /// 中断与OPC UA 服务器的连接
    /// </summary>
    public void DisConnectOPCUAServer()
    {
        if (client.Connected)
        {
            client.Disconnect();
            clientStateShow.text = "DisConnent";
        }
        else
        {
            clientStateShow.text = "DisConnent already";
        }
    }

    /// <summary>
    /// 读取指定节点的值（此节点值类型为BOOL类型，需读者自行调整设置）
    /// </summary>
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
            readResult.text = "error";
        }
    }

    /// <summary>
    /// 给指定节点写入新值（此节点值类型为BOOL类型，需读者自行调整设置）
    /// </summary>
    /// <param name="value">新值</param>
    public void WriteBoolValue(bool value)
    {
        string nodeId = nodeId_read_Input.text;
        try
        {
            client.WriteNode<bool>(nodeId, value);
            readResult.text = string.Empty;
            writeResult.text = $"write {value} ok";
        }
        catch
        {
            readResult.text = "error";
        }
    }
    #endregion

    #region 核心方法-订阅相关_旧
    /// <summary>
    /// 订阅监听指定节点内容变化事件
    /// </summary>
    [Obsolete]
    public void SubscribeNode_Old()
    {
        string nodeId = nodeId_sub_Input.text;
        client.AddSubscription("A", nodeId, MyMethod_Old);
        //以下需用户自定义开发
        {
            //client.AddSubscription("B", nodeId, SubCallback);
            //client.AddSubscription("C", nodeId, SubCallback);
        }
        nodeStateShow.text = "sub ok";
    }

    /// <summary>
    /// 指定节点内容变化事件和相关业务逻辑方法的绑定
    /// </summary>
    /// <param name="key">用户可自定义KEY，比如本例中A、B等</param>
    /// <param name="monitoredItem"></param>
    /// <param name="args"></param>
    [Obsolete]
    private void MyMethod_Old(string key, MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs args)
    {
        // 如果有多个的订阅值都关联了当前的方法，可以通过key和monitoredItem来区分
        if (key.Equals("A"))
        {
            //业务A：执行非OPC UA相关的业务逻辑方法等，用户可在此自定义开发
            MonitoredItemNotification notification = args.NotificationValue as MonitoredItemNotification;
            if (notification != null)
            {
                res = notification.Value.WrappedValue.Value.ToString();
                changeDate = DateTime.Now.ToString("G");
                isUpdateText = true;
            }
        }
        if (key.Equals("B"))
        {
            //业务B：执行非OPC UA相关的业务逻辑方法等，用户可在此自定义开发
        }
        if (key.Equals("C"))
        {
            //业务C：执行非OPC UA相关的业务逻辑方法等，用户可在此自定义开发
        }
    }
    #endregion

    #region 核心方法-订阅相关_新
    /// <summary>
    /// 当然，可使用扩展方法去忽略key概念
    /// </summary>
    public void SubscribeNode_New()
    {
        string nodeId = nodeId_sub_Input.text;
        client.AddSubscription(nodeId, MyMethod_New);
        nodeStateShow.text = "sub ok";
    }

    private void MyMethod_New(string nodeId, MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs args)
    {
        MonitoredItemNotification notification = args.NotificationValue as MonitoredItemNotification;
        if (notification != null)
        {
            string nodeIdNewValue = notification.Value.WrappedValue.Value.ToString();
        }
    }
    #endregion

    #region 核心方法-解除订阅_旧
    /// <summary>
    /// 移除对指定KEY值的订阅监听行为
    /// </summary>
    [Obsolete]
    public void RemoveSubscribeNode_Old()
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
            nodeStateShow.text = "error";
        }
    }
    #endregion

    #region 核心方法-解除订阅_新
    public void RemoveSubscribeNode_New()
    {
        string nodeId = nodeId_sub_Input.text;
        try
        {
            client.RemoveSubscribeNode(nodeId);
            nodeStateShow.text = "remove sub ok";
            changeTimeShow.text = "stop";
        }
        catch
        {
            nodeStateShow.text = "error";
        }
    }
    #endregion
}
