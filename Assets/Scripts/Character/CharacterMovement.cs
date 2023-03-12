using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour
{
    public Animator characterAnimator;
    public Transform characterTr;
    public Rigidbody characterBody;

    private Vector3 _InputVector;

    private Joystick _Joystick => SingletonController.singletonController.UIController.joystick;
    private float _MoveSpeed => SingletonController.singletonController.config.characterMoveSpeed;
    private float _RotateSpeed => SingletonController.singletonController.config.characterRotateSpeed;

    private void FixedUpdate()
    {
        CharacterMove();
        CharacterRotate();
    }

    private void CharacterMove()
    {
        _InputVector.x = _Joystick.Horizontal;
        _InputVector.z = _Joystick.Vertical;

        characterBody.velocity = _InputVector * _MoveSpeed;
        characterAnimator.SetBool("IsRun", _InputVector != Vector3.zero);
    }

    private void CharacterRotate()
    {
        if (_InputVector == Vector3.zero) return;

        characterTr.rotation = Quaternion.Lerp(characterTr.rotation,
            Quaternion.LookRotation(new Vector3(_InputVector.x, 0, _InputVector.z)), _RotateSpeed);
    }
}