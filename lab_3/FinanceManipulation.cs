using System;

namespace Lab3
{
    public class FinanceManipulation
    {
        public float NDS = 0.20f; // уже 22 :((((
        public float Nacenka;
        public FinanceManipulation(float nds = 0.20f, float nacenka= 1.1f)
        {
            NDS = nds;
            Nacenka = nacenka;
        }

        public float GetMarja()
        {
            return 1 / (1 - NDS) * Nacenka;
        }


    }    
}