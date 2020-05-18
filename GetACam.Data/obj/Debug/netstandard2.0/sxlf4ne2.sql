IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Categorie] (
    [Id] int NOT NULL IDENTITY,
    CONSTRAINT [PK_Categorie] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [User] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [EmailAddress] nvarchar(max) NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Order] (
    [Id] int NOT NULL IDENTITY,
    [OrderDate] datetime2 NOT NULL,
    [ShippingAddress] nvarchar(max) NULL,
    [UserId] int NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Order_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [OrderItem] (
    [Id] int NOT NULL IDENTITY,
    [Quantity] int NOT NULL,
    [OrderId] int NULL,
    CONSTRAINT [PK_OrderItem] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_OrderItem_Order_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Order] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Product] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [Price] decimal(18,2) NOT NULL,
    [OrderItemId] int NULL,
    [CategoryId] int NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Product_Categorie_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categorie] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Product_OrderItem_OrderItemId] FOREIGN KEY ([OrderItemId]) REFERENCES [OrderItem] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Order_UserId] ON [Order] ([UserId]);

GO

CREATE INDEX [IX_OrderItem_OrderId] ON [OrderItem] ([OrderId]);

GO

CREATE INDEX [IX_Product_CategoryId] ON [Product] ([CategoryId]);

GO

CREATE INDEX [IX_Product_OrderItemId] ON [Product] ([OrderItemId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200427210643_init', N'3.1.3');

GO

