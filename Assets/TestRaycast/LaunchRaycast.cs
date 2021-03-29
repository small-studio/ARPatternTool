using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchRaycast : MonoBehaviour
{
    public GameObject _prefab;
    float _timer = 0f;
    public float _duration = 0.3f;
    public Vector2Int _offsetSize;

    void FixedUpdate()
    {
        _timer += Time.deltaTime;

        if (_timer >= _duration)
        {
            RaycastHit hit;
            int layerMask = LayerMask.GetMask("ScanMesh", "MaskEarly");
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward + new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f), 0f)), out hit, Mathf.Infinity, layerMask))
            {
                if (hit.transform.gameObject.layer == 9)
                {
                    _timer -= _duration;
                    GameObject go = Instantiate(_prefab, hit.point, Quaternion.LookRotation(hit.normal));
                    // 9 * 13
                    Vector2 scale = new Vector2(-1f / (float)_offsetSize.x, 1f / (float)_offsetSize.y);
                    Material mat = go.GetComponent<Renderer>().material;
                    mat.SetTextureOffset("_MainTex", new Vector2(scale.x * (float)Random.Range(0, _offsetSize.x), scale.y * (float)Random.Range(0, _offsetSize.y)));
                    mat.SetTextureScale("_MainTex", scale);
                }
            }
        }
    }
}
