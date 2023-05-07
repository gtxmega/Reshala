using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public class Actor : MonoBehaviour
    {
        public Transform SelfTransform => _selfTransform;

        [SerializeField] protected Transform _selfTransform;
    }
}