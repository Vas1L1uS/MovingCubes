using UnityEngine;

public class SpawnCubeController : MonoBehaviour
{
    [Header("Обьект в котором будут спавнится кубы")]
    [SerializeField] private Transform _parrent;
    [Header("Префаб куба")]
    [SerializeField] private GameObject _prefabCube;

    public float TimeToSpawn { get; set; }

    private float _currentTime = 0;

    private void Awake()
    {
        TimeToSpawn = 5; // Настройки по умолчанию
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;
        if (TimeToSpawn - _currentTime <= 0)
        {
            Instantiate(_prefabCube, Vector3.zero, Quaternion.Euler(0, 0, 0), _parrent);
            _currentTime = 0;
        }
    }
}