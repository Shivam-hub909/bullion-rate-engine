# Real-Time Bullion Rate & Smart Inventory Engine

An enterprise-grade, high-throughput backend architecture designed for luxury jewelry retail networks. It streams live gold/silver spot prices via WebSockets (SignalR) and triggers sub-second inventory valuation updates across distributed store terminals.

## 🚀 Core Features
- **Live Price Streaming:** Implements ASP.NET Core SignalR for persistent WebSocket connections, eliminating polling overhead.
- **In-Memory Caching:** Utilizes localized fast-access states within a background worker service to reduce database reads.
- **Sub-second Calculations:** Reactively computes item weight, wastage, and fluid metal rates instantly upon price flux.

## 🛠️ Tech Stack
- **Backend Engineering:** C#, .NET 8, ASP.NET Core Web API, SignalR, Background Tasks
