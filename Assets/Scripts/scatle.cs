using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scatle : MonoBehaviour
{
    public int Levelload = 1;
    public GameMaster gm;
    public Player player;
    public SpriteRenderer layer;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        layer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (player.Dich==true)
        {
            layer.sortingOrder = 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (player.Dich == true)
        {
            gm.lastCheckPointPos = new Vector2(-11, -4);

            SceneManager.LoadScene(Levelload);
            
        }
    }

}
