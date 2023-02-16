using UnityEngine;
using KardasTag;

public class CharacterAnimationController : MonoBehaviour
{
    public bool warriorAttack;
    public ObjectPoolen _objectPoolen;

    [SerializeField] private CharacterDataTransmitter characterDataTransmitter;
    [SerializeField] private Animator characterAnimator;
    [SerializeField] private Transform spawnTransform;


    private void OnEnable()
    {
        GetComponentValues();
        SetAttackAnimationActive(false);
    }



    private void GetComponentValues()
    {
        _objectPoolen = GameObject.FindGameObjectWithTag(Tag.OBJECTPOOLEN).GetComponent<ObjectPoolen>();
    }



    public void SetAttackAnimationActive(bool isActive)
    {
        characterAnimator.SetBool("Attack", isActive);
    }


    #region AnimationEvent
    public void SetBattleObjectSpawner(int value)
    {
        _objectPoolen.SetSelectBattleObject(value, spawnTransform, characterDataTransmitter.GetTargetTransform());
    }



    public void SetWarriorAttack()
    {
        warriorAttack = true;
    }
    #endregion
}
