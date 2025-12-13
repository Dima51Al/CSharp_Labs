
using System;

namespace Lab3
{
    public interface IPricingStrategy
    {
        float CalculateCost(Order order);
    }
}