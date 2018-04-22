using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    public class shape : MonoBehaviour
    {

        public List<GameObject> currentCollisions = new List<GameObject>();
        public GameObject myDropper;
        public Material mainMaterial;
        public Material highlightMaterial;
        public Renderer rend;
        LineRenderer lineRenderer;
        public Text scoreText;
        public Text powerCost;
        public Image powerSlider;
        public int myValue = 5;
        public float myPower = 0.05f;
        public float costModifier = 3;

        private void Start()
        {
            rend = GetComponent<Renderer>();
            lineRenderer = gameObject.AddComponent<LineRenderer>();
            lineRenderer.widthMultiplier = .1f;
            lineRenderer.enabled = false;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == tag)
            {
                currentCollisions.Add(collision.gameObject);
            }

            if (currentCollisions.Count == 2)
            {
                foreach (GameObject gObject in currentCollisions)
                {
                    if(gObject != null)
                    {
                        Destroy(gObject);
                    }        
                }
                Destroy(gameObject);
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.tag == tag)
            {
                currentCollisions.Remove(collision.gameObject);
            }
        }

        private void OnDestroy()
        {
            try
            {
                myDropper.GetComponent<dropper>().numToSpawn += 1;
                scoreText.GetComponent<score>().UpdateScore(myValue);
                powerSlider.GetComponent<Power>().UpdatePower(myPower);
            }
            catch
            {
                //do nothing
            }
        }

        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                RaycastHit hitInfo = new RaycastHit();
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo) && hitInfo.collider.gameObject == gameObject)
                {
                    rend.material = highlightMaterial;
                    lineRenderer.SetPosition(0, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -5));
                    lineRenderer.enabled = true;
                }
                else
                {
                    rend.material = mainMaterial;
                }
            }

            if (Input.GetButton("Fire1") && lineRenderer.enabled == true)
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                lineRenderer.SetPosition(1, new Vector3(mousePos.x, mousePos.y, -5));
                powerCost.enabled = true;
                powerCost.transform.position = Input.mousePosition;
                Vector3 line = lineRenderer.GetPosition(0) - lineRenderer.GetPosition(1);
                powerCost.text = ((int)(line.magnitude * costModifier)).ToString();
            }

            if (Input.GetButtonUp("Fire1") && lineRenderer.enabled == true)
            {
                powerCost.enabled = false;
                Rigidbody rb = GetComponent<Rigidbody>();
                Vector3 line = lineRenderer.GetPosition(0) - lineRenderer.GetPosition(1);
                rb.AddForce(line * -1, ForceMode.Impulse);
                float cost = line.magnitude * -0.01f * costModifier;
                powerSlider.GetComponent<Power>().UpdatePower(cost);
                lineRenderer.enabled = false;
            }
        }
    }
}

