
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/05/2021 15:24:10
-- Generated from EDMX file: D:\Эдик\Программирование (Обучение)\с#\EntityTest\GroceryStore\GroceryStoreModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [GroceryStoreDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ProductSet'
CREATE TABLE [dbo].[ProductSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Price] int  NOT NULL
);
GO

-- Creating table 'StoregeSet'
CREATE TABLE [dbo].[StoregeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Count] int  NOT NULL,
    [Warehouse_Id] int  NOT NULL,
    [Product_Id] int  NOT NULL
);
GO

-- Creating table 'WarehouseSet'
CREATE TABLE [dbo].[WarehouseSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ProductSet'
ALTER TABLE [dbo].[ProductSet]
ADD CONSTRAINT [PK_ProductSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StoregeSet'
ALTER TABLE [dbo].[StoregeSet]
ADD CONSTRAINT [PK_StoregeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WarehouseSet'
ALTER TABLE [dbo].[WarehouseSet]
ADD CONSTRAINT [PK_WarehouseSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Warehouse_Id] in table 'StoregeSet'
ALTER TABLE [dbo].[StoregeSet]
ADD CONSTRAINT [FK_WarehouseStorege]
    FOREIGN KEY ([Warehouse_Id])
    REFERENCES [dbo].[WarehouseSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WarehouseStorege'
CREATE INDEX [IX_FK_WarehouseStorege]
ON [dbo].[StoregeSet]
    ([Warehouse_Id]);
GO

-- Creating foreign key on [Product_Id] in table 'StoregeSet'
ALTER TABLE [dbo].[StoregeSet]
ADD CONSTRAINT [FK_ProductStorege]
    FOREIGN KEY ([Product_Id])
    REFERENCES [dbo].[ProductSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductStorege'
CREATE INDEX [IX_FK_ProductStorege]
ON [dbo].[StoregeSet]
    ([Product_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------