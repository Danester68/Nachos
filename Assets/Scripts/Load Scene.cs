using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadMainMenu() {
        SceneManager.LoadScene(0);
    }

    public void LoadMainGame() {
        SceneManager.LoadScene(1);
    }
}
