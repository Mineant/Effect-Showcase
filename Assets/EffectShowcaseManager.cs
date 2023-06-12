using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ParticleEffectShowcase
{
    public class EffectShowcaseManager : MonoBehaviour
    {
        public List<EffectShowcaser> Showcasers;
        public List<GameObject> Effects;
        public Button NextSetButton;
        public Button PreviousSetButton;
        public TMP_Text CurrentPageText;

        protected List<ParticleSystem> _effects;
        public int CurrentSet;
        protected int _showcasersPerSet;

        void Awake()
        {
            NextSetButton.onClick.AddListener(NextSet);
            PreviousSetButton.onClick.AddListener(PreviousSet);

            _effects = new();
            foreach (var item in Effects)
            {
                if (item.TryGetComponent<ParticleSystem>(out var ps)) _effects.Add(ps);
            }
        }

        void Start()
        {
            _showcasersPerSet = Showcasers.Count;
            ChangeSet(0);
        }

        private void NextSet()
        {
            ChangeSet(1);
        }
        private void PreviousSet()
        {
            ChangeSet(-1);
        }

        private void ChangeSet(int value)
        {
            int totalPages = _effects.Count / _showcasersPerSet;
            CurrentSet = Math.Clamp(CurrentSet + value, 0, totalPages);
            foreach (var item in Showcasers)
            {
                item.Hide();
            }

            for (int i = 0; i < _showcasersPerSet; i++)
            {
                int index = CurrentSet * _showcasersPerSet + i;
                if (index >= _effects.Count) break;

                Showcasers[i].Show(_effects[index]);
            }

            CurrentPageText.text = $"Page {CurrentSet + 1} / {totalPages + 1}";
        }


    }

}
