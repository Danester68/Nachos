using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadLevel : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] GameObject levelGameObject;
    [SerializeField] GameObject treeGameObject;
    [SerializeField] GameObject bushGameObject;
    [SerializeField] GameObject ovenGameObject;
    [SerializeField] GameObject chipGameObject;
    [SerializeField] GameObject tomatoGameObject;
    [SerializeField] GameObject onionGameObject;
    [SerializeField] GameObject meatGameObject;
    [SerializeField] GameObject cheeseGameObject;
    [SerializeField] GameObject lettuceGameObject;

    [SerializeField] Button saveLevelButton;

    [SerializeField] float ingredientRange;
    string savePath;
    string saveFileName = "levelSaves.json";
    string filePath;
    void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "Data");
        filePath = Path.Combine(savePath, saveFileName);
        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
        }
        if (!File.Exists(filePath))
        {
            LevelSaves emptyLevelSave = new();
            string jsonContent = JsonUtility.ToJson(emptyLevelSave);
            using (StreamWriter streamWriter = File.CreateText(filePath))
            {
                streamWriter.WriteLine(jsonContent);
            }
        }
    }

    void Update()
    {
        LevelSaves levelSaves = GetLevelSaves();
        saveLevelButton.interactable = (levelSaves.saves.Count >= 5) ? false : true;
    }

    public LevelSaves GetLevelSaves()
    {
        string jsonContent;
        using (StreamReader streamReader = new(filePath))
        {
            jsonContent = streamReader.ReadToEnd();
        }
        LevelSaves levelSaves = JsonUtility.FromJson<LevelSaves>(jsonContent);
        return levelSaves;
    }

    public void SaveLevel()
    {
        Debug.Log("Saving new level in file " + filePath);
        LevelSaves levelSaves = GetLevelSaves();
        if (levelSaves.saves.Count >= 5)
        {
            throw new IndexOutOfRangeException("Cannot save level: No slots available");
        }
        LevelSave levelSave = new();
        GameObject[] trees = GameObject.FindGameObjectsWithTag("Tree");
        GameObject[] bushes = GameObject.FindGameObjectsWithTag("Bush");
        GameObject oven = GameObject.FindGameObjectWithTag("Oven");
        List<Object> objects = new();
        foreach (GameObject tree in trees)
        {
            Object treeObject = new();
            treeObject.type = ObjectType.Tree;
            treeObject.position = tree.transform.position.x;
            objects.Add(treeObject);
        }
        foreach (GameObject bush in bushes)
        {
            Object bushObject = new();
            bushObject.type = ObjectType.Bush;
            bushObject.position = bush.transform.position.x;
            objects.Add(bushObject);
        }
        Object ovenObject = new();
        ovenObject.type = ObjectType.Oven;
        ovenObject.position = oven.transform.position.x;
        objects.Add(ovenObject);
        levelSave.objects = objects;
        levelSaves.saves.Add(levelSave);
        string jsonContent = JsonUtility.ToJson(levelSaves);
        using (StreamWriter streamWriter = File.CreateText(filePath))
        {
            streamWriter.WriteLine(jsonContent);
        }
        Debug.Log("Succeeded at saving level");
    }

    public void LoadLevel(int level)
    {
        Debug.Log("Loading level " + level + " from file " + filePath);
        player.position = new Vector3(player.position.x, 4.59f, player.position.z);
        for (int i = 0; i < levelGameObject.transform.childCount; i++)
        {
            Destroy(levelGameObject.transform.GetChild(i).gameObject);
        }
        string jsonContent;
        using (StreamReader streamReader = new(filePath))
        {
            jsonContent = streamReader.ReadToEnd();
        }
        LevelSave levelSave = JsonUtility.FromJson<LevelSaves>(jsonContent).saves[level];
        List<Object> objects = levelSave.objects;
        for (int i = 0; i < objects.Count; i++)
        {
            Object levelObject = objects[i];
            bool ovenExists = false;
            switch (levelObject.type)
            {
                case ObjectType.Tree:
                    GameObject tree = Instantiate(treeGameObject, new Vector3(levelObject.position, -1.3f, 0), new Quaternion());
                    tree.name = "Tree_" + i;
                    tree.transform.SetParent(levelGameObject.transform);
                    break;
                case ObjectType.Bush:
                    GameObject bush = Instantiate(bushGameObject, new Vector3(levelObject.position, -3f, 0), new Quaternion());
                    bush.name = "Bush_" + i;
                    bush.transform.SetParent(levelGameObject.transform);
                    break;
                case ObjectType.Oven:
                    GameObject oven = Instantiate(ovenGameObject, new Vector3(levelObject.position, -3f,-1), new Quaternion());
                    oven.name = "Oven";
                    oven.transform.SetParent(levelGameObject.transform);
                    ovenExists = true;
                    break;
                default:
                    throw new IncorrectFileStructureException("Invalid object type. Object: " + i + ", Level: " + level);
            }
            if (!ovenExists)
            {
                throw new IncorrectFileStructureException("No oven in level. Level: " + level);
            }
        }
        // Ingredients are not yet stored in saves, remove this code chunk once feature is implemented
        GameObject chip = Instantiate(chipGameObject, new Vector3(UnityEngine.Random.Range(-ingredientRange, ingredientRange), -3f, -1), new Quaternion());
        chip.name = "Chip";
        chip.transform.SetParent(levelGameObject.transform);
        GameObject tomato = Instantiate(tomatoGameObject, new Vector3(UnityEngine.Random.Range(-ingredientRange, ingredientRange), -3f,-1), new Quaternion());
        tomato.name = "Tomato";
        tomato.transform.SetParent(levelGameObject.transform);
        GameObject onion = Instantiate(onionGameObject, new Vector3(UnityEngine.Random.Range(-ingredientRange, ingredientRange), -3f,-1), new Quaternion());
        onion.name = "Onion";
        onion.transform.SetParent(levelGameObject.transform);
        GameObject meat = Instantiate(meatGameObject, new Vector3(UnityEngine.Random.Range(-ingredientRange, ingredientRange), -3f,-1), new Quaternion());
        meat.name = "Meat";
        meat.transform.SetParent(levelGameObject.transform);
        GameObject cheese = Instantiate(cheeseGameObject, new Vector3(UnityEngine.Random.Range(-ingredientRange, ingredientRange), -3f,-1), new Quaternion());
        cheese.name = "Cheese";
        cheese.transform.SetParent(levelGameObject.transform);
        GameObject lettuce = Instantiate(lettuceGameObject, new Vector3(UnityEngine.Random.Range(-ingredientRange, ingredientRange), -3f,-1), new Quaternion());
        lettuce.name = "Lettuce";
        lettuce.transform.SetParent(levelGameObject.transform);
        Debug.Log("Succeeded at loading level");
    }

    public void DeleteLevel(int level)
    {
        Debug.Log("Deleting level " + level + " from file " + filePath);
        LevelSaves levelSaves = GetLevelSaves();
        levelSaves.saves.RemoveAt(level);
        string jsonContent = JsonUtility.ToJson(levelSaves);
        using (StreamWriter streamWriter = File.CreateText(filePath))
        {
            streamWriter.WriteLine(jsonContent);
        }
        Debug.Log("Succeeded at deleting level");
    }
}

public class IncorrectFileStructureException : Exception
{
    public IncorrectFileStructureException()
    {
        
    }

    public IncorrectFileStructureException(string message) : base(message)
    {
        
    }

    public IncorrectFileStructureException(string message, Exception inner) : base(message, inner)
    {
        
    }
}