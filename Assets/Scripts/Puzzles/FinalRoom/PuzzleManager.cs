using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Puzzles
{
    namespace FinalRoom
    {
        public class PuzzleManager : MonoBehaviour
        {
            private static PuzzleManager _instance;

            public static PuzzleManager Instance { get { return _instance; } }

            private void Awake()
            {
                if (_instance != null && _instance != this)
                {
                    Destroy(this.gameObject);
                }
                else
                {
                    _instance = this;
                }
            }

            public GameObject pressurePlate;
            public GameObject displayPlane;
            public GameObject displayLight;

            public Material displayFalseMaterial;
            public Color displayFalseColor;
            public float glitchTimeFactor;

            private AudioSource audio;
            private float switchTime;

            void Start()
            {
                audio = GetComponent<AudioSource>();
            }

            void Update()
            {
                if (switchTime > 0 && !audio.isPlaying)
                {
                    SceneManager.LoadScene("EndCreditsScene");
                }
            }

            public void OnPressurePlateEnter(GameObject pressurePlate, GameObject triggerPerson)
            {
                Debug.Log("OnPressurePlateEnter called");

                if (pressurePlate == this.pressurePlate)
                    ChangeLoop();
            }

            private void ChangeLoop()
            {
                Debug.Log("ChangeLoop called");

                switchTime = Time.time;

                audio.Play();
                displayPlane.GetComponent<MeshRenderer>().material = displayFalseMaterial;
                displayLight.GetComponent<Light>().color = displayFalseColor;
                StartCoroutine(GlitchOut());
            }

            IEnumerator GlitchOut()
            {
                Camera mainCamera = Camera.main;
                Kino.DigitalGlitch effect = mainCamera.GetComponent<Kino.DigitalGlitch>();

                float intensity = 0f;

                while (intensity < 1f)
                {
                    float time = (Time.time - switchTime) * glitchTimeFactor;
                    intensity = Mathf.Lerp(0.0f, 1f, time);
                    effect.intensity = intensity;

                    yield return new WaitForEndOfFrame();
                }
            }
        }

    }
}
