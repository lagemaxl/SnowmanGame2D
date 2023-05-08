using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObjectOnClick : MonoBehaviour
{
    // Serialized field pro p�i�azen� objektu, kter� se m� zobrazit po kliknut� na tla��tko.
    [SerializeField] private GameObject objectToShow;

    private void Start()
    {
        // Skryje objekt p�i spu�t�n� hry.
        objectToShow.SetActive(false);
    }

    public void ShowObject()
    {
        // Zobraz� objekt po kliknut� na tla��tko.
        objectToShow.SetActive(true);
    }
}
