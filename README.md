# SieMarket Console Application

This project implements the requirements of **Problem 2** by modeling orders for an online electronics store and providing basic business logic and analytics.

---

## Overview

The application is a small .NET console app structured around simple domain models and a service layer.
All data is handled in memory and demonstrated through a sample dataset in `Program.cs`.

---

# Requirement Mapping

## 2.1 — Classes for Orders and Items

**Where implemented**

* `Models/Order.cs`
* `Models/OrderItem.cs`

**How it is fulfilled**

* `OrderItem` stores:

  * `ProductName`
  * `Quantity`
  * `UnitPrice`
  * Method `GetTotal()` to compute item total
* `Order` stores:

  * `CustomerName`
  * `List<OrderItem> Items`
  * Method `GetTotalBeforeDiscount()`

These classes represent the domain entities exactly as described in the problem.

---

## 2.2 — Final Price Calculation with Discount

**Where implemented**

* `Order.GetFinalTotal()` in `Models/Order.cs`

**Logic**

1. Sum all item totals
2. If total exceeds **500€**, apply **10% discount**
3. Return the computed final value

This encapsulates the pricing rule inside the domain model, keeping the logic reusable and testable.

---

## 2.3 — Customer Who Spent the Most

**Where implemented**

* `Services/OrderAnalytics.cs`
* Method: `GetTopCustomer(IEnumerable<Order> orders)`

**How it works**

* Groups orders by customer
* Sums final totals per customer
* Returns the customer with the highest aggregated spend

The method returns `null` if no orders exist, ensuring safe behavior.

---

## 2.4 (Bonus) — Popular Products by Quantity Sold

**Where implemented**

* `Services/OrderAnalytics.cs`
* Method: `GetPopularProducts(IEnumerable<Order> orders)`

**How it works**

* Flattens all order items
* Groups by product name
* Sums quantities per product
* Returns a dictionary of product → total sold

---

# Project Structure

```
SieMarketApp
│
├── Models
│   ├── Order.cs
│   └── OrderItem.cs
│
├── Services
│   └── OrderAnalytics.cs
│
└── Program.cs
```

* **Models** → domain representation
* **Services** → business and aggregation logic
* **Program** → sample data + execution

---

# How to Run

```bash
dotnet run
```

The console output will display:

* Final totals per order
* Top customer
* Aggregated product sales

---
