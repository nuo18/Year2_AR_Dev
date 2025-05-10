using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Scenes
    [SerializeField] private string scene1Name = "Scene_Game";
    [SerializeField] private string scene2Name = "Scene_Face Test";
    [SerializeField] private string scene3Name = "Scene_Image Track";

    // Called by the button OnClick event
    public void LoadScene1() => SceneManager.LoadScene(scene1Name);
    public void LoadScene2() => SceneManager.LoadScene(scene2Name);
    public void LoadScene3() => SceneManager.LoadScene(scene3Name);

    public void QuitApp()
    {
        Application.Quit();
    }
}
