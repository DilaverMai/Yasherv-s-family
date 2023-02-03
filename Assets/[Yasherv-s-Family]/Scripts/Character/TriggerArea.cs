using System.Linq;
using UnityEngine;

namespace Character
{
    [System.Serializable]
    public class TriggerArea<T> where T: Component
    {
        public float Radius;
        public Transform Transform;
        
        public TriggerArea(float radius, Transform transform)
        {
            Radius = radius;
            Transform = transform;
        }

        public T GetTarget()
        {
            var colliders = Physics.OverlapSphere(Transform.position, Radius);
            return colliders.Select(collider => collider.GetComponent<T>()).FirstOrDefault(target => target != null);
        }

    }
}