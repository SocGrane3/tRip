using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Perro : MonoBehaviour
{

    [SerializeField] private NavMeshAgent navigation;
    [SerializeField] private Transform player;
    [SerializeField] private Transform pilota;
    [SerializeField] private float stopDistance;
    [SerializeField] private Animator animation;
    public bool pilotaCatch, corre;

    // Start is called before the first frame update
    void Start()
    {
        navigation = GetComponent<NavMeshAgent>();
        animation = GetComponent<Animator>();
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
        animation.SetTrigger("run");
    }

    public void irAJugador()
    {
        navigation.destination = player.position;
        navigation.stoppingDistance = stopDistance;
        if (navigation.remainingDistance < stopDistance) animation.SetTrigger("wait");
        else animation.SetTrigger("run");
    }
}
