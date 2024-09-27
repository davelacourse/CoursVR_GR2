using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AnneauGameManager : MonoBehaviour
{

    //--Singleton
    public static AnneauGameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    [SerializeField] private GameObject[] _anneaux;  // tableau qui contient toutes les anneaux du jeu
    [SerializeField] private int _pointsParAnneau = 100;
    
    private int _pointage;
    private Vector3[] _positionAnneauxDepart; // contient la position de chaque anneau au départ
    private Quaternion[] _rotationAnneauxDepart; // pareil pour la rotation

    public event Action<int> EventUptadePointage;

    private void Start()
    {
        _pointage = 0;

        _positionAnneauxDepart = new Vector3[_anneaux.Length];
        _rotationAnneauxDepart = new Quaternion[_anneaux.Length];

        for(int i = 0; i < _anneaux.Length; i++)
        {
            _positionAnneauxDepart[i] = _anneaux[i].transform.position;
            _rotationAnneauxDepart[i] = _anneaux[i].transform.rotation;
        }
    }

    public void AugmenterPointage()
    {
        _pointage += _pointsParAnneau;
        EventUptadePointage?.Invoke(_pointage);
    }

    [ContextMenu("Reset Game")]
    public void ResetGame()
    {
        for (int i = 0; i < _anneaux.Length; i++)
        {
            _anneaux[i].transform.SetPositionAndRotation(_positionAnneauxDepart[i], _rotationAnneauxDepart[i]);
        }
        _pointage = 0;
        EventUptadePointage?.Invoke(_pointage);
    }
}
