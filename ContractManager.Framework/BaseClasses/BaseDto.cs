﻿namespace ContractManager.Framework.BaseClasses
{
    public class BaseDto
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}