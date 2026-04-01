using UnityEngine;

public class Pickap : MonoBehaviour
{
    public GameObject ItemButton;
    private Inventory inventory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                // Проверяем, пуст ли слот и нет ли уже предметов в слоте
                if (!inventory.Full[i] && inventory.slots[i].transform.childCount == 0)
                {
                    // Создаём объект и добавляем его в слот
                    GameObject spawnedItem = Instantiate(ItemButton, inventory.slots[i].transform, false);
                    inventory.Full[i] = true; // Помечаем слот как занятый

                    Debug.Log($"Предмет добавлен в слот {i}. Дочерних объектов: {inventory.slots[i].transform.childCount}");

                    Destroy(gameObject); // Уничтожаем объект, поднятый игроком
                    return; // Прерываем цикл, чтобы предмет заполнил только один слот
                }
            }

            Debug.Log("Все слоты заняты! Невозможно добавить предмет.");
        }
    }
}
