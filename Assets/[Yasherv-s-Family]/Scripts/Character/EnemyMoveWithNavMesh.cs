using System;
using System.Collections;
using _Yasherv_s_Family_.Scripts.Character;
using _Yasherv_s_Family_.Scripts.Character.Attack;
using _Yasherv_s_Family_.Scripts.Character.Player;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

namespace Character
{
    [Serializable]
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyMoveWithNavMesh:MonoBehaviour,IMoveable,IRoute
    {
        public MoveData MoveData;
        public NavMeshAgent NavAgent;

        public Vector3[] WayPoints;
        private Coroutine _wayPointCoroutine,_searchEnemyCoroutine;
        public TriggerArea<Player> _triggerArea;
        private Player targetEnemy;
        private bool stop;
        public LineRenderer lineRenderer;
        
        
        private Attacker _attacker;

        private void Awake()
        {
            _attacker = GetComponent<Attacker>();
        }

        public void Start()
        {
            NavAgent.speed = MoveData.Speed;
            StartRoute();
        }

        private void FixedUpdate()
        {
            if(stop) return;
            
            targetEnemy = _triggerArea.GetTarget();

            if (targetEnemy != null)
            {
                Move(targetEnemy.transform.position);
                lineRenderer.positionCount = 2;
                lineRenderer.SetPositions(new[] {transform.position+ new Vector3(0,1,0), targetEnemy.transform.position});
                _attacker.Attack(targetEnemy.GetComponent<IDamageable>());
                if (_wayPointCoroutine == null) return;
                StopCoroutine(_wayPointCoroutine);
                _wayPointCoroutine = null;
            }
            else if (_wayPointCoroutine == null)
            {
                _wayPointCoroutine = StartCoroutine(AIUpdater());
                lineRenderer.positionCount = 0;
                _attacker.Attack(null);

            }
        }
        
        private IEnumerator AIUpdater()
        {
            var wayPointIndex = 0;
            
            while (!targetEnemy)
            {
                targetEnemy = _triggerArea.GetTarget();
                Move(WayPoints[wayPointIndex]);
                yield return new WaitUntil(()=> ReachedDestination());
                yield return new WaitForSeconds(.25f);
                wayPointIndex++;
                
                if (wayPointIndex >= WayPoints.Length)
                    wayPointIndex = 0;
            }
            
            _wayPointCoroutine = null;
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
            stop = true;
            if (_wayPointCoroutine != null)
                StopCoroutine(_wayPointCoroutine);

            _wayPointCoroutine = null;
            NavAgent.SetDestination(transform.position);
            NavAgent.isStopped = true;
        }

        public void StopAndStartDelay(float delay)
        {
            Stop();
            StartCoroutine(DelayStarter(delay));
        }
        
        IEnumerator DelayStarter(float delay)
        {
            yield return new WaitForSeconds(delay);
            StartCoroutine(AIUpdater());
            StartRoute();
        }

        public void StartRoute()
        {
            stop = false;
            _wayPointCoroutine = StartCoroutine(AIUpdater());
        }

        public void StopRoute()
        {
            StopCoroutine(_wayPointCoroutine);
            _wayPointCoroutine = null;
        }
        
        [Button]
        public void BackJump()
        {
            NavAgent.isStopped = true;
            transform.DOJump(transform.position + transform.forward * -2, 1, 1, .5f).OnComplete(() => NavAgent.isStopped = false);
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
                    Gizmos.DrawLine(WayPoints[i], WayPoints[(i + 1)]);
                
            }
            
            if(_triggerArea == null) return;
            Handles.color = Color.red;
            Handles.DrawWireDisc(transform.position,Vector3.down, _triggerArea.Radius,10f);
        }
    }
}