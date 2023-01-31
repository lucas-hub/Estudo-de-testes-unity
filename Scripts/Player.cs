using UnityEngine;

namespace InfallibleCode
{
    public class Player : MonoBehaviour
    {
        private Sheep _sheep;

        private void Awake()
        {
            _sheep = GetComponent<Sheep>();
        }
        
        private void Update()
        {
            var moveVector = Vector2.zero;

            if (Input.GetKey(KeyCode.W))
            {
                moveVector += Vector2.up;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                moveVector += Vector2.down;
            }

            if (Input.GetKey(KeyCode.A))
            {
                moveVector += Vector2.left;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveVector += Vector2.right;
            }

            if (moveVector == Vector2.zero) return;

            var direction = Direction.NearestFromVector(moveVector);
            
            _sheep.Move(direction);
        }
    }
}