using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonBall : MonoBehaviour
{
    [SerializeField] GameObject pokemonPos;
    [SerializeField] GameObject MumuxiaoPrefab;
    // Start is called before the first frame update
    void Start()
    {
        pokemonPos = GameObject.Find("pokemonPos");
    }

    private void OnMouseDown()
    {
        GameObject Mumu = Instantiate(MumuxiaoPrefab);
       
        Mumu.transform.position = pokemonPos.transform.position;
        Destroy(this.gameObject);
    }
}
