using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // Синглтон для доступа к ScoreManager1

    private int score = 0; // Текущее количество очков

    private void Awake()
    {
        // Убедитесь, что существует только один объект ScoreManager1
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Сохраняем объект при смене сцены
        }
        else
        {
            Destroy(gameObject); // Удаляем новый объект, если уже существует экземпляр
        }
    }

    // Метод для добавления очков
    public void AddScore(int points)
    {
        score += points;
        Debug.Log($"Очки добавлены! Текущий счет: {score}");
    }

    // Метод для получения текущего счета
    public int GetScore()
    {
        return score;
    }
}
