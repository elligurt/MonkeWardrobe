using UnityEngine;

public static class StandLocations
{
    // gazebo wardrobe
    public static readonly Vector3 gazeboStandPosition = new Vector3(-63.9811f, 2.1382f, - 60.0751f);
    public static readonly Quaternion gazeboStandRotation = Quaternion.Euler(0.3982f, 174.8689f, 0.0091f);

    // mirror in city wardrobe
    public static readonly Vector3 mirrorStandPosition = new Vector3(-49.7739f, 16.1382f, - 118.5215f);
    public static readonly Quaternion mirrorStandRotation = Quaternion.Euler(0f, 252.1958f, 0f);

    // basement wardrobe
    public static readonly Vector3 basementStandPosition = new Vector3(-32.9472f, 13.626f,- 88.6619f);
    public static readonly Quaternion basementStandRotation = Quaternion.Euler(0.5091f, 217.6972f,0f);
}
