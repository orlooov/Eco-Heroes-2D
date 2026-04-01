using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    public Quest_Event QEvent; // —сылка на объект квеста

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            // ”величиваем количество собранного мусора
            QEvent.UpdateTrashCollected(); // ћетод увеличивает количество собранного мусора

            // ”ничтожаем объект, который был собран
            Destroy(gameObject);
        }
    }
}
