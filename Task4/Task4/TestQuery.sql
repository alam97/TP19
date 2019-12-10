SELECT * FROM dbo.Person;
SELECT * FROM dbo.Event;
SELECT * FROM dbo.Product;
SELECT * FROM dbo.Inventory;

DELETE FROM dbo.Event
WHERE Id >= 0;

DELETE FROM dbo.Person
WHERE dbo.Person.FirstName ='Aleksander';

DELETE FROM dbo.Inventory
WHERE Id >= 0;

DELETE FROM Product
WHERE Name = 'Sword';

COMMIT;

