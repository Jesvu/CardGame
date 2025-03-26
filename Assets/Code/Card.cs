using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public string nameText;
    public Sprite cardImage;
    public string cardInfo;
}
