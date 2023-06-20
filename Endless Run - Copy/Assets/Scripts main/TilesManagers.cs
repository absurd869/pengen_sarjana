using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesManagers : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] tilePrefabs;
    private float zSpawn = 0;
    public float tileLenght;
    private float numberOfTiles;
    private int angka,ulang;

    private List<GameObject> activeTiles = new List<GameObject>();
    //private int num = Random.Next(5);

    public Transform player;
    
    void Start()
    {

        //numberOfTiles = tilePrefabs.Length;
        numberOfTiles = 4;
        for (int i = 0; i < numberOfTiles; i++)
        {
            // startingTiles
            if (zSpawn == 0)
            {
                SpawnTile(0);
                SpawnTile(0);
                SpawnTile(0);
            }

            else
            {

                angka = Random.Range(1, tilePrefabs.Length);
                ulang = angka;
                SpawnTile(angka);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.z - 5 > zSpawn - (numberOfTiles * tileLenght))
        {

            //SpawnTile(Random.Range(1, tilePrefabs.Length));
            while (angka == ulang)
            { 
                angka = Random.Range(1, tilePrefabs.Length);
            }

            ulang = angka;
            SpawnTile(angka);

            DeleteTiles();
        }
    }

    public void SpawnTile(int TileIndex)
    {
        GameObject go = Instantiate(tilePrefabs[TileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLenght;
        //zSpawn += 5;


    }

    public void DeleteTiles()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
