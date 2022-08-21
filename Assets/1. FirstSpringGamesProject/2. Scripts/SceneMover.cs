using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMover : MonoBehaviour
{
    const string FirstScene = "Main_Menu";
    const string LastScene = "Game_Over";
    private void Start()
    {
        StartCoroutine(EndGameOnEsc());
    }
    IEnumerator EndGameOnEsc()
    {
        while(true)
        {
            if(Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene(LastScene);
            }
            yield return null;
        }
    }
    public static void MoveScene()
    {
        
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName(LastScene))
        {
            SceneManager.LoadScene(FirstScene);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void EndGameOnLoss()
    {
        StartCoroutine(EndGameSequence(1));
    }

    IEnumerator EndGameSequence(float Seconds)
    {
        yield return new WaitForSeconds(Seconds);
        SceneManager.LoadScene(LastScene);
    }
}