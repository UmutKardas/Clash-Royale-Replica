using UnityEngine;
using KardasTag;

public class CharacterCollisionController : MonoBehaviour
{
    [SerializeField] private CharacterDataTransmitter characterDataTransmitter;
    private int _characterTypeValue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tag.TARGET))
        {
            _characterTypeValue = characterDataTransmitter.GetCharacterType();
            if (other.gameObject.GetComponent<CharacterDataTransmitter>().GetCharacterType() != _characterTypeValue)
            {
                if (this.gameObject.layer == LayerMask.NameToLayer(Tag.WARRIOR))
                {
                    if (other.gameObject.layer != LayerMask.NameToLayer(Tag.MAGIC))
                        characterDataTransmitter.GetTargetCharacter(other.gameObject.transform);
                }
                else
                {
                    characterDataTransmitter.GetTargetCharacter(other.gameObject.transform);
                }
            }
        }


        if (other.gameObject.CompareTag("Tower"))
        {
            _characterTypeValue = characterDataTransmitter.GetCharacterType();
            if (_characterTypeValue == 0)
            {
                if (!other.gameObject.GetComponent<TowerHealthController>().isEnemyTower)
                {
                    characterDataTransmitter.GetTargetCharacter(other.gameObject.transform);
                }
            }

            else
            {
                if (other.gameObject.GetComponent<TowerHealthController>().isEnemyTower)
                {
                    characterDataTransmitter.GetTargetCharacter(other.gameObject.transform);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(Tag.TARGET) && this.gameObject.layer == LayerMask.NameToLayer(Tag.WARRIOR))
        {
            _characterTypeValue = characterDataTransmitter.GetCharacterType();
            if (other.gameObject.GetComponent<CharacterDataTransmitter>().GetCharacterType() != _characterTypeValue)
            {
                other.gameObject.GetComponent<CharacterMovementController>().SelectTowerTarget();
            }
        }
    }
}
