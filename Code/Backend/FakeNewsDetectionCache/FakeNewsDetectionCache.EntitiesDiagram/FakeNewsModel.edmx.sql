
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/12/2019 18:10:57
-- Generated from EDMX file: C:\Users\maste\Desktop\SoftwareEngineeringTechniques\Backend\FakeNewsDetectionCache\FakeNewsDetectionCache.EntitiesDiagram\FakeNewsModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [FakeNewsDetectionCache];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_NewsArticeUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NewsArticles] DROP CONSTRAINT [FK_NewsArticeUser];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[NewsArticles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NewsArticles];
GO
IF OBJECT_ID(N'[dbo].[TwitterUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TwitterUsers];
GO
IF OBJECT_ID(N'[dbo].[ApplicationUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ApplicationUsers];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'NewsArticles'
CREATE TABLE [dbo].[NewsArticles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Source] nvarchar(max)  NOT NULL,
    [CredibilityScore] int  NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'TwitterUsers'
CREATE TABLE [dbo].[TwitterUsers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [CredibilityScore] int  NULL
);
GO

-- Creating table 'ApplicationUsers'
CREATE TABLE [dbo].[ApplicationUsers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [CredibilityScore] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'NewsArticles'
ALTER TABLE [dbo].[NewsArticles]
ADD CONSTRAINT [PK_NewsArticles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TwitterUsers'
ALTER TABLE [dbo].[TwitterUsers]
ADD CONSTRAINT [PK_TwitterUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ApplicationUsers'
ALTER TABLE [dbo].[ApplicationUsers]
ADD CONSTRAINT [PK_ApplicationUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [User_Id] in table 'NewsArticles'
ALTER TABLE [dbo].[NewsArticles]
ADD CONSTRAINT [FK_NewsArticeUser]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[TwitterUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NewsArticeUser'
CREATE INDEX [IX_FK_NewsArticeUser]
ON [dbo].[NewsArticles]
    ([User_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------