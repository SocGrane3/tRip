﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Perro : MonoBehaviour
{

    [SerializeField] private NavMeshAgent navigation;
    [SerializeField] private Transform player;
    [SerializeField] private Transform pilota;
    private Animation animation;
    public bool pilotaCatch;

    // Start is called before the first frame update
    void Start()
    {
        navigation = GetComponent<NavMeshAgent>();
        animation = GetComponent<Animation>();
    }
    // Update is called once per frame
    void Update()
    {
        //si te la pilota es dirigeix al jugador
        if (pilotaCatch) irAJugador();
        else seguirPilota();
    }

    public void seguirPilota()
    {
        navigation.destination = pilota.position;
        navigation.stoppingDistance = 1;
        animation.Play();
    }

    public void irAJugador()
    {
        navigation.destination = player.position;
        navigation.stoppingDistance = 1.5f;
        animation.Play();
    }
}
