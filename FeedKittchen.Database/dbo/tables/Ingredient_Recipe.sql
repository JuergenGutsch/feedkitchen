CREATE TABLE [dbo].[Ingredient_Recipe]
(
    [Ingredient_Id] BIGINT NOT NULL,
    [Recipe_Id] BIGINT NOT NULL,
    CONSTRAINT [FK_Ingredient_Recipe_Ingredients] FOREIGN KEY ([Ingredient_Id]) REFERENCES [Ingredients]([Id]), 
    CONSTRAINT [FK_Ingredient_Recipe_Recipes] FOREIGN KEY (Recipe_Id) REFERENCES [Recipes]([Id]), 
    CONSTRAINT [PK_Ingredient_Recipe] PRIMARY KEY ([Ingredient_Id],[Recipe_Id])
)
