using UnityEngine;



    public class BackgroundInstanceControllerComponent : MonoBehaviour
    {


    private void Awake()
    {

        DontDestroyOnLoad(this.gameObject);
    }
    }

