using System.Text.Json;

using var sr = new StreamReader("Source.dat");

var nestedDict = new Dictionary<int, SortedDictionary<int, string>>();
string? line;
while ((line = sr.ReadLine()) != null)
{
    var fileNane = line.Split("/")[4];
    var splitFileName = fileNane.Replace(".jpg", "").Split("-");
    var key = int.Parse(splitFileName[4].Replace("C", ""));
    var innerKey = int.Parse(splitFileName[5]);
    if (nestedDict.ContainsKey(key))
    {
        nestedDict[key][innerKey] = line;
    }
    else
    {
        nestedDict[key] = new SortedDictionary<int, string>
        {
            [innerKey] = line
        };
    }
}

var outputs = new List<string>();
foreach (var (key, innerDict) in nestedDict)
{
    Console.WriteLine($"The number {key} camera");
    var values = innerDict.Values.ToArray();
    var jsonString = JsonSerializer.Serialize(values);
    var content = jsonString.Replace( @"""", @"\""");
    outputs.Add($"\"{content}\"");
}

using var writer = new StreamWriter("Ouput.dat");
foreach (var data in outputs)
{
    writer.WriteLine(data);
    writer.WriteLine();
}

