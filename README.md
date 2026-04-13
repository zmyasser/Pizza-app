# 🍕 Pizza Order System — Windows Forms Application

## 📌 Overview

This project is a **Pizza Ordering System** built using **C# and Windows Forms (.NET Framework)**.
It allows users to customize their pizza by selecting size, toppings, crust type, quantity, and dining preference, while dynamically calculating the total price.

The application focuses on **clean UI interaction, real-time updates, and structured logic**, making it a great example of event-driven desktop development.

---

## 🚀 Features

### 🧾 Pizza Customization

* Choose pizza size:

  * Small
  * Medium
  * Large
* Select multiple toppings:

  * Extra Cheese
  * Mushrooms
  * Tomatoes
  * Onion
  * Olives
  * Green Peppers
* Choose crust type:

  * Thin
  * Thick
* Select order type:

  * Eat In
  * Take Out
* Adjust quantity using a numeric selector

---

### 💰 Real-Time Price Calculation

* Automatically updates total price when:

  * Size changes
  * Toppings are selected/unselected
  * Crust type changes
  * Quantity changes
* Uses control `Tag` properties to store pricing values (clean and scalable design)

---

### 🔄 Reset Functionality

* Restores all selections to default:

  * Medium size
  * No toppings
  * Thin crust
  * Eat In
  * Quantity = 1
* Re-enables all controls
* Updates UI instantly

---

### ✅ Order Confirmation

* Displays confirmation dialog before placing order
* Shows success message upon confirmation
* Locks the form after order is placed to prevent further changes

---

## 🧠 Technical Highlights

### 🏗 Architecture

The application is structured using **modular methods**:

* `GetSelectedSizePrice()` → Calculates price based on size and quantity
* `CalculateToppingsPrice()` → Sums selected toppings
* `GetCrustPrice()` → Returns crust cost
* `GetTotalPrice()` → Combines all pricing logic

---

### 🔁 UI Update System

* Centralized update methods:

  * `UpDateSize()`
  * `UpDateToppings()`
  * `UpDateCrust()`
  * `UpDateWhereToEat()`
  * `UpDateTotalPrice()`
* `UpDateAll()` ensures full UI refresh

---

### ⚡ Event Handling Optimization

* Uses `_shouldUpdate` flag to:

  * Prevent unnecessary updates during reset
  * Avoid redundant event triggers
* Efficient event-driven design

---

## 🛠 Technologies Used

* C#
* Windows Forms (.NET Framework)
* Visual Studio

---

## 📂 Project Structure

```
Pizza/
│── Form1.cs          # Main logic and event handling
│── Form1.Designer.cs # UI layout (auto-generated)
│── Program.cs        # Application entry point
```

---

## ▶️ How to Run

1. Open the project in **Visual Studio**
2. Build the solution
3. Run the application (`F5`)
4. Start customizing your pizza 🍕

---

## 👨‍💻 Author

Developed as part of learning **C# desktop development and UI event handling**.

---

## 📜 License

This project is open-source and available for learning and educational purposes.
