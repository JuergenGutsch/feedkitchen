CREATE TABLE [dbo].[Ingredient_Menu]
(
    [Ingredient_Id] BIGINT NOT NULL,
    [Menu_Id] BIGINT NOT NULL,
    CONSTRAINT [FK_Ingredient_Menu_Ingredients] FOREIGN KEY ([Ingredient_Id]) REFERENCES [Ingredients]([Id]), 
    CONSTRAINT [FK_Ingredient_Menu_Menus] FOREIGN KEY ([Menu_Id]) REFERENCES [Menus]([Id]), 
    CONSTRAINT [PK_Ingredient_Menu] PRIMARY KEY ([Ingredient_Id], [Menu_Id])
)
