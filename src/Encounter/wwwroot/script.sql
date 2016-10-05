USE [Encounter]
GO
SET IDENTITY_INSERT [dbo].[Characters] ON 

INSERT [dbo].[Characters] ([CharacterId], [Name], [SpriteUrl], [Health]) VALUES (1, N'Alfonse', N'/img/testchar.svg', 20)
INSERT [dbo].[Characters] ([CharacterId], [Name], [SpriteUrl], [Health]) VALUES (2, N'Branson', N'/img/testchar.svg', 20)
INSERT [dbo].[Characters] ([CharacterId], [Name], [SpriteUrl], [Health]) VALUES (3, N'Clementine', N'/img/testchar.svg', 20)
INSERT [dbo].[Characters] ([CharacterId], [Name], [SpriteUrl], [Health]) VALUES (4, N'Drew', N'/img/testchar.svg', 20)
SET IDENTITY_INSERT [dbo].[Characters] OFF
SET IDENTITY_INSERT [dbo].[Games] ON 

INSERT [dbo].[Games] ([GameId], [CharacterId], [DateCreated], [UserId]) VALUES (1, 4, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Games] ([GameId], [CharacterId], [DateCreated], [UserId]) VALUES (2, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Games] ([GameId], [CharacterId], [DateCreated], [UserId]) VALUES (3, 3, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Games] ([GameId], [CharacterId], [DateCreated], [UserId]) VALUES (4, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Games] ([GameId], [CharacterId], [DateCreated], [UserId]) VALUES (5, 4, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Games] ([GameId], [CharacterId], [DateCreated], [UserId]) VALUES (6, 4, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Games] ([GameId], [CharacterId], [DateCreated], [UserId]) VALUES (7, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Games] ([GameId], [CharacterId], [DateCreated], [UserId]) VALUES (8, 4, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Games] ([GameId], [CharacterId], [DateCreated], [UserId]) VALUES (9, 2, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Games] ([GameId], [CharacterId], [DateCreated], [UserId]) VALUES (10, 2, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Games] ([GameId], [CharacterId], [DateCreated], [UserId]) VALUES (11, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Games] ([GameId], [CharacterId], [DateCreated], [UserId]) VALUES (12, 3, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Games] ([GameId], [CharacterId], [DateCreated], [UserId]) VALUES (13, 2, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Games] ([GameId], [CharacterId], [DateCreated], [UserId]) VALUES (14, 4, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Games] ([GameId], [CharacterId], [DateCreated], [UserId]) VALUES (15, 3, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Games] ([GameId], [CharacterId], [DateCreated], [UserId]) VALUES (16, 2, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Games] ([GameId], [CharacterId], [DateCreated], [UserId]) VALUES (17, 2, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Games] ([GameId], [CharacterId], [DateCreated], [UserId]) VALUES (18, 2, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Games] ([GameId], [CharacterId], [DateCreated], [UserId]) VALUES (1018, 3, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Games] ([GameId], [CharacterId], [DateCreated], [UserId]) VALUES (2018, 3, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Games] ([GameId], [CharacterId], [DateCreated], [UserId]) VALUES (2019, 4, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Games] ([GameId], [CharacterId], [DateCreated], [UserId]) VALUES (2020, 2, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[Games] OFF
SET IDENTITY_INSERT [dbo].[Events] ON 

INSERT [dbo].[Events] ([EventId], [GameId], [ImageUrl], [Name]) VALUES (1, NULL, N'none', N'Forest')
INSERT [dbo].[Events] ([EventId], [GameId], [ImageUrl], [Name]) VALUES (2, NULL, N'none', N'Mountains')
SET IDENTITY_INSERT [dbo].[Events] OFF
SET IDENTITY_INSERT [dbo].[Foes] ON 

INSERT [dbo].[Foes] ([FoeId], [EventId], [Health], [Name], [SpriteUrl]) VALUES (3, 1, 20, N'Gnoll', N'none')
INSERT [dbo].[Foes] ([FoeId], [EventId], [Health], [Name], [SpriteUrl]) VALUES (4, 2, 10, N'Goblin', N'none')
SET IDENTITY_INSERT [dbo].[Foes] OFF
SET IDENTITY_INSERT [dbo].[Abilities] ON 

INSERT [dbo].[Abilities] ([AbilityId], [CharacterId], [Name], [CharHarm], [CharHeal], [FoeHarm], [FoeHeal], [FoeId]) VALUES (1, 1, N'Attack', 0, 0, 0, 0, NULL)
INSERT [dbo].[Abilities] ([AbilityId], [CharacterId], [Name], [CharHarm], [CharHeal], [FoeHarm], [FoeHeal], [FoeId]) VALUES (2, 2, N'Defend', 0, 0, 0, 0, NULL)
INSERT [dbo].[Abilities] ([AbilityId], [CharacterId], [Name], [CharHarm], [CharHeal], [FoeHarm], [FoeHeal], [FoeId]) VALUES (3, 3, N'Kick', 0, 0, 0, 0, NULL)
INSERT [dbo].[Abilities] ([AbilityId], [CharacterId], [Name], [CharHarm], [CharHeal], [FoeHarm], [FoeHeal], [FoeId]) VALUES (4, 4, N'Pray', 0, 0, 0, 0, NULL)
INSERT [dbo].[Abilities] ([AbilityId], [CharacterId], [Name], [CharHarm], [CharHeal], [FoeHarm], [FoeHeal], [FoeId]) VALUES (5, 1, N'Shout', 0, 0, 0, 0, NULL)
INSERT [dbo].[Abilities] ([AbilityId], [CharacterId], [Name], [CharHarm], [CharHeal], [FoeHarm], [FoeHeal], [FoeId]) VALUES (6, 2, N'Shove', 0, 0, 0, 0, NULL)
INSERT [dbo].[Abilities] ([AbilityId], [CharacterId], [Name], [CharHarm], [CharHeal], [FoeHarm], [FoeHeal], [FoeId]) VALUES (7, 3, N'Total Mess', 1, 2, 5, 2, 3)
INSERT [dbo].[Abilities] ([AbilityId], [CharacterId], [Name], [CharHarm], [CharHeal], [FoeHarm], [FoeHeal], [FoeId]) VALUES (8, 4, N'Power Up', 0, 10, 0, 10, 4)
SET IDENTITY_INSERT [dbo].[Abilities] OFF
SET IDENTITY_INSERT [dbo].[Players] ON 

INSERT [dbo].[Players] ([PlayerId], [GameInstanceGameId], [Name], [Created], [UserId]) VALUES (1, 17, N'Natsu', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Players] ([PlayerId], [GameInstanceGameId], [Name], [Created], [UserId]) VALUES (2, 7, N'Gray', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Players] ([PlayerId], [GameInstanceGameId], [Name], [Created], [UserId]) VALUES (3, 14, N'Erza', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Players] ([PlayerId], [GameInstanceGameId], [Name], [Created], [UserId]) VALUES (4, 13, N'Lucy', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Players] ([PlayerId], [GameInstanceGameId], [Name], [Created], [UserId]) VALUES (5, 2020, N'Yakul', CAST(N'2016-09-25T11:59:22.6650673' AS DateTime2), NULL)
INSERT [dbo].[Players] ([PlayerId], [GameInstanceGameId], [Name], [Created], [UserId]) VALUES (6, 2018, N'Richard', CAST(N'2016-09-25T13:33:23.4079727' AS DateTime2), NULL)
INSERT [dbo].[Players] ([PlayerId], [GameInstanceGameId], [Name], [Created], [UserId]) VALUES (7, NULL, N'Authorized Profile', CAST(N'2016-09-28T14:30:46.3606098' AS DateTime2), N'e6bfb9ec-c3d5-4fce-9bbd-707517cde585')
INSERT [dbo].[Players] ([PlayerId], [GameInstanceGameId], [Name], [Created], [UserId]) VALUES (8, NULL, N'Authorized2', CAST(N'2016-09-28T14:51:35.1599212' AS DateTime2), N'e6bfb9ec-c3d5-4fce-9bbd-707517cde585')
INSERT [dbo].[Players] ([PlayerId], [GameInstanceGameId], [Name], [Created], [UserId]) VALUES (1008, NULL, N'This is the place!', CAST(N'2016-09-28T15:06:21.0865696' AS DateTime2), N'b97fbafc-a58c-4615-8c82-6fc494d422be')
SET IDENTITY_INSERT [dbo].[Players] OFF
