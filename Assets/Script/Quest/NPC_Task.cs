using UnityEngine;

public class NPC_Task : MonoBehaviour
{
    public GameObject Dialog1; // Первый диалог
    public GameObject Dialog2; // Второй диалог
    public bool EndDialog;
    public Quest_Event QE; // Ссылка на квест
    public bool Fin_Dialog;
    private bool onHide;

    void Update()
    {
        // Проверяем, существует ли объект квеста и его состояние
        if (QE != null && QE.end_Quest1 == true)
        {
            Fin_Dialog = true;
        }

        if (EndDialog)
        {
            Time.timeScale = 1;
            QE.Quest1 = true; // Запускаем квест
            if (Dialog1 != null) Dialog1.SetActive(false);
        }

        if (Fin_Dialog && !onHide)
        {
            Time.timeScale = 1;
            QE.Quest1 = false; // Останавливаем квест
            if (Dialog2 != null) Dialog2.SetActive(true); // Показываем второй диалог
            onHide = true; // Устанавливаем флаг, чтобы не показывать второй диалог повторно
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            // Если диалог еще не завершен, показываем первый диалог
            if (!Fin_Dialog)
            {
                Time.timeScale = 0;
                if (Dialog1 != null) Dialog1.SetActive(true); // Показываем первый диалог
            }
            else if (!onHide) // Если диалог завершен, показываем второй диалог
            {
                Time.timeScale = 0; // Останавливаем время
                if (Dialog2 != null) Dialog2.SetActive(true); // Показываем второй диалог
                onHide = true; // Устанавливаем флаг, чтобы не показывать второй диалог повторно
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            // Скрываем диалоги, когда игрок покидает триггер
            if (Dialog1 != null) Dialog1.SetActive(false);
            if (Dialog2 != null) Dialog2.SetActive(false);
            Time.timeScale = 1; // Возвращаем время в норму
            onHide = false; // Сбрасываем флаг
        }
    }
}