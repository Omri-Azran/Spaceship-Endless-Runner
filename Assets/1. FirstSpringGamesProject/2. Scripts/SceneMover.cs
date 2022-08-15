using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMover : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(EndGame());
    }
    IEnumerator EndGame()
    {
        while(true)
        {
            if(Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("Game_Over");
            }
            yield return null;
        }
    }
    public static void MoveScene()
    {
        
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game_Over"))
        {
            SceneManager.LoadScene("Main_Menu");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}