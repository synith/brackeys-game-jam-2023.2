using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] float _speed=400f;
    [SerializeField] float _nextWaypointDistance = 3f;
    [SerializeField] bool _isFlying;

    Path _path;
    int _currentWaypoint = 0;
    bool _reachedEndOfPath=false;

    Seeker _seeker;
    Rigidbody2D _rb;
    SpriteRenderer _spriteRenderer;


    void Start()
    {
        _seeker = GetComponent<Seeker>();
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }


    void FixedUpdate()
    {
        if (_path==null)
        {
            return;
        }

        if (_currentWaypoint>=_path.vectorPath.Count)
        {
            _reachedEndOfPath = true;
            return;
        }
        else
        {
            _reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)_path.vectorPath[_currentWaypoint]-_rb.position).normalized;

        Vector2 force = direction * _speed * Time.deltaTime;
        if (_isFlying == false)
        {
            _rb.AddForce(new Vector2(0, -3f));
        }
        _rb.AddForce(force);
        
       

        float distance = Vector2.Distance(_rb.position, _path.vectorPath[_currentWaypoint]);

        if (distance<_nextWaypointDistance)
        {
            _currentWaypoint++;
        }

        if (force.x>=0.01f)
        {
            _spriteRenderer.flipX = true;
        }
        else if(force.x<=-0.01f)
        {
            _spriteRenderer.flipX = false;
        }




    }



    void UpdatePath()
    {
        if (_seeker.IsDone())
            _seeker.StartPath(_rb.position, _target.position, OnPathComplete);
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            _path = p;
            _currentWaypoint = 0;

        }
    }
}
