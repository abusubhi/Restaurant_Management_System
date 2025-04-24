-- Insert into UserRole
INSERT INTO UserRole (RoleName, isActive)
VALUES 
('Admin', 1),
('Customer', 1),
('Driver', 1),
('Manager', 1),
('Staff', 1);

-- Insert into Users
INSERT INTO Users (FirstName, LastName, Username, [Password], Email, PhoneNumber, Profile_Image, UserRoleID)
VALUES
('John', 'Doe', 'johndoe', 'SecurePass123!', 'john@gmail.com', '0771234567', 'profile1.jpg', 1),
('Jane', 'Smith', 'janesmith', 'JanePass456!', 'jane@hotmail.com', '0782345678', 'profile2.jpg', 2),
('Mike', 'Johnson', 'mikej', 'MikePass789!', 'mike@outlook.com', '0793456789', 'profile3.jpg', 3),
('Sarah', 'Williams', 'sarahw', 'SarahPass012!', 'sarah@zoho.com', '0774567890', 'profile4.jpg', 4),
('David', 'Brown', 'davidb', 'DavidPass345!', 'david@gmail.com', '0785678901', 'profile5.jpg', 5);

-- Insert into Categorys
INSERT INTO Categorys (Name_en, Name_ar, [Image], CreatedBy)
VALUES
('Electronics', N'إلكترونيات', 'electronics.jpg', 'admin'),
('Clothing', N'ملابس', 'clothing.jpg', 'admin'),
('Food', N'طعام', 'food.jpg', 'admin'),
('Furniture', N'أثاث', 'furniture.jpg', 'admin'),
('Books', N'كتب', 'books.jpg', 'admin');

-- Insert into Items
INSERT INTO Items (NameAR, NameEN, ItemImage, DescriptionAR, DescriptionEN, Price, CategoryID, CreatedBy)
VALUES
(N'هاتف ذكي', 'Smartphone', 'phone.jpg', N'هاتف ذكي حديث', 'Modern smartphone', 599.99, 1, 'admin'),
(N'قميص', 'Shirt', 'shirt.jpg', N'قميص قطني', 'Cotton shirt', 29.99, 2, 'admin'),
(N'بيتزا', 'Pizza', 'pizza.jpg', N'بيتزا لذيذة', 'Delicious pizza', 12.99, 3, 'admin'),
(N'كرسي', 'Chair', 'chair.jpg', N'كرسي مريح', 'Comfortable chair', 89.99, 4, 'admin'),
(N'رواية', 'Novel', 'novel.jpg', N'رواية مشوقة', 'Exciting novel', 14.99, 5, 'admin');

-- Insert into ItemOptions
INSERT INTO ItemOptions (NameAR, NameEN, IsRequired, ItemID)
VALUES
(N'لون', 'Color', 1, 1),
(N'حجم', 'Size', 1, 2),
(N'مكونات إضافية', 'Extra toppings', 0, 3),
(N'مادة', 'Material', 1, 4),
(N'نوع الغلاف', 'Cover type', 0, 5);

-- Insert into Orders
INSERT INTO Orders (OrderCreationDate, TotalPrice, Rate, [Status], Latitude, Longitude, PaymentMethod, [PaymentStatus], ItemID, ClientID, DriverID)
VALUES
(GETDATE(), 599.99, 4.5, 'Completed', 31.9566, 35.9457, 'Credit Card', 'Completed', 1, 2, 3),
(GETDATE()-1, 59.98, 4.0, 'On Shipment', 31.9566, 35.9457, 'Cash', 'Pending', 2, 2, 3),
(GETDATE()-2, 38.97, 4.8, 'Active', 31.9566, 35.9457, 'Online Payment', 'Completed', 3, 2, 3),
(GETDATE()-3, 89.99, 3.5, 'Pending', 31.9566, 35.9457, 'Debit Card', 'Completed', 4, 2, 3),
(GETDATE()-4, 29.98, 5.0, 'Cancelled', 31.9566, 35.9457, 'Cash', 'Failed', 5, 2, 3);

-- Insert into OrderItems
INSERT INTO OrderItems (OrderID, ItemID, Quantity, Price_at_time_of_order)
VALUES
(1, 1, 1, 599.99),
(2, 2, 2, 29.99),
(3, 3, 3, 12.99),
(4, 4, 1, 89.99),
(5, 5, 2, 14.99);

-- Insert into Addresses
INSERT INTO Addresses (Province, Region, AddressHint, UserID)
VALUES
(N'Jordanian', N'Amman', N'Near City Mall', 2),
(N'Jordanian', N'Zarqa', N'Main Street', 2),
(N'Jordanian', N'Irbid', N'University Street', 3),
(N'Jordanian', N'Aqaba', N'Near Red Sea', 4),
(N'Jordanian', N'Madaba', N'Church Area', 5);

-- Insert into CardPayment
INSERT INTO CardPayment (CardNumber, CardHolderName, ExpiryDate, CVV, CardType, UserID)
VALUES
('4111111111111111', 'John Doe', '12/25', '123', 'Visa', 2),
('5555555555554444', 'Jane Smith', '06/24', '456', 'MasterCard', 3),
('378282246310005', 'Mike Johnson', '09/23', '789', 'Amex', 4),
('6011111111111117', 'Sarah Williams', '03/26', '321', 'Discover', 5),
('4222222222222', 'David Brown', '11/24', '654', 'Visa', 2);

-- Insert into Rates
INSERT INTO Rates ([Message], ItemRate, UserID, ItemID)
VALUES
('Great product!', 5.0, 2, 1),
('Good quality', 4.0, 3, 2),
('Excellent service', 4.5, 4, 3),
('Average product', 3.0, 5, 4),
('Perfect!', 5.0, 2, 5);

-- Insert into Notifications
INSERT INTO Notifications (Title, NotificationType, UserID)
VALUES
('New Order', 'New Order', 2),
('Order Shipped', 'order update', 2),
('Special Offer', 'promotional', 3),
('Support Ticket', 'Support', 4),
('System Update', 'New System Action', 5);

-- Insert into OTPs
INSERT INTO OTPs (OTPCode, ExpirationTime, UserID)
VALUES
(12345, DATEADD(MINUTE, 10, GETDATE()), 2),
(54321, DATEADD(MINUTE, 10, GETDATE()), 3),
(98765, DATEADD(MINUTE, 10, GETDATE()), 4),
(56789, DATEADD(MINUTE, 10, GETDATE()), 5),
(13579, DATEADD(MINUTE, 10, GETDATE()), 2);

-- Insert into Offers
INSERT INTO Offers (Title_EN, Description_EN, Title_AR, Description_AR, Start_Date, End_Date, Limit_Amount, Limit_Persons, Code, [Image], [Percentage], ItemID)
VALUES
('Summer Sale', 'Big discounts on summer items', N'تخفيضات الصيف', N'خصومات كبيرة على مستلزمات الصيف', GETDATE(), DATEADD(DAY, 30, GETDATE()), 1000, 100, 'SUMMER20', 'summer.jpg', 20, 1),
('Winter Special', 'Winter collection at special prices', N'عروض الشتاء', N'مجموعة الشتاء بأسعار خاصة', GETDATE(), DATEADD(DAY, 60, GETDATE()), 500, 50, 'WINTER15', 'winter.jpg', 15, 2),
('New Year', 'Celebrate new year with discounts', N'السنة الجديدة', N'احتفل بالسنة الجديدة مع خصومات', GETDATE(), DATEADD(DAY, 90, GETDATE()), 750, 75, 'NEWYEAR25', 'newyear.jpg', 25, 3),
('Spring Collection', 'Fresh spring items', N'مجموعة الربيع', N'منتجات الربيع الطازجة', GETDATE(), DATEADD(DAY, 45, GETDATE()), 600, 60, 'SPRING10', 'spring.jpg', 10, 4),
('Back to School', 'Everything for school season', N'العودة إلى المدرسة', N'كل شيء لموسم المدرسة', GETDATE(), DATEADD(DAY, 30, GETDATE()), 300, 30, 'SCHOOL30', 'school.jpg', 30, 5);

-- Insert into Favorite
INSERT INTO Favorite (UserID, ItemID)
VALUES
(2, 1),
(2, 3),
(3, 2),
(4, 4),
(5, 5);

-- Insert into Chat
INSERT INTO Chat (UserID, DriverID, [Message], sender_type)
VALUES
(2, 3, 'When will my order arrive?', 'user'),
(3, 2, 'Your order will arrive in 30 minutes', 'delivery person'),
(2, 3, 'Thank you!', 'user'),
(4, 3, 'Is there any delay?', 'user'),
(3, 4, 'No, your order is on the way', 'delivery person');
