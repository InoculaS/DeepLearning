using System;
using System.Linq;
using System.Collections.Generic;
using Core;

namespace NeuralNetworks.Core
{
    public class NeuralNetwork
    {
        public List<Layer> Layers { get; private set; }

        public NeuralNetwork(params Layer[] layers)
        {
            Layers = new List<Layer>(layers.Length);
            var inputLayer = layers.First();
            var outputLayer = layers.Last();
            var hiddenLayers = layers.Skip(1).Take(layers.Length - 2).ToList();
            InitLayers(inputLayer, outputLayer, hiddenLayers);
        }

        private void InitLayers(Layer inputLayer, Layer outputLayer, List<Layer> hiddenLayers)
        {
            inputLayer.LayerType = LayerType.Input;
            Layers.Add(inputLayer);

            hiddenLayers.ForEach(layer => layer.LayerType = LayerType.Hidden);
            Layers.AddRange(hiddenLayers);

            outputLayer.LayerType = LayerType.Output;
            Layers.Add(outputLayer);

            Layers.ForEach(x => x.Init());
        }

        public void ForwardPropogation(IEnumerable<Image> images)
        {

        }

        public void ShowData()
        {
            Console.WriteLine("LayersCount " + Layers.Count);
            int k = 1;
            foreach (var layer in Layers)
            {
                Console.WriteLine("Layer: " + k);
                Console.WriteLine("\tLayerType: " + layer.LayerType.ToString());
                Console.WriteLine("\tLayerNeuronsCount: " + layer.NeuronsCount);

                //if (layer.NeuronsCount < 11)
                {
                    for (int i = 0; i < layer.Neurons.Count; i++)
                    {
                        var neuron = layer.Neurons[i];
                        Console.WriteLine("\t\tNeuron {2}. W = {0}; B = {1}", neuron.Weight, neuron.Bias, i + 1);
                        if (i == 9) break;
                    }
                }
                Console.WriteLine();
                k++;
            }
        }
    }
}
