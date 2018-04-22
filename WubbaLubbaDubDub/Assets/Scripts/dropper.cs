using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    public class dropper : MonoBehaviour
    {
        public Transform dropSpot;
        public GameObject[] shapes;
        public int numToSpawn = 3;
        public Text scoreText;
        public Text powerCost;
        public Image powerSlider;

        private void Start()
        {
            dropSpot = gameObject.transform;
            StartCoroutine(SpawnQueue());
        }

        // Update is called once per frame
        void Update()
        {
            //if (Input.GetButtonDown("Jump"))
            //{
            //    SpawnShape();
            //}
        }

        public IEnumerator SpawnQueue()
        {
            if(numToSpawn > 0)
            {
                SpawnShape();
                numToSpawn -= 1;
            }
            yield return new WaitForSeconds(.75f);
            yield return StartCoroutine(SpawnQueue());
        }

        public void SpawnShape()
        {
            GameObject myShape = Instantiate(shapes[Random.Range(0, shapes.Length)], dropSpot.position, Quaternion.identity);
            myShape.GetComponent<shape>().myDropper = gameObject;
            myShape.GetComponent<shape>().scoreText = scoreText;
            myShape.GetComponent<shape>().powerSlider = powerSlider;
            myShape.GetComponent<shape>().powerCost = powerCost;
        }
    }
}
