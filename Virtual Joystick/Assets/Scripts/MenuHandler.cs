using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;
using Vector2 = UnityEngine.Vector2;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;

public class MenuHandler : MonoBehaviour
{
    // --------------------------------------------
    // ------------------ FIELDS ------------------
    // --------------------------------------------

    // Fields for the camera rotation.
    float camRotSpeed = 5f;
    Camera camera;
    Transform cameraRot;

    // Prefabs for menus.
    [SerializeField] private GameObject levelButton, levelPanel, shopButton, shopPanel;
    [SerializeField] private Material playerMaterial;

    // --------------------------------------------
    // --------------- MONOBEHAVIORS --------------
    // --------------------------------------------

    // On start, get the camera and handle the level and shop panels.
    void Start()
    {
        camera = FindObjectOfType<Camera>();
        HandleLevels();
        HandleShop();
        PlayerSkins(GameManager.Instance.SimdikiSkin);
    }

    // On update, rotate the camera according to the cameraRot.rotation.
    void Update()
    {
        if (cameraRot != null)
        {
            camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, cameraRot.rotation, camRotSpeed * Time.deltaTime);
        }
    }


    // --------------------------------------------
    // --------------- OTHER METHODS --------------
    // --------------------------------------------

    // This method is to change the camera rotation according to the
    // given transform value.
    public void ChangeCameraRot(Transform menuTransform)
    {
        cameraRot = menuTransform;
        Debug.Log(menuTransform.rotation);
    }

    // This method is to handle the levels menu.
    void HandleLevels()
    {
        // Load a collection of sprites representing level images.
        Sprite[] levelImages = Resources.LoadAll<Sprite>("Levels");
        // For each sprite:
        foreach (Sprite image in levelImages)
        {
            // Instantiate a button, set the level panel as its 
            // parent so that they'd display correctly.
            GameObject btn = Instantiate(levelButton) as GameObject;
            btn.GetComponent<Image>().sprite = image;
            btn.transform.SetParent(levelPanel.transform, false);

            // Add a click listener to the button so that it'll
            // call the "LoadScene" method on click.
            string sceneName = image.name;
            btn.GetComponent<Button>().onClick.AddListener(() => LoadScene(sceneName));
        }
    }

    // This method is to handle the shop menu.
    void HandleShop()
    {   // TextureIndex to keep track of the index of the selected skin texture.
        int TextureIndex = 0;
        // Load a collection of sprites representing the skins.
        Sprite[] skins = Resources.LoadAll<Sprite>("Player");
        // For each sprite:
        foreach (Sprite skin in skins)
        {
            // Instantiate a button, set the shop panel as its 
            // parent so that they'd display correctly.
            GameObject btn = Instantiate(shopButton) as GameObject;
            btn.GetComponent<Image>().sprite = skin;
            btn.transform.SetParent(shopPanel.transform, false);

            // A var to capture the current value of TextureIndex.
            int index = TextureIndex;
            // Add a click listener to the button so that it'll
            // call the "PlayerSkins" method on click.
            btn.GetComponent<Button>().onClick.AddListener(() => PlayerSkins(index));
            TextureIndex++;
        }
    }

    // This method is to load the given scene by name.
    void LoadScene(string sceneName)
    {
        Debug.Log("Load scene is called!");
        SceneManager.LoadScene(sceneName);
    }

    // This method is to change the player skin.
    private void PlayerSkins(int index)
    {
        Debug.Log("PlayerSkis is called!");
        float x = (index % 4) * 0.25f;
        float y = ((int)index / 4) * 0.25f;

        if (y == 0)
            y = 0.75f;
        else if (y == 0.25f)
            y = 0.50f;
        else if (y == 0.50f)
            y = 0.25f;
        else if (y == 0.75f)
            y = 0;

        playerMaterial.SetTextureOffset("_MainTex", new Vector2(x, y));

        GameManager.Instance.SimdikiSkin = index;
        GameManager.Instance.Save();
    }
}
