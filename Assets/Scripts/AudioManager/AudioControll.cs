using Services.Progress;
using System.Collections;
using TMPro;
using UnityEngine;
using Zenject;

namespace AudioManager
{
    public class AudioControll : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        private PlayerProgress _playerProgress;

        [Inject]
        private void Construction(PlayerProgress playerProgress)
        {
            _playerProgress = playerProgress;

            _audioSource.loop = true;

            if(_playerProgress.ProgressData.IsVolume)
            {
                _audioSource.Play();
            }else
            {
                _audioSource.Stop();
            }
        }
    }
}