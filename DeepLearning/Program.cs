using DataSets;
using NeuralNetworks.Core;

var model = new NeuralNetwork(
    new Layer(28 * 28),
    new Layer(10),
    new Layer(10)
    );

var trainData = MnistReader.ReadTrainingData().ToArray();

var numberOfImages = trainData.Length;

Console.WriteLine("numberOfImages " + numberOfImages);

model.ShowData();

//var a = trainData[0].Data;