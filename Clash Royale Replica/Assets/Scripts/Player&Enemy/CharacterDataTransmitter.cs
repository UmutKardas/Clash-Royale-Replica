using UnityEngine;

public class CharacterDataTransmitter : MonoBehaviour
{
    [SerializeField] private CharacterHealthController characterHealthController;
    [SerializeField] private CharacterMovementController characterMovementController;
    [SerializeField] private CharacterAnimationController characterAnimationController;



    public float GetCharacterHealthValue()
    {
        return characterHealthController.characterHealthValue;
    }



    public int GetCharacterType()
    {
        return (int)characterMovementController.characterType;
    }



    public Transform GetTargetTransform()
    {
        return characterMovementController._targetTranform;
    }



    public void GetTargetCharacter(Transform targetTransform)
    {
        characterMovementController.SetTargetCharacter(targetTransform);
    }



    public void GetAttackAnimationActive(bool isActive)
    {
        characterAnimationController.SetAttackAnimationActive(isActive);
    }


    public bool GetWariorAttack()
    {
        return characterAnimationController.warriorAttack;
    }
}
