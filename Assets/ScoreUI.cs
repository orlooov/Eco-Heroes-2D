using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public TMP_Text scoreText;  // Обязательно TMP_Text, а не Text

    void Update()
    {
        if (ScoreManager.Instance != null)
        {
            scoreText.text = "Очки: " + ScoreManager.Instance.GetScore();
        }
    }
}
