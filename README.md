# Unity3D OPC UA Client

在 Unity3D 中实现 **OPC UA 客户端** 的简单 Demo，可用于与 PLC 等工业设备进行数据通信。

> A simple demo implementing an **OPC UA Client** in Unity3D for data communication with industrial devices such as PLCs.

---

## 功能 / Features

- 连接 / Disconnect OPC UA 服务器
- 读取 / Write 节点数据
- 订阅 / Unsubscribe 节点数据变更通知

---

## 截图 / Screenshot

![Unity3D OPC UA Client Demo](https://github.com/user-attachments/assets/cfecdfa2-dd0c-49dc-ae4b-3b2343311329)

---

## 依赖 / Dependencies

- [OpcUaHelper](https://github.com/dathlin/OpcUaHelper.git) — OPC UA 客户端封装库
- NuGet 相关依赖包

---

## 环境 / Requirements

- Unity3D **2021.3.18f1c1**
- Windows

---

## 快速开始 / Quick Start

```bash
git clone https://github.com/1947899648/Unity3D-OPC-UA-Client.git
```

1. 使用 Unity 2021.3.18f1c1+ 打开项目
2. 确保本地已运行 OPC UA 服务器（如 KepServerEX、Prosys 等）
3. 打开 Demo 场景，填写服务器地址和节点信息
4. 运行测试

---

## 致谢 / Credits

- [dathlin/OpcUaHelper](https://github.com/dathlin/OpcUaHelper)
- OPC Foundation

---

## 许可证 / License

[MIT](./LICENSE)
