using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using KartGame.KartSystems;
using UnityEngine.UI;

public class PlayerPoop : MonoBehaviour
{
    [Header("Poop Collection")]
    [SerializeField] private TMP_Text poopNum;

    [Header("Fever Mode")]
    [SerializeField] private TMP_Text feverCheck;


    private ArcadeKart arcadeKart;

    
    public Transform movingObject; // Assign your moving object in the Inspector
    public float freezeDistance = 10f; // Distance threshold to freeze the object
    public KeyCode freezeKey = KeyCode.C;
    public float freezeDuration = 2f; // Duration to freeze the object in seconds
    private float distance;
    public KeyCode feverKey = KeyCode.V;

    [Header("Poop")] 
    [SerializeField] private GameObject poopUI;
    [SerializeField] private int poopCollect = 5;
    [SerializeField] private Image feverBar;
    [SerializeField] private float feverCountdown = 5f;
    [SerializeField] private bool onStartFever;

    private bool feverActivated = false;

    private bool isFrozen = false;
    
    void Start()
    {
        arcadeKart = GetComponent<ArcadeKart>();
        onStartFever = true;
    }

    // Update is called once per frame
    void Update()
    {

        distance = Vector3.Distance(transform.position, movingObject.position);

        // Try enter Fever Mode
        StartCoroutine(CheckFever());

        // Try to throw poop
        StartCoroutine(CheckThrowPoop());

        if (feverActivated)
        {
            feverCountdown -= Time.deltaTime;
            feverBar.fillAmount = feverCountdown / 5f;
        }
        
    }

    // Poop collection
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Poop") && poopCollect <= 5 && !feverActivated)
        {
            poopUI.transform.GetChild(poopCollect).gameObject.SetActive(false);
        
            poopCollect++;
            poopUI.transform.GetChild(poopCollect).gameObject.SetActive(true);
            poopNum.text = poopCollect.ToString();
            Destroy(other.gameObject);
        }
    }

    // Check if the player have enough poop to trigger Fever mode
    IEnumerator CheckFever()
    {
        if (onStartFever)
        {
            
            yield return new WaitForSeconds(4f);
            onStartFever = false;
            poopUI.transform.GetChild(6).gameObject.SetActive(true);
            StartCoroutine(Fever());

        }
        if(Input.GetKeyDown(feverKey))
        {
            if (poopCollect == 5)
            {
               
                poopNum.text = poopCollect.ToString();
                poopUI.transform.GetChild(5).gameObject.SetActive(false);
                poopUI.transform.GetChild(6).gameObject.SetActive(true);
                StartCoroutine(Fever());
                
            } else
            {
                feverCheck.text = "You Don't Have Enough Poop!";
                yield return new WaitForSeconds(2f);
                feverCheck.text = string.Empty;
            }
            
        }
    }

    // Fever mode triggered
    IEnumerator Fever()
    {
        poopCollect -= 5;
        feverActivated = true;
        SetBaseStatsFromDatabase(FeverModeData());

        feverCheck.text = "FEVER MODE";
        
        yield return new WaitForSeconds(5f);
        poopUI.transform.GetChild(0).gameObject.SetActive(true);
        poopUI.transform.GetChild(6).gameObject.SetActive(false);
        feverCountdown = 5f;
        feverBar.fillAmount = 1f;
        feverActivated = false;
        feverCheck.text = string.Empty;

        SetBaseStatsFromDatabase(NormalModeData());

    }



    // Check if the player can throw the poop
    IEnumerator CheckThrowPoop()
    {
        if (Input.GetKeyDown(freezeKey))
        {
            //Collider[] colliders = Physics.OverlapSphere(transform.position, opponentDist);

            if (poopCollect >= 1)
            {
                // Check if the distance is less than the threshold and the freeze key is pressed
                if (distance < freezeDistance)
                {
                    // Toggle freeze state
                    isFrozen = !isFrozen;

                    // Start the coroutine to freeze the object for the specified duration
                    if (isFrozen)
                    {
                        //Debug.Log("Poop Freeze!");
                        //StartCoroutine(FreezeObjectForDuration());
                        
                        StartCoroutine(ThrowPoop());
                    }
                }
                //StartCoroutine(ThrowPoop());
            }
            else
            {
                feverCheck.text = "You Don't Have Enough Poop!";
                yield return new WaitForSeconds(2f);
                feverCheck.text = string.Empty;
            }

            

            /*
            if (!playerTag)
            {
                feverCheck.text = "No Player Within Reach";
                yield return new WaitForSeconds(2f);
                feverCheck.text = string.Empty;
            }
            */
        }

        
    }

    // Throw Poop Now
    IEnumerator ThrowPoop()
    {
        //Debug.Log("Drop a poop");
        poopCollect -= 1;
        poopNum.text = poopCollect.ToString();

        

        Rigidbody movingObjectRb = movingObject.GetComponent<Rigidbody>();
        if (movingObjectRb != null)
        {
            Debug.Log("Poop Freeze!");
            movingObjectRb.isKinematic = true;
        }

        // Wait for the specified duration
        yield return new WaitForSeconds(freezeDuration);

        // Unfreeze the object
        if (movingObjectRb != null)
        {
            movingObjectRb.isKinematic = false;
        }


        feverCheck.text = "THROW POOP!";
        yield return new WaitForSeconds(3f);
        feverCheck.text = string.Empty;
        

    }



    private ArcadeKart.Stats FeverModeData()
    {
        // Replace this with your actual database call to fetch FeverModeData
        // Example:
        ArcadeKart.Stats feverStats = new ArcadeKart.Stats
        {
            TopSpeed = 30f,
            Acceleration = 30f,

            AccelerationCurve = 4f,
            Braking = 10f,
            ReverseAcceleration = 5f,
            ReverseSpeed = 5f,
            Steer = 5f,
            CoastingDrag = 4f,
            Grip = .95f,
            AddedGravity = 1f,
            // Add other stat assignments as needed for FeverModeData
        };

        return feverStats;
    }


    private ArcadeKart.Stats NormalModeData()
    {
        // Replace this with your actual database call to fetch NormalModeData
        // Example:
        ArcadeKart.Stats normalStats = new ArcadeKart.Stats
        {
            TopSpeed = 15f,
            Acceleration = 10f,

            AccelerationCurve = 4f,
            Braking = 10f,
            ReverseAcceleration = 5f,
            ReverseSpeed = 5f,
            Steer = 5f,
            CoastingDrag = 4f,
            Grip = .95f,
            AddedGravity = 1f,
            // Add other stat assignments as needed for NormalModeData
        };

        return normalStats;
    }


    private void SetBaseStatsFromDatabase(ArcadeKart.Stats stats)
    {
        if (arcadeKart != null)
        {
            arcadeKart.baseStats = stats;
        }
    }


    /*
    IEnumerator FreezeObjectForDuration()
    {
        // Freeze the object
        Rigidbody movingObjectRb = movingObject.GetComponent<Rigidbody>();
        if (movingObjectRb != null)
        {
            
            movingObjectRb.isKinematic = true;
        }

        // Wait for the specified duration
        yield return new WaitForSeconds(freezeDuration);

        // Unfreeze the object
        if (movingObjectRb != null)
        {
            movingObjectRb.isKinematic = false;
        }
    }
    */
}
