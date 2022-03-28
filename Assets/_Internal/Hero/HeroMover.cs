using _Internal.Infrastructure.Services;
using _Internal.Infrastructure.Services.Input;
using UnityEngine;

namespace _Internal.Hero
{
    public class HeroMover : MonoBehaviour
    {
        public CharacterController CharacterController;
        public float MovementSpeed;
        
        private IInputService _inputService;
        private Camera _camera;

        private void Awake()
        {
            _inputService = AllServices.Container.Single<IInputService>();
        }

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            Vector3 movementVector = Vector3.zero;

            if (_inputService.Axis.sqrMagnitude > Constants.Epsilon)
            {
                movementVector = _camera.transform.TransformDirection(_inputService.Axis);
                movementVector.y = 0;
                //movementVector.Normalize();

                transform.forward = movementVector;
            }

            movementVector += Physics.gravity;
            CharacterController.Move(MovementSpeed * movementVector * Time.deltaTime);
        }
    }
}
