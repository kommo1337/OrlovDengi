
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/09/2024 22:16:58
-- Generated from EDMX file: C:\Users\kommo\Desktop\OrlovKursovaya\OrlovKursovaya\DataFolder\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Orlov];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Client_Remont]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Client] DROP CONSTRAINT [FK_Client_Remont];
GO
IF OBJECT_ID(N'[dbo].[FK_Oborudovanie_Type]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Oborudovanie] DROP CONSTRAINT [FK_Oborudovanie_Type];
GO
IF OBJECT_ID(N'[dbo].[FK_Remont_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Remont] DROP CONSTRAINT [FK_Remont_Employee];
GO
IF OBJECT_ID(N'[dbo].[FK_Remont_Oborudovanie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Remont] DROP CONSTRAINT [FK_Remont_Oborudovanie];
GO
IF OBJECT_ID(N'[dbo].[FK_User_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_Role];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Client]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Client];
GO
IF OBJECT_ID(N'[dbo].[Employee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employee];
GO
IF OBJECT_ID(N'[dbo].[Oborudovanie]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Oborudovanie];
GO
IF OBJECT_ID(N'[dbo].[Remont]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Remont];
GO
IF OBJECT_ID(N'[dbo].[Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Type]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Type];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Client'
CREATE TABLE [dbo].[Client] (
    [ClientId] int IDENTITY(1,1) NOT NULL,
    [FIO] nvarchar(50)  NOT NULL,
    [ClientPassport] int  NOT NULL,
    [ClientAdress] nvarchar(max)  NOT NULL,
    [ClientDateOfBirth] datetime  NOT NULL,
    [PhoneNumber] nvarchar(50)  NOT NULL,
    [Email] nvarchar(50)  NOT NULL,
    [RemontId] int  NOT NULL
);
GO

-- Creating table 'Employee'
CREATE TABLE [dbo].[Employee] (
    [EmployeeId] int IDENTITY(1,1) NOT NULL,
    [FIO] nvarchar(max)  NOT NULL,
    [PhoneNumber] nvarchar(50)  NOT NULL,
    [DateOfBirth] datetime  NOT NULL,
    [Email] nvarchar(50)  NOT NULL,
    [Passport] int  NOT NULL,
    [Adress] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Oborudovanie'
CREATE TABLE [dbo].[Oborudovanie] (
    [OborudovanieId] int IDENTITY(1,1) NOT NULL,
    [OborudovanieName] nvarchar(50)  NOT NULL,
    [OborudovanieCount] nvarchar(50)  NOT NULL,
    [OborudovanieDescription] nvarchar(max)  NOT NULL,
    [TypeId] int  NOT NULL,
    [Price] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Remont'
CREATE TABLE [dbo].[Remont] (
    [RemontId] int IDENTITY(1,1) NOT NULL,
    [RemontDate] datetime  NOT NULL,
    [RemontPrice] decimal(10,2)  NOT NULL,
    [OborudovanieId] int  NOT NULL,
    [EmployeeId] int  NOT NULL
);
GO

-- Creating table 'Role'
CREATE TABLE [dbo].[Role] (
    [RoleId] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Type'
CREATE TABLE [dbo].[Type] (
    [TypeId] int IDENTITY(1,1) NOT NULL,
    [TypeName] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(50)  NOT NULL,
    [UserPassword] nvarchar(50)  NOT NULL,
    [RoleId] int  NOT NULL,
    [FIO] nvarchar(50)  NOT NULL,
    [PhoneNumber] nvarchar(50)  NOT NULL,
    [Email] nvarchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ClientId] in table 'Client'
ALTER TABLE [dbo].[Client]
ADD CONSTRAINT [PK_Client]
    PRIMARY KEY CLUSTERED ([ClientId] ASC);
GO

-- Creating primary key on [EmployeeId] in table 'Employee'
ALTER TABLE [dbo].[Employee]
ADD CONSTRAINT [PK_Employee]
    PRIMARY KEY CLUSTERED ([EmployeeId] ASC);
GO

-- Creating primary key on [OborudovanieId] in table 'Oborudovanie'
ALTER TABLE [dbo].[Oborudovanie]
ADD CONSTRAINT [PK_Oborudovanie]
    PRIMARY KEY CLUSTERED ([OborudovanieId] ASC);
GO

-- Creating primary key on [RemontId] in table 'Remont'
ALTER TABLE [dbo].[Remont]
ADD CONSTRAINT [PK_Remont]
    PRIMARY KEY CLUSTERED ([RemontId] ASC);
GO

-- Creating primary key on [RoleId] in table 'Role'
ALTER TABLE [dbo].[Role]
ADD CONSTRAINT [PK_Role]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [TypeId] in table 'Type'
ALTER TABLE [dbo].[Type]
ADD CONSTRAINT [PK_Type]
    PRIMARY KEY CLUSTERED ([TypeId] ASC);
GO

-- Creating primary key on [UserId] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [RemontId] in table 'Client'
ALTER TABLE [dbo].[Client]
ADD CONSTRAINT [FK_Client_Remont]
    FOREIGN KEY ([RemontId])
    REFERENCES [dbo].[Remont]
        ([RemontId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Client_Remont'
CREATE INDEX [IX_FK_Client_Remont]
ON [dbo].[Client]
    ([RemontId]);
GO

-- Creating foreign key on [EmployeeId] in table 'Remont'
ALTER TABLE [dbo].[Remont]
ADD CONSTRAINT [FK_Remont_Employee]
    FOREIGN KEY ([EmployeeId])
    REFERENCES [dbo].[Employee]
        ([EmployeeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Remont_Employee'
CREATE INDEX [IX_FK_Remont_Employee]
ON [dbo].[Remont]
    ([EmployeeId]);
GO

-- Creating foreign key on [TypeId] in table 'Oborudovanie'
ALTER TABLE [dbo].[Oborudovanie]
ADD CONSTRAINT [FK_Oborudovanie_Type]
    FOREIGN KEY ([TypeId])
    REFERENCES [dbo].[Type]
        ([TypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Oborudovanie_Type'
CREATE INDEX [IX_FK_Oborudovanie_Type]
ON [dbo].[Oborudovanie]
    ([TypeId]);
GO

-- Creating foreign key on [OborudovanieId] in table 'Remont'
ALTER TABLE [dbo].[Remont]
ADD CONSTRAINT [FK_Remont_Oborudovanie]
    FOREIGN KEY ([OborudovanieId])
    REFERENCES [dbo].[Oborudovanie]
        ([OborudovanieId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Remont_Oborudovanie'
CREATE INDEX [IX_FK_Remont_Oborudovanie]
ON [dbo].[Remont]
    ([OborudovanieId]);
GO

-- Creating foreign key on [RoleId] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [FK_User_Role]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[Role]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User_Role'
CREATE INDEX [IX_FK_User_Role]
ON [dbo].[User]
    ([RoleId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------