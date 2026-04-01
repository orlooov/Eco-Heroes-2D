using UnityEngine;

public class Dialog_Next : MonoBehaviour
{
    public GameObject Text1;
    public GameObject Text2;
    private bool isText1 = true;
    public NPC_Task npc_taskScript;
    public bool Fin_Dialog;
    public GameObject ObjectQuest;
    public GameObject ObjectQuest2;
    public GameObject ObjectQuest3;
    public GameObject ObjectQuest4;
    public GameObject ObjectQuest5;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isText1)
            {
                isText1 = false;
            }
            else
            {
                if (Fin_Dialog == false)
                {
                    isText1 = true;
                    ObjectQuest.SetActive(true);
                    ObjectQuest2.SetActive(true);
                    ObjectQuest3.SetActive(true);
                    ObjectQuest4.SetActive(true);
                    ObjectQuest5.SetActive(true);
                    npc_taskScript.EndDialog = true;
                }
                else
                {
                    isText1 = true;
                    npc_taskScript.Fin_Dialog = true;
                }
            }
        }

        if (isText1)
        {
            Text1.SetActive(true);
            Text2.SetActive(false);
        }
        else
        {
            Text1.SetActive(false);
            Text2.SetActive(true);
        }
    }
}