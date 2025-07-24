# 🌟 API Gateway Demo with .NET 9

![.NET](https://img.shields.io/badge/.NET-9.0-blueviolet)

![Ocelot](https://img.shields.io/badge/Ocelot-API%20Gateway-orange)

Welcome to the **API Gateway Demo**! 🚀 This repository demonstrates a modern **API Gateway** implementation using **Ocelot** in **.NET 9**, featuring two N-Layer APIs: a sleek **Minimal API** for products and a robust **controller-based API** for orders.

Perfect for learning API Gateway patterns, exploring clean architecture, or building scalable microservices! 💻

## 🎯 Why You'll Love This Project

- **Master API Gateways**: Learn how Ocelot routes requests and simplifies microservice communication.
- **N-Layer Architecture**: Clean, modular design with **Presentation**, **Application**, **Domain**, and **Infrastructure** layers.
- **Minimal vs. Standard APIs**: Compare a lightweight Minimal API with a traditional MVC API.
- **Production-Ready**: Built with .NET 9 best practices for scalability and maintainability.
- **Easy to Run**: Fully configured with Git, unit tests, and clear setup instructions.

## 📂 Project Structure

```
📂 ApiGatewayDemo
├── 📂 doc            # Documentation
├── 📂 src            # Source code
│   ├── 📂 Gateway    # Ocelot-based API Gateway
│   ├── 📂 OrderApi   # Standard API for orders
│   └── 📂 ProductApi # Minimal API for products
├── 📂 test           # Unit tests
└── 📜 README.md      # This file
```

## 🚀 Get Started

### Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- A terminal (e.g., PowerShell, Bash, or VS Code terminal)
- Optional: [Visual Studio Code](https://code.visualstudio.com/) or [Visual Studio](https://visualstudio.microsoft.com/)

### Setup
1. **Clone the Repository**:
   ```bash
   git clone https://github.com/AlejBlasco/ApiGatewayDemo.git
   cd api-gateway-demo
   ```

2. **Restore Dependencies**:
   ```bash
   dotnet restore
   ```

3. **Run the APIs**:
   Start each project in a separate terminal:
   ```bash
   cd src/Gateway
   dotnet run
   ```
   ```bash
   cd src/ProductApi
   dotnet run
   ```
   ```bash
   cd src/OrderApi
   dotnet run
   ```

4. **Access the Gateway**:
   - Gateway: `http://localhost:5000`
   - Test endpoints:
     - Products: `curl http://localhost:5000/api/products`
     - Orders: `curl http://localhost:5000/api/orders`

5. **Run Tests**:
   ```bash
   cd tests
   dotnet test
   ```

## 🧪 Test the APIs

- **Get Products**:
  ```bash
  curl http://localhost:5000/api/products
  ```
  **Expected Response**:
  ```json
  [
    {"id": 1, "name": "Laptop", "price": 999.99},
    {"id": 2, "name": "Phone", "price": 499.99}
  ]
  ```

- **Get Orders**:
  ```bash
  curl http://localhost:5000/api/orders
  ```
  **Expected Response**:
  ```json
  [
    {"id": 1, "productId": 1, "quantity": 2},
    {"id": 2, "productId": 2, "quantity": 1}
  ]
  ```

## 🛠️ Troubleshooting

- **Gateway not responding?**
  - Ensure `ocelot.json` exists in `src/Gateway` and is valid JSON.
  - Verify ProductApi (`http://localhost:5001`) and OrderApi (`http://localhost:5002`) are running.
  - Check port 5000: `netstat -a -n -o | find "5000"` (Windows) or `lsof -i :5000` (Linux/macOS).
- **Build errors?**
  - Run `dotnet restore` to resolve dependencies.
  - Confirm .NET 9 is installed: `dotnet --version`.

## 📚 Resources

- [Ocelot Documentation](https://ocelot.readthedocs.io/en/latest/)
- [.NET 9 Minimal APIs](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis)
- [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)

## 🤝 Contribute

Want to make this project even better? Contributions are welcome! 🙌
- Fork the repo and submit a pull request.
- Report bugs or suggest features via [issues](https://github.com/AlejBlasco/ApiGatewayDemo/issues).
