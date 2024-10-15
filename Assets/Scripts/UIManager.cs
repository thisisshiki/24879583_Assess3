using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Load level 1
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1Scene");
    }

    // Load level 2
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2Scene");
    }

}
