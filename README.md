<h1 align="center">🔌 Unity3D OPC UA Client</h1>

<p align="center">
  <img src="https://img.shields.io/badge/Unity-2021.3.18f1c1-blue?logo=unity" alt="Unity">
  <img src="https://img.shields.io/badge/OPC_UA-Client-orange?logo=opc" alt="OPC UA">
  <img src="https://img.shields.io/badge/PLC-Industrial-green" alt="PLC">
  <img src="https://img.shields.io/badge/platform-Windows-lightgrey?logo=windows" alt="Windows">
  <img src="https://img.shields.io/badge/license-MIT-brightgreen" alt="License">
</p>

<p align="center">
  <a href="#-概述--overview">📖 概述</a> •
  <a href="#-功能--features">✨ 功能</a> •
  <a href="#-截图--screenshot">📸 截图</a> •
  <a href="#-环境要求--requirements">📋 环境要求</a> •
  <a href="#-依赖说明--dependencies">📦 依赖说明</a> •
  <a href="#-快速开始--quick-start">🚀 快速开始</a> •
  <a href="#-致谢--credits">🙏 致谢</a> •
  <a href="#-许可证--license">📄 许可证</a>
</p>

---

## 📖 概述 / Overview

在 Unity3D 中实现 **OPC UA 客户端** 的简单 Demo，可用于与 PLC 等工业设备进行数据通信。

> A simple demo implementing an **OPC UA Client** in Unity3D for data communication with industrial devices such as PLCs.

---

## ✨ 功能 / Features

| 功能 / Feature | 说明 / Description |
|:---:|---|
| 🔗 连接 / Connect | 连接 OPC UA 服务器 |
| 🔌 断开 / Disconnect | 断开与 OPC UA 服务器的连接 |
| 📖 读 / Read | 读取节点数据 |
| ✏️ 写 / Write | 写入节点数据 |
| 📡 订阅 / Subscribe | 订阅节点数据变更通知 |
| ❌ 取消订阅 / Unsubscribe | 解除节点数据订阅 |

---

## 📸 截图 / Screenshot

<p align="center">
  <img src="https://github.com/user-attachments/assets/cfecdfa2-dd0c-49dc-ae4b-3b2343311329" width="80%" alt="Unity3D OPC UA Client Demo" />
</p>

---

## 📋 环境要求 / Requirements

| 项目 | 说明 |
|------|------|
| 引擎 | Unity3D **2021.3.18f1c1** |
| 平台 | Windows |
| 运行时 | .NET Framework / .NET Standard 2.0 |
| 依赖库 | [OpcUaHelper](https://github.com/dathlin/OpcUaHelper) + NuGet 包 |

---

## 📦 依赖说明 / Dependencies

本项目核心 OPC UA 通信能力基于以下开源库：

- **[OpcUaHelper](https://github.com/dathlin/OpcUaHelper.git)** — OPC UA 客户端封装库
- **NuGet** 相关依赖包（详见 `Packages/manifest.json`）

> The core OPC UA communication is powered by [OpcUaHelper](https://github.com/dathlin/OpcUaHelper.git) and related NuGet packages.

---

## 🚀 快速开始 / Quick Start

### 1. 下载 / Download

```bash
git clone https://github.com/1947899648/Unity3D-OPC-UA-Client.git
```

或前往 [Releases](https://github.com/1947899648/Unity3D-OPC-UA-Client/releases) 下载最新 `UnityPackage`。

### 2. 打开项目 / Open

使用 **Unity 2021.3.18f1c1** 或更高版本打开项目。

### 3. 运行 / Run

1. 确保本地已运行 OPC UA 服务器（如 KepServerEX、Prosys 等）
2. 打开 Demo 场景
3. 填写服务器地址和节点信息
4. 点击 Play 运行，测试读写订阅功能

---

## 🙏 致谢 / Credits

- OPC UA 库封装：[dathlin/OpcUaHelper](https://github.com/dathlin/OpcUaHelper)
- OPC Foundation — OPC UA 协议标准

---

## 📄 许可证 / License

本项目使用 [MIT License](./LICENSE) 开源许可。
