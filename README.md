# 🛒 ECommerce Marketplace (.NET)

A full-featured E-Commerce Marketplace web application built with **ASP.NET Core MVC** and **Entity Framework Core**, designed to deliver a modern online shopping experience for customers and a powerful admin interface for product and order management.

---

## 📌 Features

✅ User authentication with registration, login, secure password hashing, and role-based access (Admin/User)  
✅ Product catalog with category-based browsing and detailed product views  
✅ Shopping cart with add, update, and remove items  
✅ Checkout process with order history for users  
✅ Admin dashboard for product, category, and order management  
✅ Responsive, mobile-first design using Bootstrap  
✅ Secure architecture with ASP.NET Core Identity  
✅ Database integration with Entity Framework Core and SQL Server  

---

## 🚀 Technologies Used

| Layer    | Technology                        |
| -------- | --------------------------------- |
| Backend  | ASP.NET Core MVC                  |
| Database | SQL Server, Entity Framework Core |
| Frontend | Razor Views, Bootstrap, jQuery    |
| Auth     | ASP.NET Core Identity             |
| ORM      | Entity Framework Core             |
| Tools    | Visual Studio/VS Code, .NET CLI   |

---

## 📁 Project Structure

```

ECommerce-Marketplace/
├── Controllers/        # MVC controllers for Home, Products, Cart, Orders, Admin
├── Models/             # Entity models and ViewModels
├── Data/               # ApplicationDbContext and database seeding
├── Views/              # Razor views for all pages
├── wwwroot/            # Static assets (CSS, JS, images)
├── appsettings.json    # Configuration (connection strings, etc.)
├── Program.cs          # Application entry point
└── Startup.cs          # Middleware, Identity, and service configuration

````

---

## ⚙️ Installation & Setup

> **Prerequisites**
> - [.NET 6 SDK or later](https://dotnet.microsoft.com/download)
> - SQL Server (local or cloud instance)

1️⃣ Clone the repository:

```bash
git clone https://github.com/rajatbalda/ECommerce-Marketplace.git
cd ECommerce-Marketplace
````

2️⃣ Update the database connection string in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=ECommerceDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

3️⃣ Apply EF Core migrations:

```bash
dotnet ef database update
```

4️⃣ Run the application:

```bash
dotnet run
```

5️⃣ Open your browser at:

```
https://localhost:5001
```

---

## 🧪 Usage Guide

* Register as a user or log in with existing credentials.
* Browse products by category or search.
* Add items to the cart, update quantities, or remove items.
* Proceed to checkout and confirm your order.
* View order history under your account.
* If your account has admin privileges, access `/Admin` to:

  * Add, edit, and delete products/categories.
  * View and manage user orders.

---

## 🚢 Deployment

### ✅ Deploying to Azure App Service

1. Create an App Service in the Azure portal.
2. Publish from Visual Studio or use Azure CLI:

```bash
dotnet publish -c Release
az webapp up --name <app-name> --resource-group <resource-group> --plan <app-service-plan>
```

### ✅ Deploying to IIS on Windows Server

1. Publish your app:

```bash
dotnet publish -c Release -o ./publish
```

2. Copy `./publish/` contents to your IIS site folder.
3. Configure your IIS site (ensure .NET Core Hosting Bundle is installed).

---

## 🧰 Development Commands

* `dotnet build` — Build the project
* `dotnet run` — Run the app locally
* `dotnet ef migrations add <MigrationName>` — Create a new EF migration
* `dotnet ef database update` — Apply migrations

---

## 🙌 Contributing

Pull requests are welcome! Here’s how:

1. Fork the repository

2. Create a feature branch:

   ```bash
   git checkout -b feature/your-feature
   ```

3. Commit your changes:

   ```bash
   git commit -m "Add your feature"
   ```

4. Push your branch:

   ```bash
   git push origin feature/your-feature
   ```

5. Open a pull request on GitHub

---

## 👤 Author

**Rajat Balda**

* [GitHub](https://github.com/rajatbalda)
* [Website](https://rajatbalda.in)
* [LinkedIn](https://linkedin.com/in/rajatbalda)

---

## 📝 License

This project is licensed under the [MIT License](LICENSE).

---

## ⭐️ Show Your Support

If you like this project, please ⭐️ it on [GitHub](https://github.com/rajatbalda/ECommerce-Marketplace) — it helps others find it!

---

## 📧 Contact

For questions or feedback, reach out to [rajatbalda@gmail.com](mailto:contact@rajatbalda.in).

---

## ✅ Future Enhancements

* Integrate payment gateways (Stripe, PayPal)
* Add product reviews and ratings
* Implement wishlists
* Inventory management features
* Multi-language and localization support
* Upgrade UI with React or Blazor

```
