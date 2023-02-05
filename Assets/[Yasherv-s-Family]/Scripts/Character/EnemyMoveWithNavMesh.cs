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

        // public Vector3[] WayPoints;
        private Coroutine _wayPointCoroutine,_searchEnemyCoroutine;
        public TriggerArea<Player> _triggerArea;
        private Player targetEnemy;
        private bool stop;
        public LineRenderer lineRenderer;
        public Health Health;
        
        private Attacker _attacker;

        private void Awake()
        {
            startPos = transform.position;
            _attacker = GetComponent<Attacker>();
        }

        public void Start()
        {
            NavAgent.speed = MoveData.Speed;
            StartRoute();
        }

        private void FixedUpdate()
        {
            if (stop)
                return;

            targetEnemy = _triggerArea.GetTarget();
            if (targetEnemy != null)
            {
                Move(targetEnemy.transform.position);
                lineRenderer.positionCount = 2;
                lineRenderer.SetPositions(new[] {transform.position+ new Vector3(0,1,0), targetEnemy.transform.position});
                _attacker.Attack(targetEnemy.GetComponent<IDamageable>());
            }
            else if (_wayPointCoroutine == null)
            {
                lineRenderer.positionCount = 0;
                Move(startPos);
                // _wayPointCoroutine = StartCoroutine(AIUpdater());
            }
        }

        public float raidus;
        // private IEnumerator AIUpdater()
        // {
        //     lineRenderer.positionCount = 0;
        //     _attacker.Attack(null);
        //     while (!targetEnemy)
        //     {
        //         Move(RandWalkPosition());
        //         yield return new WaitUntil(ReachedDestination);
        //     }
        //     
        //     StopCoroutine(_wayPointCoroutine);
        //     _wayPointCoroutine = null;
        // }
        
        public void Move(Vector3 position)
        {
            NavAgent.SetDestination(position);
        }

        public bool ReachedDestination()
        {
            return Vector3.Distance(transform.position, NavAgent.destination) > .5f;
        }

        public void Stop()
        {
            lineRenderer.positionCount = 0;

            stop = true;
            if (_wayPointCoroutine != null)
                StopCoroutine(_wayPointCoroutine);

            _wayPointCoroutine = null;
            NavAgent.SetDestination(transform.position);
            NavAgent.isStopped = true;
        }

        private Vector3 startPos;
        public Vector3 RandWalkPosition()
        {
            var rand = UnityEngine.Random.insideUnitSphere * raidus;
            rand.y = startPos.y;
            Debug.Log(startPos + rand);
            return startPos + rand;
        }
        
        public void StopAndStartDelay(float delay)
        {
            Stop();
            StartCoroutine(DelayStarter(delay));
        }
        
        IEnumerator DelayStarter(float delay)
        {
            yield return new WaitForSeconds(delay);
            StartRoute();
        }

        public void StartRoute()
        {
            stop = false;
            NavAgent.isStopped = false;
        }

        public void StopRoute()
        {
            if (_wayPointCoroutine != null)
            {
                StopCoroutine(_wayPointCoroutine);
            }
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
            // if (WayPoints == null) return;
            // for (int i = 0; i < WayPoints.Length; i++)
            // {
            //     Gizmos.color = Color.red;
            //     Gizmos.DrawSphere(WayPoints[i], 0.5f);
            //     
            //     Gizmos.color = Color.magenta;
            //     
            //     
            //     if (i != WayPoints.Length -1)
            //         Gizmos.DrawLine(WayPoints[i], WayPoints[(i + 1)]);
            //     
            // }

            if(_triggerArea == null) return;
            Gizmos.color = Color.green; 
            Gizmos.DrawWireSphere(transform.position, _triggerArea.Radius);
        }
    }
}