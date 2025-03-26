using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{

    public Card card;

    public string nameText;
    public string infoText;
    public Sprite cardImage;

    // Start is called before the first frame update
    void Start()
    {
        nameText = card.nameText;
        infoText = card.cardInfo;
        cardImage = card.cardImage;
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
