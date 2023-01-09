using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderPlacer : MonoBehaviour
{
    [SerializeField]
    private GameObject borderLeft, borderRight, ground;
    [SerializeField]
    private float bottemShiftingSpace = 5, TopShiftingSpace = 5;

    public void PlaceBorders()
    {
        RescaleBorders();

        TranslateBorders();
    }

    private void RescaleBorders()
    {
        borderLeft.transform.localScale = new Vector3(borderLeft.transform.localScale.x, GameParameters.worldDimensions.y * 2 + bottemShiftingSpace + TopShiftingSpace, borderLeft.transform.localScale.z);
        borderRight.transform.localScale = new Vector3(borderRight.transform.localScale.x, GameParameters.worldDimensions.y * 2 + bottemShiftingSpace + TopShiftingSpace, borderRight.transform.localScale.z);
        ground.transform.localScale = new Vector3(GameParameters.worldDimensions.x * 2, ground.transform.localScale.y, ground.transform.localScale.z);
    }

    private void TranslateBorders()
    {
        borderLeft.transform.position = new Vector3(-GameParameters.worldDimensions.x - borderLeft.transform.localScale.x / 2, -bottemShiftingSpace / 2 + TopShiftingSpace/2, 0);
        borderRight.transform.position = new Vector3(GameParameters.worldDimensions.x + borderRight.transform.localScale.x / 2, -bottemShiftingSpace / 2 + TopShiftingSpace/2, 0);
        ground.transform.position = new Vector3(0, -GameParameters.worldDimensions.y - bottemShiftingSpace - ground.transform.localScale.y / 2, 0);
    }
}
