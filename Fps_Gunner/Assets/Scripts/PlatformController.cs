using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Transform checker;
    public LayerMask player_layer;
    private bool is_Touch = false;
    private void Update()
    {
        if (Physics.CheckBox(checker.position, new Vector3(1, 0.5f, 1), Quaternion.identity, player_layer))
        {
            StartCoroutine(FallWait());
        }
        if (is_Touch)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator FallWait()
    {
        yield return new WaitForSeconds(2f);
        is_Touch = true;

    }
}


