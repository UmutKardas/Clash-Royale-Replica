using UnityEngine;

[CreateAssetMenu(fileName = "New Card Data", menuName = "Card Data")]
public class Card : ScriptableObject
{
    public CardData[] CardDatas;
}

[System.Serializable]
public class CardData
{
    public int manaValue;
}
