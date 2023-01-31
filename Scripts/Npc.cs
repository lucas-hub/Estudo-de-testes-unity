using System;
using UnityEngine;

namespace InfallibleCode
{
    public class Npc : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] [MinMaxSlider(1, 20)] private MinMax followDistance;

        private Sheep _sheep;

        private void Awake()
        {
            _sheep = GetComponent<Sheep>();
        }

        private void Start()
        {
            _sheep.EnteredPen += sheep => enabled = false;
        }

        private void Update()
        {
            if (!InFollowingRange) return;
            
            var moveVector = player.transform.position - transform.position;
            var direction = Direction.NearestFromVector(moveVector);
            _sheep.Move(direction);
        }

        private float DistanceFromPlayer =>
            Vector2.Distance(transform.position, player.transform.position);

        private bool InFollowingRange =>
            DistanceFromPlayer >= followDistance.Min && DistanceFromPlayer <= followDistance.Max;
    }
}