using UnityEngine;
using KardasTag;

public class SwordAttackController : MonoBehaviour
{
    [SerializeField] private CharacterDataTransmitter characterDataTransmitter;
    [SerializeField] private CharacterAnimationController characterAnimationController;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tag.TARGET))
        {
            if (characterDataTransmitter.GetTargetTransform().gameObject == other.gameObject && characterDataTransmitter.GetWariorAttack())
            {
                other.gameObject.GetComponent<CharacterHealthController>().SetCharacterHealthDecrease(40);
                characterAnimationController.warriorAttack = false;
            }
        }


        if (other.gameObject.CompareTag(Tag.TOWER))
        {
            if (characterDataTransmitter.GetTargetTransform().gameObject == other.gameObject && characterDataTransmitter.GetWariorAttack())
            {
                other.gameObject.GetComponent<TowerHealthController>().SetTowerTakeDamage(40);
                characterAnimationController.warriorAttack = false;
            }
        }
    }
}
