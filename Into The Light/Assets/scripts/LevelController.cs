using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private static LevelController instance;
    public static LevelController Instance { get; private set; }

    public GameObject LevelMenu;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void LoadScene(int scenenumber)
    {
        SceneManager.LoadScene(scenenumber);
    }
    public void MenuLevel()
    {
        LevelMenu.gameObject.SetActive(true);
    }
    public void exit()
    {
        Application.Quit();
    }
}
