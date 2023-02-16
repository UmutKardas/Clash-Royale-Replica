using UnityEngine;
using KardasTag;

public class PlayerInputController : MonoBehaviour
{
    [Header("Raycast")]
    [SerializeField] private LayerMask layerMask;
    Ray mousePosition;
    RaycastHit hit;


    [Header("Other")]
    [SerializeField] private EnemySpawnController enemySpawnController;
    [SerializeField] private ManaController manaController;
    [SerializeField] private ObjectPoolen objectPoolen;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private GameManager gameManager;
    private Vector3 _mouseVectorPosition;
    private float _characterPositionY = 2f;
    private float _magicCharacterPositionY = 5f;



    void Update()
    {
        SetPlayerInput();
    }

    /// <summary>
    ///  Activating a character in the arena.
    /// </summary>
    private void SetPlayerInput()
    {
        mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mousePosition, out hit, Mathf.Infinity, layerMask) && gameManager.isSelect)
        {
            if (!uiManager.isTouch)
            {
                SelectSpawnPoint();
            }

            else
            {
                if (Input.GetMouseButtonUp(0))
                {
                    SelectSpawnPoint();
                    uiManager.isTouch = false;
                }
            }
        }
    }


    private void SelectSpawnPoint()
    {
        objectPoolen.selectPlayerCharacter.SetActive(true);
        SetSpawnCharacterTransform();
        gameManager.isSelect = false;
        uiManager.SetButtonMoveDownAnimation(objectPoolen.characterCardValue);
        manaController.DescreaManaCount(objectPoolen.characterCardValue);

    }


    private void SetSpawnCharacterTransform()
    {
        _mouseVectorPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.gameObject.transform.position.y));
        if (objectPoolen.selectPlayerCharacter.layer == LayerMask.NameToLayer(Tag.MAGIC))
        {
            Debug.Log("geldi");
            objectPoolen.selectPlayerCharacter.transform.position = new Vector3(_mouseVectorPosition.x, _magicCharacterPositionY, _mouseVectorPosition.z);
        }
        else
        {
            objectPoolen.selectPlayerCharacter.transform.position = new Vector3(_mouseVectorPosition.x, _characterPositionY, _mouseVectorPosition.z);
        }

    }
}