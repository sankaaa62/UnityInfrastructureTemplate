using UnityEngine;

namespace _Internal.Infrastructure.Services.Input
{
    public abstract class InputService : IInputService
    {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";
        protected const string FireButton = "Fire";

        public abstract Vector2 Axis { get; }

        public bool IsAttackButtonUp() => 
            SimpleInput.GetButtonUp(FireButton);

        protected static Vector2 GetSimpleInputAxis() => 
            new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
    }
}