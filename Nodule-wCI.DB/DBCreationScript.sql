-- Script Date: 3/7/2013 11:56 πμ  - ErikEJ.SqlCeScripting version 3.5.2.30
-- Database information:
-- Locale Identifier: 1033
-- Encryption Mode: 
-- Case Sensitive: False
-- Database: C:\---Work---\EPU\webinos\Nodule-wCI\Nodule-wCI.DB\NoduleDb.sdf
-- ServerVersion: 4.0.8876.1
-- DatabaseSize: 151552
-- Created: 29/6/2013 2:33 μμ

-- User Table information:
-- Number of tables: 4
-- Commits: 0 row(s)
-- PostStatuses: 4 row(s)
-- WebHookPostCommits: 0 row(s)
-- WebHookPosts: 0 row(s)

CREATE TABLE [PostStatuses] (
  [Id] tinyint NOT NULL
, [Description] nvarchar(100) NOT NULL
);
GO
CREATE TABLE [WebHookPosts] (
  [Id] bigint NOT NULL  IDENTITY (1,1)
, [Date] datetime NOT NULL
, [PostData] ntext NULL
, [StatusId] tinyint NOT NULL
, [RepoUrl] nvarchar(500) NULL
, [PullRequestReference] nvarchar(500) NULL
, [Result] ntext NULL
);
GO
CREATE TABLE [Commits] (
  [Id] nvarchar(100) NOT NULL
, [Email] nvarchar(255) NULL
, [Name] nvarchar(500) NULL
, [Username] nvarchar(500) NULL
, [ModifiedNo] int NOT NULL
, [AddedNo] int NOT NULL
, [DeletedNo] int NOT NULL
, [Date] datetime NOT NULL
, [Url] nvarchar(1000) NOT NULL
, [Message] ntext NOT NULL
);
GO
CREATE TABLE [WebHookPostCommits] (
  [WebHookPostId] bigint NOT NULL
, [CommitId] nvarchar(100) NOT NULL
, [Order] int NOT NULL
);
GO
ALTER TABLE [PostStatuses] ADD CONSTRAINT [PK_PostStatuses] PRIMARY KEY ([Id]);
GO
ALTER TABLE [WebHookPosts] ADD CONSTRAINT [PK_WebHookPosts] PRIMARY KEY ([Id]);
GO
ALTER TABLE [Commits] ADD CONSTRAINT [PK_Commits] PRIMARY KEY ([Id]);
GO
ALTER TABLE [WebHookPostCommits] ADD CONSTRAINT [PK__WebHookPostCommits__0000000000000058] PRIMARY KEY ([WebHookPostId],[CommitId]);
GO
CREATE UNIQUE INDEX [UQ__WebHookPosts__0000000000000012] ON [WebHookPosts] ([Id] ASC);
GO
ALTER TABLE [WebHookPosts] ADD CONSTRAINT [FK_PostStatuses] FOREIGN KEY ([StatusId]) REFERENCES [PostStatuses]([Id]) ON DELETE CASCADE ON UPDATE CASCADE;
GO
ALTER TABLE [WebHookPostCommits] ADD CONSTRAINT [FK_Commit] FOREIGN KEY ([CommitId]) REFERENCES [Commits]([Id]) ON DELETE CASCADE ON UPDATE CASCADE;
GO
ALTER TABLE [WebHookPostCommits] ADD CONSTRAINT [FK_WebHookPosts] FOREIGN KEY ([WebHookPostId]) REFERENCES [WebHookPosts]([Id]) ON DELETE CASCADE ON UPDATE CASCADE;
GO

