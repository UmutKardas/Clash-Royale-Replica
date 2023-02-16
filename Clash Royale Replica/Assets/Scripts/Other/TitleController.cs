using UnityEngine;
using KardasTag;

public class TitleController : MonoBehaviour
{
    private Transform _cameraTransform;
    private float _titleRotationX = -117;
    private float _titleRotationY = -0.04f;
    private float _titleRotationZ = -90;



    private void Start()
    {
        GetComponentValues();
    }



    private void Update()
    {
        SetTitleTextRotation();
    }



    private void SetTitleTextRotation()
    {
        transform.rotation = Quaternion.Euler(_titleRotationX, _titleRotationY, _titleRotationZ);
    }



    private void GetComponentValues()
    {
        _cameraTransform = GameObject.FindGameObjectWithTag(Tag.CAMERA).transform;
    }
}