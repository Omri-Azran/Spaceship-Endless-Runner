using UnityEngine;
using UnityEngine.UI;
using System.Text;
public class HighScore : MonoBehaviour
{
    [SerializeField] Text HighscoreText;
    [SerializeField] Text ScoreText;
    int Highscore;
    Encoding _Encoding;


    private void Start()
    {
        Highscore = PlayerPrefs.GetInt("HighScore", 0);
        if (Highscore < Score._Score)
        {
            Highscore = Score._Score;
            PlayerPrefs.SetInt("HighScore", Highscore);
        }
        ScoreText.text = "Score: " + Score._Score;
        HighscoreText.text = "Highscore: " + Highscore;

    }
}
