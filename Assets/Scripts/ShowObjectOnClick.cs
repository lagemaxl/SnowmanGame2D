using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObjectOnClick : MonoBehaviour
{
    // Serialized field pro pøiøazení objektu, který se má zobrazit po kliknutí na tlaèítko.
    [SerializeField] private GameObject objectToShow;

    private void Start()
    {
        // Skryje objekt pøi spuštìní hry.
        objectToShow.SetActive(false);
    }

    public void ShowObject()
    {
        // Zobrazí objekt po kliknutí na tlaèítko.
        objectToShow.SetActive(true);
    }
}
