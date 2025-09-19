# AbySalto.Junior .NET

## Setup

1. Clone the repository
2. Open `appsettings.Development.json` and set the `DefaultConnection` to point to your SQL Server instance. Default should be `Server=localhost`, but this project uses `Server=localhost\\SQLEXPRESS02`
3. Apply database migrations with `dotnet ef database update` or via Visual Studio Package Manager Console with the command `Update-Database`
4. Run the project

## Test order

```json
{
  "customerName": "John Doe",
  "status": "Pending",
  "orderTime": "2025-09-19T08:38:41.454Z",
  "paymentMethod": "Credit Card",
  "deliveryAddress": "123 Zagreb",
  "contactNumber": "+1234567890",
  "note": "Leave at the door.",
  "currency": "EUR",
  "items": [
    {
      "name": "Pizza",
      "quantity": 2,
      "price": 10.00
    }
  ]
}
