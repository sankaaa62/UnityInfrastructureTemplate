using UnityEngine;

namespace _Internal.Infrastructure.Services.Input
{
    public class MobileInputService : InputService
    {
        public override Vector2 Axis => GetSimpleInputAxis();
    }
}