using System;
using System.Collections.Generic;

namespace PinGenerator
{
    public class Generator
    {
        private List<string> pins;
        private const int BATCH_SIZE = 1000;


        public Generator(List<string> pins)
        {
            this.pins = pins;
        }


        public List<string> GetNewBatch()
        {
            Random rand = new Random();
            var pinBatch = new List<string>();
            var pinList = new List<string>(pins);

            for (int i = 0; i < BATCH_SIZE; i++)
            {
                int index = rand.Next(0, pinList.Count);
                string targetPin = pinList[index];
                pinBatch.Add(targetPin);
                pinList.Remove(targetPin);
            }

            return pinBatch;
        }
    }
}
