using UnityEngine;

namespace Logics.Movements
{
    public class MovePoints : MonoBehaviour
    {
        [SerializeField] private Transform[] _movePoints;

        public Vector3 GetMovePoint(int index, out bool isFinish)
        {
            if(index < _movePoints.Length)
            {
                if(index == _movePoints.Length - 1)
                {
                    isFinish = true;
                    return _movePoints[index].position;
                }else
                {
                    isFinish = false;
                    return _movePoints[index].position;
                }
            }

            isFinish = false;
            return Vector3.zero;
        }

#if UNITY_EDITOR

        [Header("EDITOR ONLY!")]
        [SerializeField] private Color _pointColor = Color.white;
        [SerializeField] private float _sphereRadius = 1.0f;
        [SerializeField] private Color _edgeColor = Color.white;
        [SerializeField] private bool _isDisplaying = true;

        private void OnDrawGizmos()
        {
            if( _isDisplaying ) 
            {
                Gizmos.color = _pointColor;

                for (int i = 0; i < _movePoints.Length; ++i)
                {
                    Gizmos.DrawSphere(_movePoints[i].position, _sphereRadius);
                }

                Gizmos.color = _edgeColor;

                for (int i = 0; i < _movePoints.Length; ++i)
                {
                    if(i + 1 < _movePoints.Length)
                        Gizmos.DrawLine(_movePoints[i].position, _movePoints[i + 1].position);
                }
            }
        }

#endif
    }
}