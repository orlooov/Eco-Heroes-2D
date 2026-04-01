using UnityEngine;

public class FullscreenToggle : MonoBehaviour
{
    // Метод для переключения полноэкранного режима
    public void ToggleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    // Метод для установки определённого режима (полный экран или окно)
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    // Пример использования: клавиша F11 для переключения полноэкранного режима
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11))
        {
            ToggleFullscreen();
        }
    }
}
