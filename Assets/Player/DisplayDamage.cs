using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] float displaytime = 0.5f;
    [SerializeField] Canvas impactCanvas;
    private void Start() 
    {
        impactCanvas.enabled =false;    
    }

    public void ShowImpactCanvas()
    {
        StartCoroutine(DisplayDamageImg());
    }

    public IEnumerator DisplayDamageImg()
    {
        impactCanvas.enabled = true;
        yield return new WaitForSeconds(displaytime);
        impactCanvas.enabled =false;
    }

}
