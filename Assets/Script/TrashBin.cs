using UnityEngine;
using System.Collections;

public class TrashBin : MonoBehaviour
{
    private Inventory inventory; // Ссылка на инвентарь игрока
    private bool isPlayerNear = false; // Флаг нахождения игрока рядом
    public Quest_Event questEvent; // Ссылка на квест

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>(); // Находим игрока
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNear = true;
            Debug.Log("Press 'E' to dispose trash.");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(DisposeAllTrash()); // Вызываем корутину для выбрасывания всего мусора
        }
    }

    // Корутина для выбрасывания всего мусора
    private IEnumerator DisposeAllTrash()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            // Пока в слоте есть предметы
            while (inventory.slots[i].transform.childCount > 0)
            {
                Transform item = inventory.slots[i].transform.GetChild(0); // Получаем первый предмет в слоте
                Destroy(item.gameObject); // Убираем предмет из инвентаря
                inventory.Full[i] = false; // Обновляем статус в инвентаре
                questEvent.UpdateTrashCollected(); // Обновляем квест

                // Немного задержки, чтобы избежать лагов
                yield return null; // Даем Unity время для обновления кадра
            }
        }

        Debug.Log("All trash disposed.");

        // Проверяем, завершён ли квест
        if (questEvent.collectedTrash >= 5)
        {
            questEvent.CompleteQuest(); // Завершаем квест
        }
    }
}
