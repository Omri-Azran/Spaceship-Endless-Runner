using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour
{
    public static int _Score;
    [SerializeField] Text score;
    
    IEnumerator Start()
    {
        _Score = 0;
        while (SceneManager.GetActiveScene().isLoaded)
        {
            if (score != null)
            {
                score.text = "Score: " + _Score;
            }
            yield return null;
        }
    }

    public static int AddScore()
    {
        return _Score += 3;
    }
        
}
