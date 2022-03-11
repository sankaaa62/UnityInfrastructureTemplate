﻿using UnityEngine;

namespace _Internal.Infrastructure.Services.Input
{
    public interface IInputService
    {
        Vector2 Axis { get; }

        bool IsAttackButtonUp();
    }
}