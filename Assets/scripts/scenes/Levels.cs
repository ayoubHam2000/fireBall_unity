using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    [SerializeField] string theScene;
    public void GoToScene(string theScene)
    {
        if (theScene == "exit")
            Application.Quit();
        else
            SceneManager.LoadScene(theScene);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (theScene != "exit")
            {
                SceneManager.LoadScene(theScene);
            }

        }
    }

}
