using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MainMenu : MonoBehaviour
{
    [SerializeField] Data data;
    [SerializeField] GameObject credits;
    private void OnEnable()
    {
#if UNITY_EDITOR
        EditorApplication.playModeStateChanged += CheckEditorState;
#endif
    }

    private void OnDisable()
    {
#if UNITY_EDITOR
        EditorApplication.playModeStateChanged -= CheckEditorState;
#endif
    }
    public void OnClickPlay()
    {
       
        SceneManager.LoadScene("GameScene");
    }
    private void Awake()
    {
        SaveManager.GetHighScore();
    }
#if UNITY_EDITOR
    public void CheckEditorState(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingPlayMode)
        {
            data.ResetAllLevelsAndScore();
        }
    }
#endif
    public void OnClickCredits()
    {
        if(credits.activeInHierarchy == true)
        {
            credits.gameObject.SetActive(false);
        }
        else
        {
            credits.gameObject.SetActive(true);
        }
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
