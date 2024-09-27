
using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LancerAnneau : MonoBehaviour
{

    

    private bool _marquePoint = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bouteilles"))
        {
            _marquePoint = true;
            StopAllCoroutines();
            StartCoroutine(Delai());
        }
    }

    private void OnTriggerExit(Collider other) {
        _marquePoint = false;
    }

    private IEnumerator Delai()
    {
        yield return new WaitForSeconds(3f);
        if(_marquePoint )
        {
            AnneauGameManager.Instance.AugmenterPointage();
        }
    }

}
