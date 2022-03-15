using UnityEngine;

namespace _Internal.CameraLogic
{
    public class Follower : MonoBehaviour
    {
        public Transform Target;
        public float RotationAngleX;
        public float Distance;
        public float OffsetY;

        private void LateUpdate()
        {
            if (Target == null)
                return;

            Follow();
        }

        private void Follow()
        {
            var rotation = Quaternion.Euler(RotationAngleX, 0f, 0f);
            var position = rotation * new Vector3(0f, 0f, -Distance) + GetFollowingPointPosition();

            transform.rotation = rotation;
            transform.position = position;
        }

        private Vector3 GetFollowingPointPosition()
        {
            var followingPosition = Target.position;
            followingPosition.y += OffsetY;
            
            return followingPosition;
        }
    }
}