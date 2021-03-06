DECLARE @CurrentMigration [nvarchar](max)

IF object_id('[dbo].[__MigrationHistory]') IS NOT NULL
    SELECT @CurrentMigration =
        (SELECT TOP (1) 
        [Project1].[MigrationId] AS [MigrationId]
        FROM ( SELECT 
        [Extent1].[MigrationId] AS [MigrationId]
        FROM [dbo].[__MigrationHistory] AS [Extent1]
        WHERE [Extent1].[ContextKey] = N'CsvWebParser.Migrations.Configuration'
        )  AS [Project1]
        ORDER BY [Project1].[MigrationId] DESC)

IF @CurrentMigration IS NULL
    SET @CurrentMigration = '0'

IF @CurrentMigration < '202107050014193_InitialSetup'
BEGIN
    CREATE TABLE [dbo].[tblProduct] (
        [AsIdn] [nvarchar](20) NOT NULL,
        [Title] [nvarchar](100),
        [Price] [decimal](18, 2) NOT NULL,
        [NetMargin] [float] NOT NULL,
        CONSTRAINT [PK_dbo.tblProduct] PRIMARY KEY ([AsIdn])
    )
    CREATE TABLE [dbo].[__MigrationHistory] (
        [MigrationId] [nvarchar](150) NOT NULL,
        [ContextKey] [nvarchar](300) NOT NULL,
        [Model] [varbinary](max) NOT NULL,
        [ProductVersion] [nvarchar](32) NOT NULL,
        CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
    )
    INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
    VALUES (N'202107050014193_InitialSetup', N'CsvWebParser.Migrations.Configuration',  0x1F8B0800000000000400CD57DB6EDB38107D5FA0FF20E839356DF7A50DE416A99D2C82D68951A5DD675A1A294479D19294617FDB3EEC27ED2FEC48A22EA61DD7E905BBC84B349C3933733817FA9FBFFE8EDE6D050F36A00D5372164E46E3300099A894C97C1696367BF93A7CF7F6C56FD1752AB6C19756EF55A58796D2CCC2476B8B4B424CF208829A9160895646657694284168AAC8743C7E432613020811225610449F4A699980FA033FE74A2650D892F2A54A811B27C793B8460DEEA80053D00466E1DC6CFE80F58A6A037AD4A887C1156714438981676140A554965A0CF4F2B381D86A25F3B84001E50FBB02502FA3DC804BE0B2573F3797F1B4CA85F4862D54521AABC4330127AF1C39C437FF2E8AC38E3CA4EF1A69B6BB2AEB9AC259B8D22A2D131B06BEAFCB39D795DE518247CEEC22181E5E74F5806553FDE171C96DA96126A1B49AF28B6055AE394B3EC0EE417D05399325E7C30031443CDB13A008BD15A0EDEE13642EEC2B739B221D64DF94F8B69DE5BE59931716021675182CE9F623C8DC3ECEC22956F10DDB42DA0A5C617C960C5B006DAC2EF1F30EA3A66B0EDD3939E9F581590E27BC4EC6E7B93DED65A559D2795940C204E561B0D2F89FEBE5D7611027B40A7BFAEC1CEEC02EA9CE59C7DE42E14D7E8B8B88F405775886D8E59632097ABF164D2587EDB19AC4F67565691C29FB4137B831580F310CFA389AA930EA0AFF58BC5D64FDE021CDE4692714796244454B5A1478C18391E52441ECE6D5CBF8F97D2C1A0C929823EDDC45DB79B24AD31CBC53748D91DE306DEC825ABAA6D56DCD5371A0E6DFC3131CB7DE3CAAFDE6ED996F0DAAFF1BA313A3C5C7E989BCC1DC04485BA7095D38FD2C3BB0ACF706E5541F1F0773C54B214F0C965318AEB987184E743E866BDD2186139D8F3168D021CE407C8815118F52FFEEC8C1E57903D72F8653BDE4AB74DEBB9EF27A2772757CC61BC02FEC46A51A7F6AC3D2AAA8E39DB1204695C228FE93CF39C37C7B8525952C03639BB5848B6032F55E11FF9F8D4E8C49F9796BFD3F5AAD724375F248F5C172FD91CD7914B4DE9D3DEAB31765FACB1765C615B53F754F1E8EF1B3B6E0A925D8F40BD2B15618B7E372CD7F74491E367044864FFD680186E53D44F5F09790549DD183B63AB732532DD998DC30A256C5BB8B25589A224757DAB28C26168F1330A67E7F7DA1BC44956BB186F456DE97B628ED953120D67C37CC3722A7FDD72F81FD98A3FBA2FA323F23050C93610A702FDF978CA75DDC37478AE80988AA5C7E0794D71307DF9F0897EF3AA43B25CF0472F42DA00099E2F47C0051700433F732A61BF89ED8F041F711729AECDA39FC34C8B72F629FF668C168AEA9300EA3B7AF7EBE92EAF7EBDB7F01D9F00045F10E0000 , N'6.4.4')
END

