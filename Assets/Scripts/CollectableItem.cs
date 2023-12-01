using UnityEngine;

namespace Collectables
{
    public abstract class CollectableItem : MonoBehaviour
    {
        [SerializeField] protected ParticleSystem _particleSystem;
   

        protected AudioSource AudioSource;

        protected virtual void Awake()
        {
            Debug.Log("CollectableItem Awake");
            AudioSource = GetComponent<AudioSource>();
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            PlayParticle();

        }

        private void PlayParticle()
        {
            _particleSystem.Play();
        }
    }
}
