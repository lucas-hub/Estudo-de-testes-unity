using System;
using UnityEngine;

namespace InfallibleCode
{
    [Serializable]
    public struct MinMax
    {
        [SerializeField] private float min;
        [SerializeField] private float max;

        public float Min
        {
            get => min;
            set => min = value;
        }

        public float Max
        {
            get => max;
            set => max = value;
        }

        public float RandomValue => UnityEngine.Random.Range(this.min, this.max);

        public MinMax(float min, float max)
        {
            this.min = min;
            this.max = max;
        }

        public float Clamp(float value)
        {
            return Mathf.Clamp(value, min, max);
        }
    }
}