using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MouvementPlayer mouvementPlayer;
    public Animator playerAnimator;
    public TextMeshProUGUI textMeshProStarterOrders;

    private int orders;
    private float tempsAffichageTexte = 1.0f;
    private float t0;

    // Start is called before the first frame update
    void Start()
    {
        orders = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space") == true || Input.touchCount > 0)
        {
            orders++;

            switch (orders)
            {
                case 1:
                    StarterOrder_onYourMarks();
                    t0 = Time.time;
                    break;

                case 2:
                    StarterOrder_getSet();
                    t0 = Time.time;
                    break;
                case 3:
                    StarterOrder_GO();
                    t0 = Time.time;
                    break;
            }

        }

        // On fait disparaitre le texte au bout de x secondes
        if (Time.time - t0 > tempsAffichageTexte)
        {
            textMeshProStarterOrders.gameObject.SetActive(false);
        }
        
    }

    void StarterOrder_onYourMarks()
    {
        textMeshProStarterOrders.text = "On your marks";
        textMeshProStarterOrders.gameObject.SetActive(true);
        playerAnimator.SetTrigger("OnYourMarks");
    }

    void StarterOrder_getSet()
    {

        textMeshProStarterOrders.text = "Get Set";
        textMeshProStarterOrders.gameObject.SetActive(true);
        playerAnimator.ResetTrigger("OnYourMarks");
        playerAnimator.SetTrigger("GetSet");
    }
    void StarterOrder_GO()
    {
        textMeshProStarterOrders.text = "Go !";
        textMeshProStarterOrders.gameObject.SetActive(true);
        mouvementPlayer.MovePlayer(100.0f);
        playerAnimator.ResetTrigger("GetSet");
        playerAnimator.SetTrigger("Go");
    }
}
