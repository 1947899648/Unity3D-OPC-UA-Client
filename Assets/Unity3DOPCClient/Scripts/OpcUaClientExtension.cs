using Opc.Ua.Client;
using OpcUaHelper;
using System;

/// <summary>
/// 拓展方法，取消对key概念的关注
/// </summary>
public static class OpcUaClientExtension
{
    /// <summary>
    /// 对某NodeID进行监听
    /// 若不采用AddSubscription方法中key参数，即key和tag均设置为NodeID时
    /// callback回调方法里返回的第一个string内容为NodeID，而非key，开发者可直接忽略
    /// </summary>
    /// <param name="opcUaClient"></param>
    /// <param name="nodeId"></param>
    /// <param name="callback"></param>
    public static void AddSubscription(this OpcUaClient opcUaClient,string nodeId, Action<string, MonitoredItem, MonitoredItemNotificationEventArgs> callback)
    {
        opcUaClient.AddSubscription(nodeId, nodeId, callback);
    }

    /// <summary>
    /// 解除针对某NodeID的监听
    /// </summary>
    /// <param name="opcUaClient"></param>
    /// <param name="nodeId"></param>
    public static void RemoveSubscribeNode(this OpcUaClient opcUaClient,string nodeId)
    {
        opcUaClient.RemoveSubscription(nodeId);
    }
}
