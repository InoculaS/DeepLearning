using System;
using System.Collections.Generic;

namespace NeuralNetworks.Core
{
    public class Layer
    {
        public Layer(int neuronsCount)
        {
            NeuronsCount = neuronsCount;
            Neurons = new List<Neuron>(neuronsCount);
        }

        public LayerType LayerType { get; set; }

        public List<Neuron> Neurons { get; private set; }

        public int NeuronsCount { get; private set; }

        public void Init()
        {
            var random = new Random();
            
            for (int i = 0; i < NeuronsCount; i++)
            {
                Neurons.Add(new Neuron
                {
                    Bias = (LayerType == LayerType.Input) ? 0.0 : (random.NextDouble() - 0.5),
                    Weight = LayerType == LayerType.Input ? 1.0 : (random.NextDouble() - 0.5)
                });
            }
        }
    }
}
