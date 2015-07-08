-----------------------------------------------------------------------------
-- Part 4
-----------------------------------------------------------------------------
-- Problem 18.	Design a Database Schema in MySQL and Write a Query
-----------------------------------------------------------------------------

-- 1.	Design a MySQL database "orders" to hold products, customers and orders. 
-- Products hold name and price. Customers hold name. Orders hold customer, date and set of order items. 
-- Order items hold order, product and quantity. All tables should have auto-increment primary key – id.

DROP DATABASE IF EXISTS orders;

create schema orders
default character set utf8
collate utf8_general_ci;

Use orders;

CREATE TABLE products
	(product_id int NOT NULL AUTO_INCREMENT,
	 product_name nvarchar(50) NOT NULL,
     price Float NOT NULL,
     PRIMARY KEY(product_id)
    );
    
CREATE TABLE customers
	(customer_id int NOT NULL AUTO_INCREMENT,
     customer_name nvarchar(50) NOT NULL,
     PRIMARY KEY (customer_id)
    );
    
CREATE TABLE orders
	(order_id int NOT NULL AUTO_INCREMENT,
     order_date datetime,
     PRIMARY KEY (order_id)
    );
    
CREATE TABLE order_items
	(order_items_id int NOT NULL AUTO_INCREMENT,
	 order_id int NOT NULL,
     product_id int NOT NULL,
     quantity int NOT NULL,
     primary key (order_items_id),
     FOREIGN KEY (order_id) references orders(order_id),
     FOREIGN KEY (product_id) references products(product_id)
    );
    
-- 2.	Execute the following SQL script to load data in your tables. It should pass without any errors:

INSERT INTO `products` VALUES (1,'beer',1.20), (2,'cheese',9.50), (3,'rakiya',12.40), (4,'salami',6.33), (5,'tomatos',2.50), (6,'cucumbers',1.35), (7,'water',0.85), (8,'apples',0.75);
INSERT INTO `customers` VALUES (1,'Peter'), (2,'Maria'), (3,'Nakov'), (4,'Vlado');
INSERT INTO `orders` VALUES (1,'2015-02-13 13:47:04'), (2,'2015-02-14 22:03:44'), (3,'2015-02-18 09:22:01'), (4,'2015-02-11 20:17:18');
INSERT INTO `order_items` VALUES (12,4,6,2.00), (13,3,2,4.00), (14,3,5,1.50), (15,2,1,6.00), (16,2,3,1.20), (17,1,2,1.00), (18,1,3,1.00), (19,1,4,2.00), (20,1,5,1.00), (21,3,1,4.00), (22,1,1,3.00);

-- 3.	Write a SQL query to list all products alphabetically along with the number of orders for each product, 
-- the quantity sold (for all orders), the product price, and the total price (quantity * price).

select p.product_name, 
	COUNT(o.order_id) as `num_orders`, 
    TRUNCATE(ifnull(SUM(oi.quantity), 0.00), 2) as `quantity`, 
    TRUNCATE(p.price, 2) as `price`, 
    TRUNCATE(ifnull(SUM(oi.quantity), 0.00) * p.price, 4) as `total_price`
from products p 
left join order_items oi on p.product_id = oi.product_id
left join orders o on oi.order_id = o.order_id
group by p.product_name, p.price
order by product_name;
