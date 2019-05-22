/*
Post-Deployment Script Template                            
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.        
 Use SQLCMD syntax to include a file in the post-deployment script.            
 Example:      :r .\myfile.sql                                
 Use SQLCMD syntax to reference a variable in the post-deployment script.        
 Example:      :setvar TableName MyTable                            
               SELECT * FROM [$(TableName)]                    
--------------------------------------------------------------------------------------
*/

DECLARE @Product AS TABLE
(
    [ProductId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Description] VARCHAR(100) NOT NULL DEFAULT '', 
    [Price] DECIMAL(19, 4) NOT NULL CHECK ([Price] >= 0), 
    [Shipping] DECIMAL(19, 4) NOT NULL CHECK ([Shipping] >= 0)
)

INSERT INTO @Product ([Name]
           ,[Description]
           ,[Price]
           ,[Shipping])
     VALUES
        ('ZOLPIDEM TARTRATE', 'zolpidem tartrate', 627.02, 5.43),
        ('GUNA-IL 12', 'INTERLEUKIN-12 HUMAN RECOMBINANT', 242.50, 7.35),
        ('COMMON MUGWORT POLLEN', 'artemisia vulgaris pollen', 4155.55, 5.91),
        ('Carbidopa, levodopa and entacapone', 'Carbidopa, levodopa and entacapone', 3971.82, 8.25),
        ('equate migraine relief', 'Acetaminophen, Aspirin, Caffeine', 958.14, 1.73),
        ('Quetiapine fumarate', 'Quetiapine fumarate', 4874.32, 0.92),
        ('Atovaquone and Proguanil Hydrochloride', 'atovaquone and proguanil hydrochloride', 352.79, 6.53),
        ('AMOXICILLIN', 'AMOXICILLIN', 4801.27, 5.17),
        ('KMS California Head Remedy Dandruff', 'PYRITHIONE ZINC', 457.97, 0.90),
        ('Fentanyl Citrate', 'Fentanyl Citrate', 4424.27, 0.72),
        ('pain relief', 'Acetaminophen', 4034.81, 9.82),
        ('Ibuprofen', 'Ibuprofen', 3088.41, 7.87),
        ('MonoNessa', 'norgestimate and ethinyl estradiol', 2836.75, 7.00),
        ('SENSORCAINE', 'BUPIVACAINE HYDROCHLORIDE', 1876.50, 5.00),
        ('Ferrum sidereum 21 Special Order', 'Ferrum sidereum 21 Special Order', 94.52, 9.97),
        ('Good Sense All Day Allergy D', 'Cetirizine HCl, Pseudoephedrine HCl', 221.06, 3.84),
        ('RUTIN', 'not applicable', 3587.19, 0.76),
        ('Sodium Chloride', 'Sodium Chloride', 4444.89, 4.79),
        ('Clonidine Hydrochloride', 'clonidine hydrochloride', 4313.57, 2.83),
        ('PLANTAGO LANCEOLATA POLLEN', 'Plantain English', 1220.06, 7.55),
        ('Claforan', 'cefotaxime sodium', 4638.76, 8.35),
        ('Strawberry', 'Strawberry', 874.57, 7.61),
        ('Risperidone', 'risperidone', 1019.99, 7.83),
        ('Budpak Muscle Rub', 'Menthol', 3576.16, 3.61),
        ('Medi-Cortisone', 'Hydrocortisone', 3577.71, 1.90),
        ('Metronidazole', 'Metronidazole', 4515.14, 4.25),
        ('PROPAFENONE HYDROCHLORIDE', 'propafenone hydrochloride', 1678.04, 1.66),
        ('Hazelnut', 'Hazelnut', 3539.61, 1.66),
        ('MORUS RUBRA POLLEN', 'Mulberry Red', 3251.30, 1.10),
        ('Lisinopril', 'Lisinopril', 1481.28, 5.99),
        ('Aplicare Povidone-iodine Scrub', 'Povidone-iodine', 4331.45, 9.71),
        ('Minocin', 'minocycline hydrochloride', 2822.67, 4.50),
        ('Bacitracin Zinc', 'Bacitracin Zinc', 3202.19, 0.27),
        ('Doxycycline', 'doxycycline', 3793.18, 9.08),
        ('OXYGEN', 'OXYGEN', 2177.16, 1.68),
        ('Cinryze', 'HUMAN C1-ESTERASE INHIBITOR', 2331.10, 0.64),
        ('Aller-chlor', 'Chlorpheniramine Maleate', 1262.58, 5.89),
        ('ALOE VESTA PROTECTIVE', 'PETROLATUM', 1258.01, 7.67)


INSERT INTO [dbo].[Product]
    SELECT [Name]
           ,[Description]
           ,[Price]
           ,[Shipping]
    FROM @Product

    EXCEPT
        SELECT [Name]
           ,[Description]
           ,[Price]
           ,[Shipping]
           FROM [dbo].[Product]
