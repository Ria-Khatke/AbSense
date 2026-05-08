SET IDENTITY_INSERT [dbo].[Staff] ON

INSERT INTO [dbo].[Staff] ([StaffInfoId], [FirstName], [LastName], [Username], [Password], [AllowedLeaves], [StaffRole], [IsActive], [StaffType]) 
VALUES (1, N'Ria', N'Khatke', N'rk', N'123', 11, 1, 1, 0)

INSERT INTO [dbo].[Staff] ([StaffInfoId], [FirstName], [LastName], [Username], [Password], [AllowedLeaves], [StaffRole], [IsActive], [StaffType]) 
VALUES (2, N'John', N'Smith', N'js', N'345', 14, 2, 1, 0)

INSERT INTO [dbo].[Staff] ([StaffInfoId], [FirstName], [LastName], [Username], [Password], [AllowedLeaves], [StaffRole], [IsActive], [StaffType]) 
VALUES (7, N'Martha', N'Wavehover', N'mw', N'567', 11, 3, 1, 0)

INSERT INTO [dbo].[Staff] ([StaffInfoId], [FirstName], [LastName], [Username], [Password], [AllowedLeaves], [StaffRole], [IsActive], [StaffType]) 
VALUES (9, N'Ben', N'Gigglepops', N'bg', N'789', 11, 4, 1, 0)

SET IDENTITY_INSERT [dbo].[Staff] OFF

-- Delete the NULL row from Staff table
DELETE FROM Staff 
WHERE StaffInfoId IS NULL 
   OR (FirstName IS NULL AND LastName IS NULL AND Username IS NULL);