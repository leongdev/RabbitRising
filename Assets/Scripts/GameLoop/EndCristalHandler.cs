using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCristalHandler : MonoBehaviour
{
    [SerializeField] GameObject endPortal;
    [SerializeField] GameObject endCristal;
    [SerializeField] GameObject endArrow;
    [SerializeField] GameObject getPlarticle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            OnPlayerGetsCristal();
        }
    }

    /// <summary>
    /// This method handle when player gets the end cristal
    /// </summary>
    void OnPlayerGetsCristal()
    {
        getPlarticle.SetActive(true);
        endPortal.SetActive(true);
        endCristal.SetActive(false);
        endArrow.SetActive(true);
    }
}
