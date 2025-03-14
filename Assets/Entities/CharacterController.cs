using KinematicCharacterController;
using UnityEngine;

public class CharacterController : MonoBehaviour, ICharacterController
{
    [SerializeField]
    KinematicCharacterMotor characterMotor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterMotor.CharacterController = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region ICharacterController
    public void AfterCharacterUpdate(float deltaTime)
    {
        //throw new System.NotImplementedException();
    }

    public void BeforeCharacterUpdate(float deltaTime)
    {
        //throw new System.NotImplementedException();
    }

    public bool IsColliderValidForCollisions(Collider coll)
    {
        // throw new System.NotImplementedException();
        return true;
    }

    public void OnDiscreteCollisionDetected(Collider hitCollider)
    {
        //throw new System.NotImplementedException();
    }

    public void OnGroundHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
    {
        //throw new System.NotImplementedException();
    }

    public void OnMovementHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
    {
        //throw new System.NotImplementedException();
    }

    public void PostGroundingUpdate(float deltaTime)
    {
        //throw new System.NotImplementedException();
    }

    public void ProcessHitStabilityReport(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, Vector3 atCharacterPosition, Quaternion atCharacterRotation, ref HitStabilityReport hitStabilityReport)
    {
        //throw new System.NotImplementedException();
    }

    public void UpdateRotation(ref Quaternion currentRotation, float deltaTime)
    {
        //throw new System.NotImplementedException();
    }

    public void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime)
    {
       // throw new System.NotImplementedException();
    }
    #endregion
}
