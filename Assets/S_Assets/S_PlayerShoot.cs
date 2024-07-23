using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRadius = 1.2f;

    void Update()
    {
        Vector3 mousePositionScreen = Input.mousePosition;
        Vector3 mousePositionWorld = Camera.main.ScreenToWorldPoint(new Vector3(mousePositionScreen.x, mousePositionScreen.y, 10f));

        Vector2 dir = (mousePositionWorld - transform.position).normalized;

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 spawnPos = transform.position + (Vector3)(dir * spawnRadius);
            GameObject newBullet = Instantiate(bulletPrefab, spawnPos, Quaternion.identity);

            newBullet.GetComponent<S_Bullet>().Init(dir);
        }
    }
}
