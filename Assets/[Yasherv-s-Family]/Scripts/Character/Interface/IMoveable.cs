using UnityEngine;

namespace Character
{
    public interface IMoveable
    {
        void Move(Vector3 position);
        bool ReachedDestination();
        void Stop();
        void StopAndStartDelay(float delay);
        void BackJump();
    }
}