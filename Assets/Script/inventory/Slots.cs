using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{

    private Inventory inventory;
    public int NumberSlot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount <=0)
        {
            
        }
        inventory.Full[NumberSlot] = false;
    }
    public void DropItem()
    {
        foreach(Transform Child in transform)
        {
            Child.GetComponent<Spawn> ().DropItem();
        }
    }
}
