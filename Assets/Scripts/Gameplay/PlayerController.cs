using Enums;
using Managers;
using UnityEngine;

namespace Gameplay
{
    public class PlayerController : MonoBehaviour
    {
        private GameManager _gameManager;
        private Vector3 _offset;
        private Rigidbody2D _rb2D;
        private PolygonCollider2D _collider2D;
        private bool _isDragging;
        private BonusHandler _bonusHandler;

        private void Awake()
        {
            _gameManager = GameManager.Instance;
            _rb2D = GetComponent<Rigidbody2D>();
            _collider2D = GetComponent<PolygonCollider2D>();
            _bonusHandler = BonusHandler.Instance;
        }

        private void FixedUpdate()
        {
            _collider2D.isTrigger = !_bonusHandler.IsBonusActive(BonusType.HarmlessWalls);
            if (_isDragging)
            {
                Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + _offset;
                _rb2D.MovePosition(new Vector3(newPosition.x, newPosition.y, transform.position.z));
            }
        }

        private void OnMouseDown()
        {
            _gameManager.OnStartPlaying();
            _offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        private void OnMouseDrag()
        {
            _isDragging = true;
        }

        private void OnMouseUp()
        {
            if (_gameManager.GameState == GameState.Playing)
            {
                _isDragging = false;
                _gameManager.OnLoss();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Finish"))
            {
                Destroy(gameObject);
            }
            else if (other.CompareTag("Wall") && !BonusHandler.Instance.IsBonusActive(BonusType.HarmlessWalls))
            {
                Destroy(gameObject);
                _gameManager.OnLoss();
            }
        }
    }
}