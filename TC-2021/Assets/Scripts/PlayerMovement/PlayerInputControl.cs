using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInputControl : MonoBehaviour
{
    private Raycast raycast;
    public float gun_length = 10f;
    private float timer = 0;
    public ParticleSystem WaterPS;
    public ParticleSystem OxygenPS;
    public GameObject TipPanel;
    public Image TipImage;
    public Sprite TransportSprite;
    public Sprite WaterSprite;
    public Sprite SpraySprite;
    public Sprite LadderSprite;
    public Sprite BuildSprite;
    public Sprite OxygenSprite;



    public GameObject LadderPrefab;
    // Start is called before the first frame update
    void Start()
    {
        raycast = GetComponent<Raycast>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInteractables();
        RaycastHit hit;
        if (Input.GetButtonDown("Interact"))
        {
            // Debug.Log("Pressed");
            if (raycast.GetInteractableRaycastedObject() != null)
            {
                raycast.GetInteractableRaycastedObject().GetComponent<InteractableObject>().Interact();
            }
            if (Physics.Raycast(GameObject.FindGameObjectWithTag("MainCamera").transform.position, GameObject.FindGameObjectWithTag("MainCamera").transform.forward, out hit, gun_length))
            {
                if (hit.collider.tag == "Water")
                {
                    if (PlayerResources.instance.mode != "gun") return;
                    timer = 0;
                    WaterPS.gameObject.SetActive(true);
                }
                else if (hit.collider.tag == "Oxygen")
                {
                    if (PlayerResources.instance.mode != "gun") return;
                    OxygenPS.gameObject.SetActive(true);
                }
                else if (hit.collider.tag == "Hills")
                {
                    if (PlayerResources.instance.mode != "ladder") return;
                    Instantiate(LadderPrefab, hit.collider.transform.position, Quaternion.identity);
                    Inventory.instance.DeductItem("ladder", 1);
                }
                else if (hit.collider.tag == "InitialSpawn")
                {
                    GetComponent<CharacterController>().enabled = false;

                    gameObject.transform.position = hit.collider.GetComponent<Transfer>().where_to_go.position;
                    GetComponent<CharacterController>().enabled = true;
                }
                else if (hit.collider.tag == "BuildOxygenTank" || hit.collider.tag == "BuildLadder")
                {
                    hit.collider.GetComponent<InteractableObject>().Interact();
                }
            }
        }
        else if (Input.GetButton("Interact"))
        {
            if (Physics.Raycast(GameObject.FindGameObjectWithTag("MainCamera").transform.position, GameObject.FindGameObjectWithTag("MainCamera").transform.forward, out hit, gun_length))
            {
                if (hit.collider.tag == "Water")
                {
                    if (PlayerResources.instance.current_water == PlayerResources.instance.MaxWater || PlayerResources.instance.mode != "gun")
                    {
                        return;
                    }
                    timer += Time.deltaTime;
                    if (timer > 2)
                    {
                        timer = 0;
                        PlayerResources.instance.current_water++;
                    }
                    WaterPS.gameObject.SetActive(true);
                }
                else if (hit.collider.tag == "Oxygen")
                {
                    if (PlayerResources.instance.mode != "gun") return;
                    PlayerResources.instance.current_oxygen += Time.deltaTime;
                    OxygenPS.gameObject.SetActive(true);
                }


            }
        }

        else if (Input.GetButtonUp("Interact"))
        {
            timer = 0;
            WaterPS.gameObject.SetActive(false);
            OxygenPS.gameObject.SetActive(false);
        }
        else if (Input.GetButtonDown("Inventory"))
        {
            InventoryUI.instance.InventoryPanel.SetActive(!InventoryUI.instance.InventoryPanel.activeSelf);
            if (InventoryUI.instance.InventoryPanel.activeSelf)
            {
                Cursor.lockState = CursorLockMode.Confined;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraTrun>().enabled = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraTrun>().enabled = true;
            }
        }
    }

    public void CheckInteractables()
    {
        RaycastHit hit;
        if (Physics.Raycast(GameObject.FindGameObjectWithTag("MainCamera").transform.position, GameObject.FindGameObjectWithTag("MainCamera").transform.forward, out hit, gun_length))
        {
            if (hit.collider.tag == "InitialSpawn")
            {
                TipPanel.SetActive(true);
                TipImage.sprite = TransportSprite;
            }
            else if (hit.collider.tag == "Water")
            {
                TipPanel.SetActive(true);
                TipImage.sprite = WaterSprite;
            }
            else if (hit.collider.tag == "BuildOxygenTank")
            {
                TipPanel.SetActive(true);
                TipImage.sprite = OxygenSprite;
            }
            else if (hit.collider.tag == "BuildLadder")
            {
                TipPanel.SetActive(true);
                TipImage.sprite = LadderSprite;
            }
            else if (hit.collider.tag == "InteractableObject")
            {
                TipPanel.SetActive(true);
                TipImage.sprite = TransportSprite;
            }
            else
            {
                TipPanel.SetActive(false);
            }
        }
        else
        {
            TipPanel.SetActive(false);
        }
    }
}
