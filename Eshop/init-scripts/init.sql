    create table "catalog"(
        "id" serial PRIMARY KEY,
        "name" varchar(500) not null,
        "price" money not null,
        "type" smallint not null,
        "description" varchar(500) not null
    );

    create table "stock"(
        "id" int not null,
        "amount" int not null
    );

    insert into "catalog"("id", "name", "price", "type", "description")
    values 
        (1, 'IPhone 16 Pro ultimate HD quadro maximum', 155499, 1, 'the best of the best of the best'),
        (2, 'Xiaomi iphone killer [assasinnator] 512mp', 70999, 1, ''),
        (3, 'Dexp phone GG340', 1699, 1, '1mb/512kb 3", 0,3mp'),
        (4, 'Samsung Galaxy Universe MilkyWay Dominator Keller Terron', 124599, 1,''),
        (5, 'End of Ideas product1', 599, 1, 'some product'),
        (6, 'End of Ideas product2', 699, 1, 'some product'),
        (7, 'End of Ideas product3', 799, 1, 'some product'),
        (8, 'Update Android to version 1.2.1.45.85.1.9.7.33', 1000, 2, ''),
        (9, 'Extra warranty 120 years', 3000, 2, ''),
        (10, 'Watch in your eyes', 100, 2, ''),
        (11, 'Take the C# course', 200, 2, 'priceless');

    insert into "stock"("id", "amount")
    values
        (1, 3),
        (2, 5),
        (3, 5),
        (4, 5),
        (5, 5),
        (6, 10),
        (7, 10);