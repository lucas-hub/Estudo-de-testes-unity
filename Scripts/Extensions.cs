using UnityEngine;

namespace InfallibleCode
{
    public static class Extensions
    {
        public static Vector3 Round(this Vector3 vector)
        {
            return new Vector3(
                Mathf.Round(vector.x),
                Mathf.Round(vector.y),
                Mathf.Round(vector.z)
            );
        }

        public static Vector3 SnapTo(this Vector3 vector, float snapAngle)
        {
            var angle = Vector3.Angle(vector, Vector3.up);
            if (angle < snapAngle / 2.0f)
            {
                return Vector3.up * vector.magnitude;
            }

            if (angle > 180.0f - snapAngle / 2.0f)
            {
                return Vector3.down * vector.magnitude;
            }

            var t = Mathf.Round(angle / snapAngle);
            var deltaAngle = (t * snapAngle) - angle;

            var axis = Vector3.Cross(Vector3.up, vector);
            var q = Quaternion.AngleAxis(deltaAngle, axis);
            
            return q * vector;
        }


        public static bool HasComponent<T>(this Component component) where T : Component
        {
            return component.GetComponent<T>() != null;
        }
    }
}