using System;
using DG.Tweening;
using UnityEngine;

namespace InfallibleCode
{
    public class Sheep : MonoBehaviour
    {
        public const float JumpPower = 0.75f;
        public const float JumpDuration = 0.33f;

        private SpriteRenderer _spriteRenderer;
        private bool _isMoving;

        public event Action<Sheep> EnteredPen;

        public void Move(Direction direction)
        {
            if (_isMoving) return;

            _isMoving = true;

            UpdateSprite(direction);

            var destination = transform.position + direction.Vector;
            
            transform.DOJump(destination, JumpPower, 1, JumpDuration)
                .OnComplete(() => _isMoving = false);
        }

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void UpdateSprite(Direction direction)
        {
            if (direction == Direction.None) return;
            _spriteRenderer.flipX = direction.IsFacingLeft;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnEnteredPen(this);
        }

        private void OnEnteredPen(Sheep sheep)
        {
            EnteredPen?.Invoke(this);
        }
    }
}