using Collectables;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelGenerator : MonoBehaviour
{
    [Header("Border Settings")]
    [SerializeField] private float _startZPosition;
    [SerializeField] private float _endZPosition;
    [SerializeField] private float _leftBorder = -2f;  // Sol border konumu
    [SerializeField] private float _rightBorder = 2f; // Sað border konumu

    [Header("Prefabs")]
    [SerializeField] private Range _rangePrefab;
    [SerializeField] private Rate _ratePrefab;
    [SerializeField] private BulletCount _bulletCountPrefab;

    [Header("Spawn Settings")]
    [SerializeField] private float _rangeSpawnDistance;
    [SerializeField] private float _rateSpawnDistance;
    [SerializeField] private float _bulletCountSpawnDistance;
    private TextMeshProUGUI rangeAmountText;
    private TextMeshProUGUI rateAmountText;
    private TextMeshProUGUI _bulletCountAmountText;

    private void Start()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        int rangeSpawnCount = Mathf.FloorToInt((_endZPosition - _startZPosition) / _rangeSpawnDistance);
        int rateSpawnCount = Mathf.FloorToInt((_endZPosition - _startZPosition) / _rateSpawnDistance);
        int bulletCountSpawnCount = Mathf.FloorToInt((_endZPosition - _startZPosition) / _bulletCountSpawnDistance);

        for (int i = 1; i <= rangeSpawnCount; i++)
        {
            Range range = Instantiate(_rangePrefab);
            int horizontalRange = Random.Range(0, 2);
            float horizontalRangePos =0;
            if (horizontalRange == 0)
                horizontalRangePos = _leftBorder;
            else horizontalRangePos = _rightBorder;
            Vector3 spawnPosition = new Vector3(horizontalRangePos, 1, _startZPosition + _rangeSpawnDistance * i);
            range.transform.position = spawnPosition;
            rangeAmountText = range.GetComponentInChildren<TextMeshProUGUI>();
            int x = Random.Range(0,10);
            rangeAmountText.text = x.ToString();


        }

        for (int i = 1; i <= rateSpawnCount; i++)
        {
            Rate rate = Instantiate(_ratePrefab);
            int horizontalRate = Random.Range(0, 2);
            float horizontalRatePos = 0;
            if (horizontalRate == 0)
                horizontalRatePos = _leftBorder;
            else horizontalRatePos = _rightBorder;
            Vector3 spawnPosition = new Vector3(horizontalRatePos, 1, _startZPosition + _rateSpawnDistance * i);
            rate.transform.position = spawnPosition;
            rateAmountText = rate.GetComponentInChildren<TextMeshProUGUI>();
            int x = Random.Range(0, 10);
            rateAmountText.text = x.ToString();


        }
        for (int i = 1; i <= bulletCountSpawnCount; i++)
        {
            BulletCount bulletCount = Instantiate(_bulletCountPrefab);
            int horizontalBulletCount = Random.Range(0, 2);
            float horizontalBulletCountPos = 0;
            if (horizontalBulletCount == 0)
                horizontalBulletCountPos = _leftBorder;
            else horizontalBulletCountPos = _rightBorder;
            Vector3 spawnPosition = new Vector3(horizontalBulletCountPos, 1, _startZPosition + _bulletCountSpawnDistance * i);
            bulletCount.transform.position = spawnPosition;
            _bulletCountAmountText = bulletCount.GetComponentInChildren<TextMeshProUGUI>();
            int x = Random.Range(-2, 4);
            _bulletCountAmountText.text = x.ToString();


        }
    }

   
}
