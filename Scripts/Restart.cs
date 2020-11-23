using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    // Restart takkinn
    public void restartScene()
    {
        // Birta current scene aftur
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
