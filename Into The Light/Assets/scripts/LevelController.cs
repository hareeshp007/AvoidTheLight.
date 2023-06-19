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
        SoundController.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(scenenumber);
    }
    public void MenuLevel()
    {
        SoundController.Instance.Play(Sounds.ButtonClick);
        LevelMenu.gameObject.SetActive(true);
    }
    public void exit()
    {
        SoundController.Instance.Play(Sounds.ButtonClick);
        Application.Quit();
    }
}
