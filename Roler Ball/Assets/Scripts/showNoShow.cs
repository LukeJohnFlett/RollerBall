using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showNoShow : MonoBehaviour
{

    [SerializeField] private MeshRenderer RendererPlane;
    [SerializeField] private MeshCollider colliderPlane;
    [SerializeField] private bool first;
    [SerializeField] private bool secound;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowNoShown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ShowNoShown()
    {
        while (true)
        {
            RendererPlane.enabled = first;
            colliderPlane.enabled = first;
            yield return new WaitForSeconds(3);
            RendererPlane.enabled = secound;
            colliderPlane.enabled = secound;
            yield return new WaitForSeconds(3);
            

        }
        

    }
    
}
