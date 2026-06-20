using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
   int Score = 0 ;
    [SerializeField] TMP_Text ScoreText;


    public void IncreaseScore(int AddingScore)
    {
       Score += AddingScore;
        Debug.Log(Score);
        ScoreText.text=Score.ToString();

    }
}
