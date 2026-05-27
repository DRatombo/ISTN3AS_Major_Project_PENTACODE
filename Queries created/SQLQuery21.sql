INSERT INTO [Order]
(CustomerID, CashierID, OrderDateTime, OrderStatus, PaymentMethod, TotalAmountDue, TotalChangeDue, DeliveryCost)
VALUES
(1, 1, '2026-05-01 12:00:00', 'Completed', 'Cash', 99.99, 0.01, 15.00),
(2, 2, '2026-05-01 13:00:00', 'Completed', 'Card', 89.99, 0.00, 0.00),
(3, 3, '2026-05-02 14:00:00', 'Completed', 'Cash', 159.98, 10.02, 15.00),
(4, 1, '2026-05-02 15:00:00', 'Pending', 'Cash', 69.99, 0.00, 0.00),
(5, 2, '2026-05-03 16:00:00', 'Completed', 'Card', 129.98, 0.00, 0.00);