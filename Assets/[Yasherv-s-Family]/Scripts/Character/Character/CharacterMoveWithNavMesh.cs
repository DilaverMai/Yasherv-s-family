using System;
using UnityEngine;
using UnityEngine.AI;

namespace Character
{
    [System.Serializable]
    [RequireComponent(typeof(NavMeshAgent))]
    public class CharacterMoveWithNavMesh:MonoBehaviour,IMoveable,IRoute
    {
        public MoveData MoveData;
        public NavMeshAgent NavAgent;

        public Vector3[] WayPoints;
    
        public void Start()
        {
            NavAgent.speed = MoveData.Speed;
        }

        public void Move(Vector3 position)
        {
            NavAgent.SetDestination(position);
        }

        public bool ReachedDestination()
        {
            return NavAgent.remainingDistance <= NavAgent.stoppingDistance;
        }

        public void Stop()
        {
            NavAgent.SetDestination(transform.position);
            NavAgent.isStopped = true;
        }

        private void OnDrawGizmos()
        {
            if (WayPoints == null) return;
            for (int i = 0; i < WayPoints.Length; i++)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(WayPoints[i], 0.5f);
                
                Gizmos.color = Color.magenta;
                if (i != WayPoints.Length -1)
                {
                    Gizmos.DrawLine(WayPoints[i], WayPoints[(i + 1)]);
                }
            }
        }
    }

    public interface IRoute
    {
        
    }
}