﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DropCollectableOnDeath : MonoBehaviour
{
    [SerializeField] private int _collectableNumber;
    [SerializeField] private float _collectableWorth;
    [SerializeField] private float _radius;
    [SerializeField] private float _maxRotationSpeed;
    [SerializeField] private float _minRotationSpeed;
    [SerializeField] private Collectable_Points _collectable;
    
    // TODO:: Pool the collectables

    private EnemyInfo _info;
    private Transform _transform;
	// Use this for initialization
	void Start ()
	{
	    _transform = transform;
	    _info = GetComponent<EnemyInfo>();
        // _info.OnDeath.AddListener(OnDeath);
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private bool _isQuitting = false;
    void OnApplicationQuit()
    {
        _isQuitting = true;
        
    }

    public void Destroy()
    {
        for (int i = 0; i < _collectableNumber; i++)
        {
            if (_collectable == null) continue;
            GameObject o = Instantiate(_collectable.gameObject);
            o.transform.parent = GlobalInfo.ParticleContainer.transform;
            o.GetComponent<Collectable_Points>().m_pointValue = _collectableWorth;
            o.GetComponent<Rigidbody2D>().angularVelocity = Random.Range(_minRotationSpeed, _maxRotationSpeed);
            o.transform.position = (Vector2)_transform.position + Random.insideUnitCircle * _radius;
        }
    }
}
