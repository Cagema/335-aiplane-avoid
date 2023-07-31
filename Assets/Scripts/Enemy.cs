
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _speedRotation;

    Transform _playerTr;
    Vector3 _randomPoint;
    Quaternion _rotation;

    private void Start()
    {
        _playerTr = FindObjectOfType<PlayerController>().transform;
        _randomPoint = _playerTr.position + (Vector3)Random.insideUnitCircle * 0.3f;
    }

    private void Update()
    {
        if (GameManager.Single.GameActive)
        {
            _rotation = Quaternion.LookRotation(Vector3.forward, _playerTr.position + _randomPoint - transform.position);

            //_rotation = Quaternion.LookRotation(Vector3.forward, _playerTr.position + _randomPoint);
            transform.rotation = Quaternion.Lerp(transform.rotation, _rotation, _speedRotation * Time.deltaTime);
            transform.Translate(_speed * Time.deltaTime * Vector3.up);
        }
    }
}
