using UnityEngine;

namespace Game
{
    public class Block : MonoBehaviour
    {
        [Tooltip("Индекс уровня, которому принадлежит этот блок")]
        public int LevelIndex;

        private static readonly int _emissionColor = Shader.PropertyToID("_EmissionColor");

        private void Start()
        {
            MeshRenderer renderer = GetComponent<MeshRenderer>();
            transform.rotation = Quaternion.Euler(new Vector3(Random.Range(-15, 15), Random.Range(-15, 15), Random.Range(-15, 15)));
            renderer.materials[0].SetColor(_emissionColor, RandomColor());
            renderer.materials[0].SetColor(0, RandomColor());
        }


        private Color RandomColor()
        {
            return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }

        private void OnCollisionEnter(Collision collision)
        {
            var ball = collision.gameObject.GetComponent<Ball>();
            if (ball != null)
            {
                ball.transform.position += new Vector3(0.05f, 0.05f, 0.05f);
                Destroy(gameObject);
                ball.AddSpeed();
            }
        }
    }

}
