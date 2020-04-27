Q1
SELECT first_name + ' ' + last_name AS CustomerName, email AS Email, city AS City FROM customers WHERE state = 'NY'
***


Q2
SELECT stores.store_name AS StoreName, products.product_name AS ProductName, stocks.quantity AS QuantityOfProducts FROM stores JOIN stocks ON stores.store_id = stocks.store_id JOIN products ON stocks.product_id = products.product_id
***


Q3
SELECT stores.store_name AS StoreName FROM customers JOIN orders ON customers.customer_id = orders.customer_id JOIN stores ON orders.store_id = stores.store_id GROUP BY stores.store_name HAVING COUNT(customers.customer_id) =
(SELECT MAX(myCount) FROM (SELECT stores.store_name, Count(customers.customer_id) myCount FROM customers JOIN orders ON customers.customer_id = orders.customer_id JOIN stores ON orders.store_id = stores.store_id GROUP BY stores.store_name) AS abc)
***


Q4
SELECT brands.brand_name AS BrandName FROM products JOIN brands ON products.brand_id = brands.brand_id JOIN order_items ON products.product_id = order_items.product_id GROUP BY brands.brand_name HAVING COUNT(order_items.quantity) = 
(SELECT MAX(myCount) FROM (SELECT brands.brand_name, COUNT(order_items.quantity) AS myCount FROM products JOIN brands ON products.brand_id = brands.brand_id JOIN order_items ON products.product_id = order_items.product_id GROUP BY brands.brand_name) AS abc)
***


Q5
SELECT stff.first_name + ' ' + stff.last_name AS StaffMemberName, mngr.first_name + ' ' + mngr.last_name AS ManagerName  FROM staffs AS mngr JOIN staffs AS stff on stff.manager_id = mngr.staff_id
***

Q6
SELECT stores.store_name AS StoreName, COUNT(staffs.staff_id) AS CountOfStaffMembers FROM staffs JOIN stores ON staffs.store_id = stores.store_id WHERE staffs.active = 1 GROUP BY stores.store_name
***

Q7
SELECT customers.customer_id, COUNT(products.product_id) FROM customers JOIN orders ON customers.customer_id = orders.customer_id JOIN order_items ON orders.order_id = order_items.order_id JOIN products ON order_items.product_id = products.product_id JOIN categories ON products.category_id = categories.category_id GROUP BY customers.customer_id
***


Q8
SELECT customers.first_name + ' ' + customers.last_name AS CustomerName, discount AS Discount FROM customers JOIN 
(SELECT customers.customer_id, SUM(order_items.discount) AS discount FROM customers JOIN orders ON customers.customer_id = orders.customer_id JOIN order_items ON orders.order_id = order_items.order_id WHERE YEAR(orders.order_date) = '2010' GROUP BY customers.customer_id) as abc
ON customers.customer_id = abc.customer_id
***


Q9
SELECT customers.state FROM customers JOIN orders ON customers.customer_id = orders.customer_id JOIN order_items ON orders.order_id = order_items.order_id GROUP BY customers.state HAVING Count(orders.order_id) =
(SELECT MAX(myCount) FROM
(SELECT customers.state, Count(orders.order_id) AS myCount FROM customers JOIN orders ON customers.customer_id = orders.customer_id JOIN order_items ON orders.order_id = order_items.order_id GROUP BY customers.state) AS abc)
***

Q10
SELECT stores.store_name, CountOfPendingOrders, CountOfProcessedOrders, CountOfRejectedOrders, CountOfCompletedOrders FROM stores JOIN
(SELECT stores.store_id, COUNT(orders.order_status) AS CountOfPendingOrders FROM orders JOIN stores ON orders.store_id = stores.store_id WHERE orders.order_status = '1' GROUP BY stores.store_id) AS T1
ON stores.store_id = T1.store_id JOIN
(SELECT stores.store_id, COUNT(orders.order_status) AS CountOfProcessedOrders FROM orders JOIN stores ON orders.store_id = stores.store_id WHERE orders.order_status = '2' GROUP BY stores.store_id) AS T2
ON T1.store_id = T2.store_id JOIN
(SELECT stores.store_id, COUNT(orders.order_status) AS CountOfRejectedOrders FROM orders JOIN stores ON orders.store_id = stores.store_id WHERE orders.order_status = '3' GROUP BY stores.store_id) AS T3
ON T2.store_id = T3.store_id JOIN
(SELECT stores.store_id, COUNT(orders.order_status) AS CountOfCompletedOrders FROM orders JOIN stores ON orders.store_id = stores.store_id WHERE orders.order_status = '4' GROUP BY stores.store_id) AS T4
ON T3.store_id = T4.store_id
***