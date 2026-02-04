using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadLevelMenu : MonoBehaviour
{
    public List<GameObject> levelSlots;
    public List<TextMeshProUGUI> levelTexts;
    public List<Button> loadButtons;
    public List<Button> deleteButtons;
    
    public SaveLoadLevel saveLoadLevel;

    void Awake()
    {
        LoadLevels();
    }

    void Start()
    {
        LoadLevels();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            foreach (Button button in deleteButtons)
            {
                if (button.transform.parent.gameObject.tag == "LevelSlot")
                {
                    button.interactable = true;
                }
            }
        }
        else
        {
            foreach (Button button in deleteButtons)
            {
                button.interactable = false;
            }
        }
        if (gameObject.activeInHierarchy)
        {
            LoadLevels();
        }
    }

    public void LoadLevels()
    {
        LevelSaves levelSaves = saveLoadLevel.GetLevelSaves();
        List<LevelSave> saves = levelSaves.saves;
        int lastIndex = 0;
        if (saves.Count > 0)
        {
            for (int i = 0; i < saves.Count; i++)
            {
                lastIndex = i;
                levelTexts[i].text = "Level Save " + (i + 1);
                loadButtons[i].interactable = true;
                levelSlots[i].tag = "LevelSlot";
            }
        }
        else
        {
            lastIndex = -1;
        }
        if (!(lastIndex >= 4))
        {
            for (int i = lastIndex + 1; i < 5; i++)
            {
                levelTexts[i].text = "Empty Slot";
                loadButtons[i].interactable = false;
                levelSlots[i].tag = "EmptyLevelSlot";
            }
        }
    }

    public void LoadLevel(int level)
    {
        saveLoadLevel.LoadLevel(level);
    }

    public void DeleteLevel(int level)
    {
        saveLoadLevel.DeleteLevel(level);
        deleteButtons[level].interactable = false;
        LoadLevels();
    }
}