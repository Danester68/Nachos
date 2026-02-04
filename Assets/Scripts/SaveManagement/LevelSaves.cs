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
}

[Serializable]
public class Object
{
    public ObjectType type;
    public float position;
}

public enum ObjectType
{
    Tree,
    Bush,
    Oven
}