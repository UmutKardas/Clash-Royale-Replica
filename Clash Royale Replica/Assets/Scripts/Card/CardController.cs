using UnityEngine;
using UnityEngine.EventSystems;

public class CardController : MonoBehaviour, IPointerExitHandler, IPointerUpHandler, IPointerEnterHandler
{
    [SerializeField] private UIManager uIManager;
    [SerializeField] private int cardIndex;



    public void OnPointerExit(PointerEventData eventData)
    {
        uIManager.SetButtonAnimationDeActive();
    }



    public void OnPointerUp(PointerEventData eventData)
    {
        uIManager.SelectCharacter(cardIndex);
    }



    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        uIManager.SetButtonMoveUpAnimation(cardIndex);
    }
}
