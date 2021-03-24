using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Perro : MonoBehaviour
{

    [SerializeField] private NavMeshAgent navigation;
    [SerializeField] private Transform player;
    [SerializeField] private Transform pilota;

    // Start is called before the first frame update
    void Start()
    {
        navigation = GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update()
    {
        //se tenfria que hacer que cada vez que se lance la pelota se active este metodo con una barriante para que siga la pelota, i lo mismo al coger-la para ir a por el jugador
        navigation.destination = player.position;
    }
}
