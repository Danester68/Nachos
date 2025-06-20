using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsMenu;

    public GameObject pauseMenu;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadSettingsMenu() {
        SceneManager.LoadScene("Settings");
    }

    public void PauseMenu(bool pmenuBool) {
        pauseMenu.SetActive(pmenuBool);
        if (pmenuBool) {
            Time.timeScale = 0;
        } else {
            Time.timeScale = 1;
        }
    }

    public void ReturnToMainMenu() {
        Time.timeScale= 1;
        SceneManager.LoadScene("Main Menu");
    }

    public void Exit() {
        Application.Quit();
    }
//  Old functions
    public void InstantiateSettingsMenu()
    {
        GameObject oldMenu = GameObject.FindWithTag("currentMenu");
        oldMenu.tag = "inactiveMenu";
        oldMenu.SetActive(false);
        settingsMenu.tag = "currentMenu";
        settingsMenu.SetActive(true);
    }

    public void InstantiateMainMenu()
    {
        GameObject oldMenu = GameObject.FindWithTag("currentMenu");
        oldMenu.tag = "inactiveMenu";
        oldMenu.SetActive(false);
        mainMenu.tag = "currentMenu";
        mainMenu.SetActive(true);
    }
}
