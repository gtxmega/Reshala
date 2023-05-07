using DG.Tweening;
using Services.Events;
using Services.Selector;
using TMPro;
using UnityEngine;
using Zenject;

namespace Data
{
    public class CubeActor : Actor, ISelected
    {
        public bool IsInteractive => _interactive;

        [Header("Data")]
        [SerializeField] private MathData _mathData;

        [Header("Graphics")]
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private Color _baseColor;
        [SerializeField] private Color _trueColor;
        [SerializeField] private Color _falseColor;

        [Header("Animation")]
        [SerializeField] private float _rotateDuration;
        [SerializeField] private Ease _rotateEase;
        [Space]
        [SerializeField] private float _scaleDuration;
        [SerializeField] private Ease _scaleEase;
        [Space]
        [SerializeField] private float _offsetY;
        [SerializeField] private float _moveDuration;
        [SerializeField] private Ease _moveEase;

        [Header("References")]
        [SerializeField] private TMP_Text _titleText;

        private bool _interactive;

        private void Awake()
        {
            _meshRenderer.material.color = _baseColor;
            ShowText();
        }

        public ref MathData GetMathData() => ref _mathData;

        private void ShowText()
        {
            string operatorText = string.Empty;

            switch (_mathData.Operator)
            {
                case EMathOperator.ADDING:
                    operatorText = "+";
                    break;
                case EMathOperator.SUBTRACT:
                    operatorText = "-";
                    break;
                case EMathOperator.MULTIPLY:
                    operatorText = "*";
                    break;
                case EMathOperator.DIVIDE:
                    operatorText = "/";
                    break;
            }

            _titleText.text = _mathData.A.ToString() + " " + operatorText + " " + _mathData.B.ToString();
        }

        public void EnableInteractive() => _interactive = true;

        public void DisableInteractive() => _interactive = false;

        public string GetMathString()
        {
            string operatorText = string.Empty;

            switch (_mathData.Operator)
            {
                case EMathOperator.ADDING:
                    operatorText = "+";
                    break;
                case EMathOperator.SUBTRACT:
                    operatorText = "-";
                    break;
                case EMathOperator.MULTIPLY:
                    operatorText = "*";
                    break;
                case EMathOperator.DIVIDE:
                    operatorText = "/";
                    break;
            }

            return _mathData.A.ToString() + " " + operatorText + " " + _mathData.B.ToString();
        }

        public int GetMathResult()
        {
            int result = 0;

            switch (_mathData.Operator)
            {
                case EMathOperator.ADDING:
                    result = _mathData.A + _mathData.B;
                    break;
                case EMathOperator.SUBTRACT:
                    result = _mathData.A - _mathData.B;
                    break;
                case EMathOperator.MULTIPLY:
                    result = _mathData.A * _mathData.B;
                    break;
                case EMathOperator.DIVIDE:
                    result = _mathData.A / _mathData.B;
                    break;
            }

            return result;
        }

        public void OnSelect()
        {

        }

        public void OnTrue()
        {
            var endMovePosition = _selfTransform.position + Vector3.up * _offsetY;

            _selfTransform
                .DOMove(endMovePosition, _moveDuration)
                .SetEase(_moveEase)
                .SetLink(gameObject);

            _selfTransform
                .DORotate(new Vector3(0.0f, 360.0f, 0.0f), _rotateDuration, RotateMode.FastBeyond360)
                .SetEase(_rotateEase)
                .SetLink(gameObject);

            _selfTransform
                .DOScale(Vector3.zero, _scaleDuration)
                .SetEase(_scaleEase)
                .SetLink(gameObject)
                .OnComplete(() => gameObject.SetActive(false));
        }

        public void OnFalse()
        {
            var startPosition = _selfTransform.position;
            var endMovePosition = _selfTransform.position + Vector3.up * _offsetY;

            _selfTransform
                .DOMove(endMovePosition, _moveDuration)
                .SetEase(_moveEase)
                .SetLink(gameObject)
                .OnComplete( () => ReturnPosition(startPosition) );

            _selfTransform
                .DORotate(new Vector3(0.0f, 360.0f, 0.0f), _rotateDuration, RotateMode.FastBeyond360)
                .SetEase(_rotateEase)
                .SetLink(gameObject);
        }

        private void ReturnPosition(Vector3 position)
        {
            _selfTransform
                .DOMove(position, _moveDuration)
                .SetEase(_moveEase)
                .SetLink(gameObject);
        }

        public void OnDeselect()
        {
            
        }


    }
}