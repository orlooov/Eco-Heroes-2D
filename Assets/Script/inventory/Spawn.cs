using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
        private Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

   
    public void DropItem()
    {
        Vector2 playerPos = new Vector2(player.position.x - 1, player.position.y);
        Instantiate(item, playerPos, Quaternion.identity);
        Destroy(gameObject);
    }
}
