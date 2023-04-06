using System.Collections;
using UnityEngine;

namespace Enemies
{
    public class AIController : MonoBehaviour
    {
        private enum State
        {
            Roaming
        }

        private State state;
        private AIPathfinding aiPathfinding;

        private void Awake()
        {
            aiPathfinding = GetComponent<AIPathfinding>();
            state = State.Roaming;
        }
        
        private void Start()
        {
            StartCoroutine(RoamingRoutine());
        }

        private IEnumerator RoamingRoutine()
        {
            while (state == State.Roaming)
            {
                var roamPosition = GetRoamingPosition();
                aiPathfinding.MoveTo(roamPosition);
                yield return new WaitForSeconds(2f);
            }
        }
        
        private Vector2 GetRoamingPosition()
        {
            return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        }
    }
}

