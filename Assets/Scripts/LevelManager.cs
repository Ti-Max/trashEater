using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel(int level)
    {
        if (level > 0)
        {
            SceneManager.LoadScene(level - 1);
        }
    }
}
