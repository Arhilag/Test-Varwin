using UnityEngine;
using Varwin;
using Varwin.Public;

namespace Varwin.Types.Bowlingpin_0c565eef6a3c4d91b1a6da542c576fd8
{
    [VarwinComponent(English: "Bowlingpin")]
    public class Bowlingpin : VarwinObject
    {
        [SerializeField] private ParticleSystem _particle;
        [SerializeField] private GameObject _head;

        private Vector3 _startPosition;
        private Quaternion _startRotation;
        private Rigidbody _keglRB;
        private AudioSource _audio;
        public enum PinState { stand, down}
        public PinState PinPos;
        [Variable(English: "StatePin", Russian: "положение кегли")]
        public PinState GetStatePin
        {
            get => PinPos;
        }

        private float _startPosHead;
        public delegate void PinEventHandler();

        [Event(English: "Stand", Russian: "Стоит")]
        public event PinEventHandler StandEvent;
        [Event(English: "Down", Russian: "Упала")]
        public event PinEventHandler DownEvent;

        private void Start()
        {
            _startPosition = transform.position;
            _startRotation = transform.rotation;
            _keglRB = GetComponent<Rigidbody>();
            _audio = GetComponent<AudioSource>();
            StartState();
        }

        private void FixedUpdate()
        {
            if(PinPos == PinState.stand && _head.transform.position.y < _startPosHead-0.2f)
            {
                Debug.Log("упала");
                PinPos = PinState.down;
                _particle.Play();
                _audio.Play();
                DownEvent?.Invoke();
            }
        }

        [Action(English: "Start state")]
        [Locale(SystemLanguage.Russian, "Стартовое положение")]
        public void StartState()
        {
            transform.position = _startPosition;
            transform.rotation = _startRotation;
            _keglRB.isKinematic = true;
            _keglRB.isKinematic = false;
            PinPos = PinState.stand;
            _particle.Stop();
            _audio.Stop();
            _startPosHead = _head.transform.position.y;
            StandEvent?.Invoke();
        }
    }
}
