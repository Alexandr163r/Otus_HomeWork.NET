# Создание виртуальной базы данных магазина в PostgreSQL

## Создание таблиц

```sql
CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

-- Таблица товаров
CREATE TABLE Products (
    ProductID UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    ProductName VARCHAR(100) NOT NULL,
    Description TEXT,
    Price DECIMAL(10, 2) NOT NULL,
    QuantityInStock INTEGER NOT NULL
);

-- Таблица пользователей
CREATE TABLE Users (
    UserID UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    UserName VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    RegistrationDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Таблица заказов
CREATE TABLE Orders (
    OrderID UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    UserID UUID REFERENCES Users(UserID),
    OrderDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    Status VARCHAR(20) DEFAULT 'В процессе'
);

-- Таблица деталей заказа
CREATE TABLE OrderDetails (
    OrderDetailID UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    OrderID UUID REFERENCES Orders(OrderID) ON DELETE CASCADE,
    ProductID UUID REFERENCES Products(ProductID),
    Quantity INTEGER NOT NULL,
    TotalCost DECIMAL(10, 2) NOT NULL
);
```

## Описание запросов

1)  Добавление нового продукта
```sql
INSERT INTO Products (ProductName, Description, Price, QuantityInStock)
VALUES ('что то там', 'очень хорошее что то там', 99.99, 100);
```
2)  Обновление цены продукта
```sql
UPDATE Products
SET Price = 150.99
WHERE ProductID = :id;
```
3) Выбор всех заказов определенного пользователя
```sql
SELECT o.OrderID, o.OrderDate, o.Status
FROM Orders o
WHERE o.UserID = :id
ORDER BY o.OrderDate DESC;
```
4) Расчет общей стоимости заказа
```sql
SELECT o.OrderID, SUM(od.TotalCost) AS OrderTotal
FROM Orders o
JOIN OrderDetails od ON o.OrderID = od.OrderID
WHERE o.OrderID = :id -- пример UUID заказа
GROUP BY o.OrderID;
```
5) Подсчет количества товаров на складе
```sql
SELECT SUM(QuantityInStock) AS TotalProductsInStock
FROM Products;
```
6) Получение 5 самых дорогих товаров
```sql
SELECT ProductName, Price
FROM Products
ORDER BY Price DESC
LIMIT 5;
```
7) Список товаров с низким запасом (менее 5 штук)
```sql
SELECT ProductName, QuantityInStock
FROM Products
WHERE QuantityInStock < 5
ORDER BY QuantityInStock ASC;
```
## Диаграмма БД.
![Схема БД](https://github.com/Alexandr163r/Otus_HomeWork.NET/blob/main/img/diagram.png)
