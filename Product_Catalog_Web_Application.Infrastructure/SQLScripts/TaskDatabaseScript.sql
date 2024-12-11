BEGIN TRANSACTION;
GO

CREATE TABLE [Categories] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241210163233_Add-CategoriesTable', N'8.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Admins] (
    [Id] int NOT NULL IDENTITY,
    [ApplicationUserId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_Admins] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Admins_AspNetUsers_ApplicationUserId] FOREIGN KEY ([ApplicationUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Products] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [CreationDate] date NOT NULL,
    [StartDate] date NOT NULL,
    [Duration] int NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    [CreatedByUserId] int NOT NULL,
    [CategoryId] int NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Products_Admins_CreatedByUserId] FOREIGN KEY ([CreatedByUserId]) REFERENCES [Admins] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Admins_ApplicationUserId] ON [Admins] ([ApplicationUserId]);
GO

CREATE INDEX [IX_Products_CategoryId] ON [Products] ([CategoryId]);
GO

CREATE INDEX [IX_Products_CreatedByUserId] ON [Products] ([CreatedByUserId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241210171116_Add-ProductsTable', N'8.0.0');
GO

COMMIT;
GO

