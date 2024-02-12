using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedplayerVisual : MonoBehaviour
{

    [SerializeField] private CleanWall cleanWall;
    [SerializeField] private GameObject visualGameObject;
    private void Start()
    {
        Player.Instance.OnSlectedWallChange += Player_OnSlectedWallChange;

    }

    private void Player_OnSlectedWallChange(object sender, Player.OnSlectedWallChangeEventArgs e)
    {
        if (e.selectedWall == cleanWall)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }
    private void Show()
    {
        visualGameObject.SetActive(true);
    }

    private void Hide()
    {
        visualGameObject.SetActive(false);
    }
}
