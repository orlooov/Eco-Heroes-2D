using UnityEngine;

public class TimedDestructor : MonoBehaviour
{
    public float lifetime = 5f; // Время жизни объекта

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }
}