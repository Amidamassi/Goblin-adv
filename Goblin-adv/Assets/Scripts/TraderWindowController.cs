using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Stats;
using UnityEngine;
using UnityEngine.UI;

public class TraderWindowController : MonoBehaviour
{
    [SerializeField] private Text _passive1Name;
    [SerializeField] private Text _passive1Description;
    [SerializeField] private Text _passive2Name;
    [SerializeField] private Text _passive2Description;
    [SerializeField] private Text _passive3Name;
    [SerializeField] private Text _passive3Description;
    public Player _Player;
    private Passives[] _chosenPassives;
    public void initialization(Passives[] passivesArray)
    {
        _chosenPassives = passivesArray;
        _passive1Name.text = passivesArray[0].Name;
        _passive2Name.text = passivesArray[1].Name;
        _passive3Name.text = passivesArray[2].Name;
        _passive1Description.text = passivesArray[0].stat.ToString() +" "+passivesArray[0].Value;
        _passive2Description.text = passivesArray[1].stat.ToString() +" "+passivesArray[1].Value;
        _passive3Description.text = passivesArray[2].stat.ToString() +" "+passivesArray[2].Value;
        
    }

    public void ApplyPassive(int number)
    {
        _Player.AddPassive(_chosenPassives[number]);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
