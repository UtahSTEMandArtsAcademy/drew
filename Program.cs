string input = @"";
Dictionary<string, ushort> wires = new();

static bool[] ConvertBA (ushort signal)
{
    bool[] result = new bool[16];
    for(int i = 0; i < 16; i++){
        int value = (int)Math.Pow(2, 15-i);
        if(signal >= value)
        {
            result[i] = true;
            signal -= (ushort)value;
        }
    }
    return result;
}
static ushort ConvertUShort (bool[] signal)
{
    ushort result = 0;
    for(int i = 0; i < 16; i++){
        int value = (int)Math.Pow(2, 15-i);
        if(signal[i])
        {
            result += (ushort)value;
        }
    }
    return result;
}
for(int y = 0; y < 26; y++)
{
    for(int x = -1; x < 26; x++)
    {
        string pair = "";
        char firstLetter = Convert.ToChar(97+x);
        if(x != -1) pair += firstLetter;
        char secondLetter = Convert.ToChar(97+y);
        pair += secondLetter;
        wires[pair] = 0;
    }
}
foreach(string cmd in input.Split("\n"))
{
    string[] parts = cmd.Split(" ");
    if(parts.Length == 3)
    {
        wires[parts[2]] = ushort.Parse(parts[0]);
    }
    else if(parts.Length == 4)
    {
      wires[parts[2]] = (ushort)~wires[parts[2]];
    }
    

}
