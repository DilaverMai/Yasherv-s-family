using UnityEngine;

namespace Character
{
    [CreateAssetMenu(fileName = "ContollerData", menuName = "Character/ContollerData", order = 0)]
    public class ContollerData: ScriptableObject
    {
        public float MoveSpeed;
        public float Gravity;
        public float MaxSpeed;
    }
}