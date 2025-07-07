ECommerce Marketplace (.NET)
============================

A full-featured E-Commerce Marketplace web application built with ASP.NET Core MVC and Entity Framework Core, designed to provide a modern online shopping experience for customers and a powerful admin interface for managing products and orders.

────────────────────────────
FEATURES
────────────────────────────

✅ User Authentication: Registration, login, password hashing, and role-based access control (Admin/User).
✅ Product Catalog: Browse products by categories, view detailed product pages.
✅ Shopping Cart: Add, update, and remove items; view cart summary.
✅ Order Management: Users can place orders, view order history; admins can manage orders.
✅ Admin Dashboard: CRUD operations for products and categories.
✅ Responsive Design: Built with Bootstrap for mobile-first, responsive layouts.
✅ Secure Architecture: ASP.NET Core Identity for authentication and authorization.
✅ Database Integration: Uses Entity Framework Core with SQL Server for data persistence.

────────────────────────────
TECHNOLOGIES USED
────────────────────────────

Backend: ASP.NET Core MVC
Database: SQL Server, Entity Framework Core
Frontend: Razor Views, Bootstrap, jQuery
Auth: ASP.NET Core Identity
ORM: Entity Framework Core
Tools: Visual Studio / VS Code, .NET CLI

────────────────────────────
PROJECT STRUCTURE
────────────────────────────

ECommerce-Marketplace/
├── Controllers/        # MVC controllers for Home, Products, Cart, Orders, Admin
├── Models/             # Entity models and ViewModels
├── Data/               # ApplicationDbContext and initial seeding
├── Views/              # Razor views for all pages
├── wwwroot/            # Static assets: CSS, JS, images
├── appsettings.json    # Application configuration
├── Program.cs          # Entry point
└── Startup.cs          # Middleware, DI, Identity, routing config

────────────────────────────
INSTALLATION & SETUP
────────────────────────────

Prerequisites:
- .NET 6 SDK or later
- SQL Server (local or cloud)

1) Clone the repository:
   git clone https://github.com/rajatbalda/ECommerce-Marketplace.git
   cd ECommerce-Marketplace

2) Update database connection string in appsettings.json:
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER;Database=ECommerceDB;Trusted_Connection=True;MultipleActiveResultSets=true"
   }

3) Apply migrations and seed the database:
   dotnet ef database update

4) Run the application:
   dotnet run

5) Open your browser at:
   https://localhost:5001

────────────────────────────
USAGE GUIDE
────────────────────────────

- Register as a new user or log in with existing credentials.
- Browse products via the homepage or category pages.
- Add items to your cart, update quantities, or remove items.
- Proceed to checkout, confirm order, and view order history.
- If your account has admin privileges, access /Admin to:
  • Manage products & categories.
  • View and manage user orders.

────────────────────────────
DEPLOYMENT
────────────────────────────

Deploy to Azure App Service:
1) Create an App Service in Azure portal.
2) Publish from Visual Studio or use CLI:
   dotnet publish -c Release
   az webapp up --name <app-name> --resource-group <resource-group> --plan <app-service-plan>

Deploy to IIS:
1) dotnet publish -c Release -o ./publish
2) Copy ./publish/ contents to your IIS site folder.
3) Set up IIS site with .NET Core Hosting Bundle.

────────────────────────────
DEVELOPMENT COMMANDS
────────────────────────────

- dotnet build — Build the project.
- dotnet run — Run the app.
- dotnet ef migrations add <MigrationName> — Add EF migration.
- dotnet ef database update — Apply migrations.

────────────────────────────
CONTRIBUTING
────────────────────────────

1) Fork the repo.
2) Create a feature branch: git checkout -b feature/your-feature
3) Commit your changes: git commit -m 'Add your feature'
4) Push: git push origin feature/your-feature
5) Open a pull request.

────────────────────────────
AUTHOR
────────────────────────────

Rajat Balda
- GitHub: https://github.com/rajatbalda
- Website: https://rajatbalda.in
- LinkedIn: https://linkedin.com/in/rajatbalda

────────────────────────────
LICENSE
────────────────────────────

This project is licensed under the MIT License.

────────────────────────────
SHOW YOUR SUPPORT
────────────────────────────

⭐️ Star it on GitHub: https://github.com/rajatbalda/ECommerce-Marketplace

────────────────────────────
CONTACT
────────────────────────────

Email: contact@rajatbalda.in

────────────────────────────
FUTURE ENHANCEMENTS
────────────────────────────

- Integrate payment gateways (Stripe, PayPal)
- Add product reviews and ratings
- Implement wishlists
- Inventory management
- Multi-language support
- UI enhancements with React or Blazor
