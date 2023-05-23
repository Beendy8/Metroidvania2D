using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private const string levelName = "Level1";

    [SerializeField] private GameObject settingPanel;
    public void Play()
    {
        SceneManager.LoadScene(levelName);
    }
    public void Settings(bool active)
    {
        settingPanel.SetActive(active);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
