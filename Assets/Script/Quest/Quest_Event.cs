using UnityEngine;

public class Quest_Event : MonoBehaviour
{
    public bool Quest1; // Активен ли квест
    public GameObject Text1; // Текст квеста (UI)
    public bool end_Quest1; // Завершён ли квест
    public int collectedTrash = 0; // Количество собранного мусора

    void Update()
    {
        // Показываем текст, если квест активен и не завершён
        if (Quest1 && !end_Quest1)
        {
            Text1.SetActive(true);
        }
        else
        {
            Text1.SetActive(false); // Скрываем текст квеста, если квест завершён
        }
    }

    // Метод вызывается, когда игрок выбрасывает мусор
    public void UpdateTrashCollected()
    {
        collectedTrash++; // Увеличиваем количество собранного мусора
        Debug.Log("Collected Trash: " + collectedTrash); // Отладка
    }

    // Метод, который завершает квест
    public void CompleteQuest()
    {
        if (collectedTrash >= 5)
        {
            end_Quest1 = true; // Завершаем квест
            Debug.Log("Quest Completed!"); // Отладка

            // Добавляем 20 очков за завершение квеста
            ScoreManager.Instance.AddScore(20);
        }
    }
}
