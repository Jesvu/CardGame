using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Mono.Cecil.Cil;

public class GameManager : MonoBehaviour
{
    public List<GameObject> deck = new List<GameObject>();
    [SerializeField]private GameObject used = null;
    public Transform cardSlot;

    private CardDisplay cardDisplay;

    private string kysName;
    private string huoraName;
    public GameObject inputField;
    public GameObject inputField2;
    public GameObject kysDisplay;
    public GameObject huoraDisplay;
    public GameObject button;
    public GameObject button2;
    public GameObject nameInsert;
    public GameObject nameInsert2;
    public GameObject endMenu;
    public Button cardPickButton;
    public Text beginningInfo;

    [SerializeField]private int startingCards = 0;
    [SerializeField]private int cardAmount = 0;

    public Text cardInfo;
    public GameObject infoButton;
    public GameObject infoPanel;

    Card card;


    private void Awake()
    {
        infoPanel.SetActive(false);
        endMenu.SetActive(false);
        cardAmount = deck.Count + 1;
        startingCards = deck.Count;
    }
    
    public void DrawCard()
    {
        if (beginningInfo)
        {
            beginningInfo.enabled = false;
        }

        if (cardAmount == 0)
        {
            cardAmount += 0;
        }
        else
        {
            Destroy(used);
            cardAmount -= 1;
            infoPanel.SetActive(false);
        }

        if (deck.Count >= 1)
        {
            GameObject randCard = deck[Random.Range(0, deck.Count)];

            cardDisplay = randCard.GetComponent<CardDisplay>();


            for (int i = 0; i < deck.Count; i++)
            {
                randCard.gameObject.SetActive(true);
                randCard.transform.position = cardSlot.position;

                deck.Remove(randCard);
                used = randCard;


                if(cardDisplay.nameText == "Mestari")
                {
                    cardPickButton.interactable = false;
                    Mestari();
                }
                else if (cardDisplay.nameText == "Huora")
                {
                    cardPickButton.interactable = false;
                    Huora();
                }
            }
        }
    }

    public void NoCards()
    {
        if (used && cardAmount == 0)
        {
            EndMenu();
        }
    }

    private void SetFalse()
    {
        if(nameInsert == true)
        {
            nameInsert.gameObject.SetActive(false);
            infoButton.gameObject.SetActive(true);
            cardPickButton.interactable = true;
        }
        if (nameInsert2 == true)
        {
            nameInsert2.gameObject.SetActive(false);
            infoButton.gameObject.SetActive(true);
            cardPickButton.interactable = true;
        }
    }

    public void Mestari()
    {
        cardPickButton.interactable = false;
        infoButton.gameObject.SetActive(false);
        nameInsert.gameObject.SetActive(true);
        kysName = inputField.GetComponent<Text>().text;
        kysDisplay.GetComponent<Text>().text = kysName;

        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(SetFalse);
    }

    public void Huora()
    {
        infoButton.gameObject.SetActive(false);
        nameInsert2.gameObject.SetActive(true);
        huoraName = inputField2.GetComponent<Text>().text;
        huoraDisplay.GetComponent<Text>().text = huoraName;

        Button btn = button2.GetComponent<Button>();
        btn.onClick.AddListener(SetFalse);
    }

    public void EndMenu()
    {
        endMenu.SetActive(true);
        infoButton.SetActive(false);
    }

    public void ShowInfo()
    {
        if (infoPanel.activeSelf == false)
        {
            if (startingCards >= cardAmount && cardAmount > 0)
            {
                infoPanel.SetActive(true);
                cardInfo.GetComponent<Text>().text = cardDisplay.infoText;
            }
        }
        else
        {
            infoPanel.SetActive(false);
        }

    }

}
