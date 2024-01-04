using UnityEngine;

namespace Gameplay
{
    public class Wall : MonoBehaviour
    {
        [SerializeField] private bool _isRotatingClockwise;
        [SerializeField] private float _rotationSpeed;
        
        private void Update()
        {
            if (_isRotatingClockwise)
            {
                transform.Rotate(Vector3.back * (_rotationSpeed * Time.deltaTime));
            }
            else
            {
                transform.Rotate(Vector3.forward * (_rotationSpeed * Time.deltaTime));
            }
        }

        public void ChangeSpeedScale(float scale)
        {
            _rotationSpeed *= scale;
        }
    }
}