using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* ordres du starter:
 * variable "orders":
 *      0: rien
 *      1: On Your Marks
 *      2: Get Set
 *      3: Go !
 *      4: False Start
 */

public class GameManager : MonoBehaviour
{
    public SprinterManager sprinterManager;
    public Animator playerAnimator;
    public TextMeshProUGUI textMeshProStarterOrders;
    public GameObject imageButton;
    public Button restartButton;

    private int orders;
    private float tempsAffichageTexte = 1.0f;
    private float tempsAttenteAvantDemmarage = 3.0f;
    private float tempsAttente;
    private float t0, tOrders;


    // Start is called before the first frame update
    void Start()
    {
        orders = 0;
        tOrders = Time.time;
        tempsAttente = tempsAttenteAvantDemmarage;
        // Attache la méthode RestartGame au clic du bouton "Restart"
        restartButton.onClick.AddListener(RestartGame);
    }

    // Update is called once per frame
    void Update()
    {

        if(orders < 3 && Time.time - tOrders > tempsAttente)
        {
            switch (orders)
            {
                case 0:
                    orders = 1;
                    tOrders = Time.time;
                    tempsAttente = 3.0f;
                    StarterOrder_onYourMarks();
                    break;

                case 1:
                    orders = 2;
                    tOrders = Time.time;
                    tempsAttente = Random.Range(1, 3);
                    StarterOrder_getSet();
                    break;
                case 2:
                    orders = 3;
                    StarterOrder_GO();
                    break;
            }
        }
        else
        {
            if (orders == 3 && imageButton.activeSelf == false)
            {
                // Ajout d'une condition pour appeler la fonction uniquement si orders == 3 et que le bouton n'est pas déjà actif
                ApparitionBouton();
            }
            else
            {
                if(orders == 4)
                    StarterOrder_falseStart();
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
        t0 = Time.time;
        playerAnimator.SetTrigger("OnYourMarks");
    }

    void StarterOrder_getSet()
    {

        textMeshProStarterOrders.text = "Get Set";
        textMeshProStarterOrders.gameObject.SetActive(true);
        t0 = Time.time;
        playerAnimator.ResetTrigger("OnYourMarks");
        playerAnimator.SetTrigger("GetSet");
    }
    void StarterOrder_GO()
    {
        textMeshProStarterOrders.text = "Go !";
        textMeshProStarterOrders.gameObject.SetActive(true);
        t0 = Time.time;
        playerAnimator.ResetTrigger("GetSet");
        playerAnimator.SetTrigger("Go");
    }
    void StarterOrder_falseStart()
    {
        textMeshProStarterOrders.text = "False Start !";
        textMeshProStarterOrders.gameObject.SetActive(true);
        t0 = Time.time;
        playerAnimator.ResetTrigger("GetSet");
        playerAnimator.SetTrigger("PlayerFalseStart");
    }

    void ApparitionBouton()
    {
        Vector3 nouvellePosition;

        if (Random.Range(0, 2) == 1)
            nouvellePosition = new Vector3(-350, 0, 0); // Bouton à gauche
        else
            nouvellePosition = new Vector3(350, 0, 0); // Bouton à droite

        RectTransform rectTransformBouton = imageButton.GetComponent<RectTransform>();
        rectTransformBouton.anchoredPosition = nouvellePosition;
        imageButton.SetActive(true);
    }

    public void onClickButton()
    {
        sprinterManager.run();
        imageButton.SetActive(false);
    }

    public void RestartGame()
    {
        // Réinitialisation des variables de jeu
        orders = 0;
        tOrders = Time.time;
        tempsAttente = tempsAttenteAvantDemmarage;
        sprinterManager.ResetPlayerPosition(); // méthode à créer pour remettre le joueur à la position de départ

        // Recharge de la scène actuelle
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
