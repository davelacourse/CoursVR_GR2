using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnneauUIManager : MonoBehaviour
{

    [SerializeField] private TMP_Text _txtPointage;

    void Start()
    {
        AnneauGameManager.Instance.EventUptadePointage += OnEventUpdatePointage;
    }

    private void OnEventUpdatePointage(int nouveauPointage)
    {
        _txtPointage.text = "Pointage : " + nouveauPointage.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
