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
            // �arpan nesnenin bir BulletComponent i�erip i�ermedi�ini kontrol et
            if (other.gameObject.TryGetComponent(out BulletComponent bullet))
            {
                // Bulundu�umuz nesnenin TextMeshProUGUI bile�enine eri� ve de�erini 1 artt�r
                TextMeshProUGUI textMesh = GetComponentInChildren<TextMeshProUGUI>();
                if (textMesh != null)
                {
                    // Text'i integer'a d�n��t�r ve bir artt�r
                    if (int.TryParse(textMesh.text, out int currentValue))
                    {
                        int newValue = currentValue;
                        // Yeni de�eri text olarak ayarla
                        textMesh.text = newValue.ToString();

                        // �arpan Bullet objesini yok et
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
