
using System;

namespace Lab3
{

    public class CompletedState : IOrderState
    {
        public int StatusCode => 4;

        public bool ProcessNextStep(Order order)
        {
            return false;
        }
    }

}


