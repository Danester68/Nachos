using System;
using System.Collections.Generic;

[Serializable]
public class LevelSaves
{
    public List<LevelSave> saves;
    public LevelSave lastLevel;
}

[Serializable]
public class LevelSave
{
    public List<Object> objects;
    public List<Ingredient> ingredients;
}

[Serializable]
public class Object
{
    public ObjectType type;
    public float position;
}

[Serializable]
public class Ingredient : Object
{
    public new IngredientType type;
}

public enum ObjectType
{
    Tree,
    Bush,
    Oven
}

public enum IngredientType
{
    Cheese,
    Chip,
    Lettuce,
    Meat,
    Onion,
    Tomato
}