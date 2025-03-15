using KinematicCharacterController;
using UnityEngine;

public struct MovementInputs
{
    public Vector2 moveAxis;
    public Quaternion aimRotation;
}

public class CharacterController : MonoBehaviour, ICharacterController
{
    [SerializeField]
    KinematicCharacterMotor _characterMotor;

    [SerializeField]
    public float _moveSpeed, _gravity;

    //current movement and aim directions
    Vector3 _movementInputVector;
    Vector3 _aimInputVector;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _characterMotor.CharacterController = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetInputs(MovementInputs inputs)
    {
        //raw movement inputs
        _movementInputVector = Vector3.ClampMagnitude(new Vector3(inputs.moveAxis.x, 0, inputs.moveAxis.y), 1f);

        //convert based on camera's current up direction and horizontal rotation
        //forward direction relative to character's up vector
        Vector3 cameraPlanarDirection = Vector3.ProjectOnPlane(inputs.aimRotation * Vector3.forward, _characterMotor.CharacterUp).normalized;
        if (cameraPlanarDirection.sqrMagnitude == 0f)
        {
            cameraPlanarDirection = Vector3.ProjectOnPlane(inputs.aimRotation * Vector3.up, _characterMotor.CharacterUp).normalized;
        }
        //used to rotate the movements to match the look direction
        Quaternion cameraPlanarRotation = Quaternion.LookRotation(cameraPlanarDirection, _characterMotor.CharacterUp);

        // Move and look inputs
        _movementInputVector = cameraPlanarRotation * _movementInputVector;
        _aimInputVector = cameraPlanarDirection;
    }

    #region ICharacterController
    public void BeforeCharacterUpdate(float deltaTime)
    {
        // This is called before the motor does anything
    }

    // This is called when the motor wants to know what its rotation should be right now
    public void UpdateRotation(ref Quaternion currentRotation, float deltaTime)
    {
        currentRotation = Quaternion.LookRotation(_aimInputVector, _characterMotor.CharacterUp);
    }

    // This is called when the motor wants to know what its velocity should be right now
    public void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime)
    {
        Vector3 targetMovementVelocity;
        //if grounded
        if (_characterMotor.GroundingStatus.IsStableOnGround)
        {
            // Calculate target velocity
            Vector3 inputRight = Vector3.Cross(_movementInputVector, _characterMotor.CharacterUp);
            Vector3 reorientedInput = Vector3.Cross(_characterMotor.GroundingStatus.GroundNormal, inputRight).normalized * _movementInputVector.magnitude;
            targetMovementVelocity = reorientedInput * _moveSpeed;
            currentVelocity = targetMovementVelocity;
        }
        else
        {
            targetMovementVelocity = _movementInputVector * _moveSpeed;
            currentVelocity = targetMovementVelocity;
            currentVelocity -= _characterMotor.CharacterUp * _gravity * deltaTime;
        }
    }

    public void AfterCharacterUpdate(float deltaTime)
    {
        // This is called after the motor has finished everything in its update
    }

    public bool IsColliderValidForCollisions(Collider coll)
    {
        // This is called after when the motor wants to know if the collider can be collided with (or if we just go through it)
        return true;
    }

    public void OnGroundHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
    {
        // This is called when the motor's ground probing detects a ground hit
    }

    public void OnMovementHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
    {
        // This is called when the motor's movement logic detects a hit
    }

    public void ProcessHitStabilityReport(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, Vector3 atCharacterPosition, Quaternion atCharacterRotation, ref HitStabilityReport hitStabilityReport)
    {
        // This is called after every hit detected in the motor, to give you a chance to modify the HitStabilityReport any way you want
    }

    public void PostGroundingUpdate(float deltaTime)
    {
        // This is called after the motor has finished its ground probing, but before PhysicsMover/Velocity/etc.... handling
    }

    public void OnDiscreteCollisionDetected(Collider hitCollider)
    {
        // This is called by the motor when it is detecting a collision that did not result from a "movement hit".
    }
    #endregion
}
