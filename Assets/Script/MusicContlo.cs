using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MusicContlo : MonoBehaviour
{
    [Header("Components")]
    [Tooltip("Audio Source Does Not Connect Automatically")]
    [SerializeField] private AudioSource audio;
    [Tooltip("Slider Search Using A Tag")]
    [SerializeField] private Slider slider;

    [Header("Keys")]
    [Tooltip("Save Data PlayerPrefs Key")]
    [SerializeField] private string saveVolumeKey;

    [Header("Tags")]
    [Tooltip("Volume Control Slider Tag")]
    [SerializeField] private string sliderTag;

    [Header("Parameters")]
    [Tooltip("Sound Volume Value")]
    [SerializeField][Range(0.0f, 1.0f)] private float volume;

    private void Start()
    {
        // Задержка инициализации компонентов
        StartCoroutine(InitializeComponents());
    }

    private IEnumerator InitializeComponents()
    {
        // Ожидаем, чтобы объекты с тегами могли загрузиться
        yield return new WaitForSeconds(1f);

        // Проверяем наличие сохранённого значения громкости
        if (PlayerPrefs.HasKey(this.saveVolumeKey))
        {
            this.volume = PlayerPrefs.GetFloat(this.saveVolumeKey);
            this.audio.volume = this.volume;

            // Находим слайдер и устанавливаем его значение
            GameObject sliderObj = GameObject.FindWithTag(this.sliderTag);
            if (sliderObj != null)
            {
                this.slider = sliderObj.GetComponent<Slider>();
                this.slider.value = this.volume;
            }
            else
            {
                Debug.LogError($"Slider with tag {this.sliderTag} not found.");
            }
        }
        else
        {
            // Устанавливаем значение громкости по умолчанию
            this.volume = 0.5f;
            PlayerPrefs.SetFloat(this.saveVolumeKey, this.volume);
            this.audio.volume = this.volume;
        }
    }

    private void LateUpdate()
    {
        // Если слайдер ещё не подключён, ищем его
        if (this.slider == null)
        {
            GameObject sliderObj = GameObject.FindWithTag(this.sliderTag);
            if (sliderObj != null)
            {
                this.slider = sliderObj.GetComponent<Slider>();
                this.slider.value = this.volume;
            }
        }

        // Если слайдер найден, обновляем громкость
        if (this.slider != null)
        {
            this.volume = this.slider.value;
            this.audio.volume = this.volume;

            // Сохраняем новое значение громкости
            PlayerPrefs.SetFloat(this.saveVolumeKey, this.volume);
        }
    }
}
