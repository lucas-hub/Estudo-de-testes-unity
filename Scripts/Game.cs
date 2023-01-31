using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace InfallibleCode
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreLabel;
        [SerializeField] private List<Sheep> _sheep;
        
        public int _score;

        private void OnEnable()
        {
            for (var i = _sheep.Count - 1; i >= 0; i--)
            {
                var sheep = _sheep[i];
                sheep.EnteredPen += OnEnteredPen;
            }
        }

        private void OnEnteredPen(Sheep sheep)
        {
            _score++;
            scoreLabel.text = $"{_score:0}";
        }

        private void OnDisable()
        {
            for (var i = _sheep.Count - 1; i >= 0; i--)
            {
                var sheep = _sheep[i];
                sheep.EnteredPen -= OnEnteredPen;
            }
        }
    }
}
