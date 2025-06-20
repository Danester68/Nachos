using System;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{

    public GameObject LevelObj;
    public GameObject Tree;
    public GameObject Bush;

    public GameObject Chip;
    public GameObject Tomato;
    public GameObject Onion;
    public GameObject Meat;
    public GameObject Cheese;
    public GameObject Lettuce;
    public GameObject Oven;

    public float range;
    public float ingredientRange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        generateLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void generateLevel() {
        destroyLevelData();
        generateTrees();
        generateBushes();
        addIngredients();
    }

    void destroyLevelData() {
        foreach (Transform child in LevelObj.transform) {
            Destroy(child.gameObject);
        }
    }

    void generateTrees() {
        for (int i = 1; i < UnityEngine.Random.Range(0, range); i++) {
            GameObject tree = Instantiate(Tree, new Vector3(UnityEngine.Random.Range(-range, range), -1.3f, 0), new Quaternion());
            tree.name = "Tree_" + i;
            tree.transform.SetParent(LevelObj.transform);
        }
    }
    void generateBushes() {
        for (int i = 1; i < UnityEngine.Random.Range(0, range); i++) {
            GameObject bush = Instantiate(Bush, new Vector3(UnityEngine.Random.Range(-range, range), -3f, 0), new Quaternion());
            bush.name = "Bush_" + i;
            bush.transform.SetParent(LevelObj.transform);
        }
    }
    void addIngredients() {
        GameObject chip = Instantiate(Chip, new Vector3(UnityEngine.Random.Range(-ingredientRange, ingredientRange), -3f, -1), new Quaternion());
        chip.name = "Chip";
        chip.transform.SetParent(LevelObj.transform);
        GameObject tomato = Instantiate(Tomato, new Vector3(UnityEngine.Random.Range(-ingredientRange, ingredientRange), -3f,-1), new Quaternion());
        tomato.name = "Tomato";
        tomato.transform.SetParent(LevelObj.transform);
        GameObject onion = Instantiate(Onion, new Vector3(UnityEngine.Random.Range(-ingredientRange, ingredientRange), -3f,-1), new Quaternion());
        onion.name = "Onion";
        onion.transform.SetParent(LevelObj.transform);
        GameObject meat = Instantiate(Meat, new Vector3(UnityEngine.Random.Range(-ingredientRange, ingredientRange), -3f,-1), new Quaternion());
        meat.name = "Meat";
        meat.transform.SetParent(LevelObj.transform);
        GameObject cheese = Instantiate(Cheese, new Vector3(UnityEngine.Random.Range(-ingredientRange, ingredientRange), -3f,-1), new Quaternion());
        cheese.name = "Cheese";
        cheese.transform.SetParent(LevelObj.transform);
        GameObject lettuce = Instantiate(Lettuce, new Vector3(UnityEngine.Random.Range(-ingredientRange, ingredientRange), -3f,-1), new Quaternion());
        lettuce.name = "Lettuce";
        lettuce.transform.SetParent(LevelObj.transform);
        GameObject oven = Instantiate(Oven, new Vector3(UnityEngine.Random.Range(-ingredientRange, ingredientRange), -3f,-1), new Quaternion());
        oven.name = "Oven";
        oven.transform.SetParent(LevelObj.transform);
    }
}