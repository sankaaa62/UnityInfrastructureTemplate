using UnityEngine;

namespace _Internal.Infrastructure.Services.Input
{
    public interface IInputService : IService
    {
        Vector2 Axis { get; }

        bool IsAttackButtonUp();
    }
}