using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ParticleEffectShowcase
{
    public class EffectShowcaser : MonoBehaviour
    {
        public TMP_Text EffectNameText;
        protected ParticleSystem _effectInstance;

        public void Hide()
        {
            if (_effectInstance != null)
            {
                Destroy(_effectInstance.gameObject);
                _effectInstance = null;
            }
            gameObject.SetActive(false);
        }

        public void Show(ParticleSystem particleSystem)
        {
            gameObject.SetActive(true);
            _effectInstance = Instantiate(particleSystem, this.gameObject.transform.position, Quaternion.identity);
            var main = _effectInstance.main;
            main.loop = true;
            _effectInstance.Play();
            EffectNameText.text = particleSystem.gameObject.name;
        }
    }

}
