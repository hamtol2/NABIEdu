using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Step05
{
    public class Bullet : MonoBehaviour
    {
        public float moveSpeed = 10f;

        public LineRenderer lineRenderer;

        private void Awake()
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

        void Update()
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;

            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position - transform.forward * 5f);
        }
    }
}