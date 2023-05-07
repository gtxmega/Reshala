using DG.Tweening;
using Services.Events;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Data
{
    public class CatActor : Actor
    {
        [SerializeField] private NavMeshAgent _agent;

        [Header("Animation")]
        [SerializeField] private float _offsetY;
        [SerializeField] private float _moveDuration;
        [SerializeField] private Ease _moveEase;
        [SerializeField] private float _rotateDuration;
        [Space]
        [SerializeField] private Ease _rotateEase;
        [Space]
        [SerializeField] private float _scaleDuration;
        [SerializeField] private Ease _scaleEase;
        [Space]
        [SerializeField] private float _delayWinAnim;

        private IGameEvents _gameEvents;

        [Inject]
        private void Construction(IGameEvents gameEvents)
        {
            _gameEvents = gameEvents;
            _gameEvents.LevelWin += OnLevelWin;
        }

        private void OnLevelWin()
        {
            StartCoroutine(DelayAnim());
        }

        private IEnumerator DelayAnim()
        {
            yield return new WaitForSeconds(_delayWinAnim);

            PlayWinAnim();
        }

        public void PlayWinAnim()
        {
            _agent.enabled = false;

            var endMovePosition = _selfTransform.position + (Vector3.up * _offsetY);

            _selfTransform
                .DOMove(endMovePosition, _moveDuration)
                .SetEase(_moveEase)
                .SetLink(gameObject);

            _selfTransform
                .DORotate(new Vector3(0.0f, 180.0f, 0.0f), _rotateDuration, RotateMode.FastBeyond360)
                .SetEase(_rotateEase)
                .SetLink(gameObject);

            _selfTransform
                .DOScale(Vector3.one * 2, _scaleDuration)
                .SetEase(_scaleEase)
                .SetLink(gameObject);
        }

        private void OnDestroy()
        {
            _gameEvents.LevelWin -= OnLevelWin;
        }
    }
}