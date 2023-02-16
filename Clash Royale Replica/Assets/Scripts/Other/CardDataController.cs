using UnityEngine;

public class CardDataController : MonoBehaviour
{
    [SerializeField] private Card card;


    public float GetCharacterValue(int value)
    {
        return card.CardDatas[value].manaValue;
    }
}
