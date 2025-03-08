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

    public void CheckEditorState(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingPlayMode)
        {
            data.ResetAllLevelsAndScore();
        }
    }
}
