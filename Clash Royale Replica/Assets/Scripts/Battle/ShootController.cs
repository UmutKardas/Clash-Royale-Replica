using UnityEngine;
using KardasTag;


public class ShootController : MonoBehaviour
{
    [SerializeField] private BattleAttackController battleAttackController;
    [SerializeField] private float movementSpeed;
    [SerializeField] private GameObject _targetObject;
    private bool _isMoving;



    public void SelectTarget(Transform targetTransform, bool isActive)
    {
        this.gameObject.SetActive(isActive);
        if (isActive)
        {
            _targetObject = targetTransform.gameObject;
        }

        _isMoving = isActive;
    }



    private void Update()
    {
        if (_isMoving)
            SetShootMovement();
    }



    private void SetShootMovement()
    {
        if (this.gameObject.layer == LayerMask.NameToLayer(Tag.ARROW) || this.gameObject.layer == LayerMask.NameToLayer(Tag.MAGICBALL))
        {
            battleAttackController.SetDamage(_targetObject.transform);
        }
        if (_targetObject.gameObject.activeInHierarchy)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetObject.transform.position, movementSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, 3f, transform.position.z);
        }
        else
            SelectTarget(null, false);
    }

}
