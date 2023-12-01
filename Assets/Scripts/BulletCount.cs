using Player;
using TMPro;
using UnityEngine;

namespace Collectables
{
    public class BulletCount : BulletChanger
    {
        protected override void Awake()
        {
            Debug.Log("Range Awake");
            base.Awake();
        }

        protected override void OnTriggerEnter(Collider other)
        {
            // Çarpan nesnenin bir BulletComponent içerip içermediðini kontrol et
            if (other.gameObject.TryGetComponent(out BulletComponent bullet))
            {
                // Bulunduðumuz nesnenin TextMeshProUGUI bileþenine eriþ ve deðerini 1 arttýr
                TextMeshProUGUI textMesh = GetComponentInChildren<TextMeshProUGUI>();
                if (textMesh != null)
                {
                    // Text'i integer'a dönüþtür ve bir arttýr
                    if (int.TryParse(textMesh.text, out int currentValue))
                    {
                        int newValue = currentValue;
                        // Yeni deðeri text olarak ayarla
                        textMesh.text = newValue.ToString();

                        // Çarpan Bullet objesini yok et
                        Destroy(other.gameObject);

                    }
                    else
                    {
                        Debug.LogError("Failed to parse the text as an integer.");
                    }
                }
                else
                {
                    Debug.LogError("There is no TextMeshProUGUI component in the child objects of this game object.");
                }
            }

            else if (other.gameObject.TryGetComponent(out BulletCount bulletCount))
            {
                Debug.Log("Range.");

                GameObject.Destroy(gameObject);
            }
            else
            {
                //  Debug.Log("a");
            }
        }


    }
}
