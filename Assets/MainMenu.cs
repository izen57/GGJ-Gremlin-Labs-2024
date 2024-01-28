using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartMenu(){
        SceneManager.LoadSceneAsync("Assets/Scenes/SampleScene.unity");
    }
    public void QuitMenu(){
        Application.Quit();
    }
    public void ToMenu(){
        SceneManager.LoadSceneAsync(0);
    }
}
