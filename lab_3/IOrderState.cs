using System;

namespace Lab3
    {
    public interface IOrderState
    {
        bool ProcessNextStep(Order order);
        int StatusCode { get; }
    }
}
