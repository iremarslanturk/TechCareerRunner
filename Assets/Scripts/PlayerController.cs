using Collectables;
using System;
using TMPro;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public int rangeChange;
        public bool rangeChangeSit;
        public int rateChange;
        public bool rateChangeSit;
        public int bulletCountChange;
        public bool bulletCountChangeSit;
        public event Action<int> HelperValueChanged;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Collectables.Range range))
            {
                TextMeshProUGUI textMesh = range.GetComponentInChildren<TextMeshProUGUI>();
                Debug.Log("Parsed value: " + textMesh.text);

                rangeChange = int.Parse(textMesh.text);
                Debug.Log("_bulletChange after assignment: " + rangeChange);
                rangeChangeSit = true;
                HelperValueChanged?.Invoke(rangeChange);
                Destroy(range.gameObject);
            }
            if (other.gameObject.TryGetComponent(out Collectables.Rate rate))
            {
                TextMeshProUGUI textMesh = rate.GetComponentInChildren<TextMeshProUGUI>();
                Debug.Log("Parsed value: " + textMesh.text);

                rateChange = int.Parse(textMesh.text);
                Debug.Log("_bulletChange after assignment: " + rateChange);
                rateChangeSit = true;
                HelperValueChanged?.Invoke(rateChange);
                Destroy(rate.gameObject);
            }
            if (other.gameObject.TryGetComponent(out Collectables.BulletCount bulletCount))
            {
                TextMeshProUGUI textMesh = bulletCount.GetComponentInChildren<TextMeshProUGUI>();
                Debug.Log("Parsed value: " + textMesh.text);

                bulletCountChange = int.Parse(textMesh.text);
                Debug.Log("_bulletChange after assignment: " + bulletCount);
                bulletCountChangeSit = true;
                HelperValueChanged?.Invoke(bulletCountChange);
                Destroy(bulletCount.gameObject);
            }


        }
    }
}
