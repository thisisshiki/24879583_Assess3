using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L1UIManager : MonoBehaviour
{
    public void ReturnToStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
