using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class MenuHandler : MonoBehaviour
{
    // Fields for the camera rotation.
    public float rotationSpeed = 0.05f;
    [SerializeField] Camera camera;
    float speed = 5f;

    // Fields to check to check in which direction the camera moves.
    bool shopBool;
    bool levelBool;
    bool mainMenuBool;

    // On start, get the camera object.
    void Start()
    {
        camera = FindObjectOfType<Camera>();
    }

    // On update, check if there's any attempt to rotate the camera.
    void Update()
    {
        if (shopBool)
            ShowShopMenu();
        if (levelBool)
            ShowLevelsMenu();
        if (mainMenuBool)
            ShowMainMenu();
    }

    // This method is to show the shop menu.
    public void ShowShopMenu()
    {
        shopBool = true;
        Vector3 shopVector = new Vector3(0f, 90f, 0f);
        camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, Quaternion.Euler(shopVector), speed * Time.deltaTime);
        if (camera.transform.rotation == Quaternion.Euler(shopVector))
            shopBool = false;
    }

    // This method is to show the main menu.
    public void ShowMainMenu()
    {
        mainMenuBool = true;
        Vector3 shopVector = new Vector3(0f, 0f, 0f);
        camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, Quaternion.Euler(shopVector), speed * Time.deltaTime);
        if (camera.transform.rotation == Quaternion.Euler(shopVector))
            mainMenuBool = false;
    }

    // This method is to show the levels menu.
    public void ShowLevelsMenu()
    {
        levelBool = true;
        Vector3 levelsVector = new Vector3(0f, -90f, 0f);
        camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, Quaternion.Euler(levelsVector), speed * Time.deltaTime);
        if (camera.transform.rotation == Quaternion.Euler(levelsVector))
            levelBool = false;
    }

    // // This method is to change the camera rotation according to the
    // // given y coordinates.(
    // public void ChangeCameraRot(float y)
    // {
    //     changingCameraRot = true;
    //     Vector3 shopVector = new Vector3(0f, y, 0f);
    //     camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, Quaternion.Euler(shopVector), speed * Time.deltaTime);
    //     if (camera.transform.rotation == Quaternion.Euler(shopVector))
    //         changingCameraRot = false;
    // }
}
