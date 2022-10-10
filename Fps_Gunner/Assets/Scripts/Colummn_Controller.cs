using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colummn_Controller : MonoBehaviour
{
    public Transform checker;
    public LayerMask player_layer;
    private Vector3 velocity;
    public float velocityDivider;
    private bool is_Touch = false;
    private void Update()
    {
        if (Physics.CheckBox(checker.position, new Vector3(2.5f, 0.5f, 2.5f), Quaternion.identity, player_layer))
        {
            is_Touch = true;

        }
        if (is_Touch)
        {
            StartCoroutine(FallWait());
            StartCoroutine(DestroyWait());
        }
    }
    IEnumerator FallWait()
    {
        yield return new WaitForSeconds(1f);
        velocity.z -= Time.deltaTime / velocityDivider;
        transform.Translate(velocity);

    }
    IEnumerator DestroyWait()
    {
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
    }
}
