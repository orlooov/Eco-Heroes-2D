using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] slots; // Слоты инвентаря
    public bool[] Full; // Флаги, указывающие, занят ли слот

    // Метод для добавления предмета в инвентарь
    public void AddItemToInventory(GameObject item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (!Full[i]) // Если слот пуст
            {
                // Помещаем предмет в первый свободный слот
                GameObject newItem = Instantiate(item);
                newItem.transform.SetParent(slots[i].transform); // Добавляем предмет в слот
                Full[i] = true; // Помечаем слот как занятый
                Debug.Log($"Предмет {item.name} добавлен в инвентарь.");
                break;
            }
        }
    }
}
