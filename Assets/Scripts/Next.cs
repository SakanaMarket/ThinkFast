using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour
{
    [SerializeField] private string SceneName;

    public void LoadSceneName()
    {
        SceneManager.LoadScene(SceneName);
    }
}
