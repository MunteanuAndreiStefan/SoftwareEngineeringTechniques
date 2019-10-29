
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/28/2019 17:58:09
-- Generated from EDMX file: C:\Users\vpantelemon\source\repos\FakeNewsDetectionCache\FakeNewsDetectionCache.EntitiesDiagram\FakeNewsModel.edmx
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
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
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

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
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

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [User_Id] in table 'NewsArticles'
ALTER TABLE [dbo].[NewsArticles]
ADD CONSTRAINT [FK_NewsArticeUser]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
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