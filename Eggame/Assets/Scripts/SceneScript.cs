using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneScript : MonoBehaviour
{
    private List<GameObject> children;
    private int isDead = 0;
    private int players = 3; // will change to a variable that keeps track of how many controllers put in input on start screen and selected an egg -> brings into this script for reference 
                             // of how many child game objects to keep track of
	// Use this for initialization
	void Start ()
    {
        // dynamically add children based on how many players selected an egg on start screen to game
        // keep track how many are alive and how many die
        // end game when amount of players - 1 have died

        children = new List<GameObject>();
        for(int i = 0; i < players; i++) 
        {
            children.Add(this.gameObject.transform.GetChild(i).gameObject); // will have to be replaced when we dynamically instantiate eggs rather than eggs that already exist in scene
        }

        // method to place eggs on a location in the nest based on how many eggs there are has to be made

        // start menu holds an array of eggs with their customization, this script holds the same array
        // when a player selects that egg as their egg, that player's egg prefab will be that egg -> it will be instantiated as a child of "Players"
        // method to be made to place eggs based on how many players there are in the game. 
    }

    // Update is called once per frame
    void Update ()
    {
        if (isDead >= players - 1)
        {
            Application.LoadLevel(0);
        }

        for (int i = 0; i < children.Count; i++)
        {
            if(children[i].transform.position.y <= -50)
            {
                isDead++;
                Destroy(children[i]);
                children.RemoveAt(i);
            }
        }
    }
}
