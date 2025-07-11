using Unity.Collections;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private Transform childContainer;
    [SerializeField] private Transform enemyHitbox;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float initialDelay = 1f;

    private SpriteRenderer spriteRenderer;

    // code that finds the maximum and minimum x values of the roof
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        minX = spriteRenderer.bounds.min.x +1f;
        maxX = spriteRenderer.bounds.max.x- 1f;
        InvokeRepeating("SpawnObject", initialDelay, spawnInterval);
    }

    private void SpawnObject()
    {
        if (ball)
        {
            float xPos = Random.Range(minX, maxX);
            Vector3 worldPos = new Vector3(xPos, enemyHitbox.position.y, childContainer.position.z);
            GameObject obj = Instantiate(ball, worldPos, Quaternion.identity);
            obj.transform.SetParent(childContainer);
            if (childContainer.localScale != Vector3.one)
            {
                Debug.LogWarning("childContainer is out of scale");
            }
        }
    }

}
