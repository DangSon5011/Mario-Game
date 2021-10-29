using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamemaster1 : MonoBehaviour
{
  
    public Text lifetext;
    public int point;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        point = PlayerPrefs.GetInt("life",3);
    }

    // Update is called once per frame
    void Update()
    {
        lifetext.text = ("X" +point);
    }
}
