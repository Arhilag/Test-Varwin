using UnityEngine;
using Varwin;
using Varwin.Public;

namespace Varwin.Types.BallController_4b8448ba92b449c0b9bbbf96e7b6d51c
{
    [VarwinComponent(English: "Ball")]
    public class BallController : VarwinObject
    {
        private Rigidbody _bollRB;
        private Vector3 _startPosition;
        private Quaternion _startRotation;
        private MeshRenderer _mesh;
        //[ValueList("small sizes", "sizes")]
        //[Value(English: "Force")]
        //[Locale(SystemLanguage.Russian, "сила броска")]
        public int _force;
        [Variable(English: "Force", Russian: "сила броска")]
        public int ForceBall
        {
            get => _force;
            set => _force = value;
        }
        //[Checker(English:"Ball state")]
        //[Locale(SystemLanguage.Russian, "состояние шара")]
        //public int SlowKow()
        //{
        //    return 1;
        //}

        void Start()
        {
            _bollRB = GetComponent<Rigidbody>();
            _startPosition = transform.position;
            _startRotation = transform.rotation;
            _mesh = GetComponent<MeshRenderer>();
            //ThrowBoll(250);
        }

        [Action(English: "Throw ball")]
        [Locale(SystemLanguage.Russian, "бросить шар")]
        public void ThrowBoll(int force)
        {
            _bollRB.AddForce(transform.forward * -_force, ForceMode.Impulse);
            //_bollRB.AddForce(new Vector3(0,0,force), ForceMode.Impulse);
        }

        [Action(English: "Start state")]
        [Locale(SystemLanguage.Russian, "Стартовое положение")]
        public void StartState()
        {
            transform.position = _startPosition;
            transform.rotation = _startRotation;
            _bollRB.isKinematic = true;
            _bollRB.isKinematic = false;
        }

        public void SwitchColor()
        {
            _mesh.material.color = Color.red;
        }
    }
}
