using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] float _speed;
    [SerializeField] float _distanceBetween;

    float _distance;
    bool _startChase = false;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        ChasePlayer();
    

        
    }

    void ChasePlayer()
    {
        _distance=Vector2.Distance(transform.position, _player.position);
        Debug.Log(_distance+_player.name);
        if (_distance <= _distanceBetween)
            _startChase = true;

        if (_startChase)
        {
            Vector2 direction = _player.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.position = Vector2.MoveTowards(transform.position, _player.position, _speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
       
    }

    
}
