string input = @"";
Dictionary<string, ushort> wires = new();

Console.WriteLine((ushort)(123 | 456));
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
static bool[] Not(bool[] ba)
{
    for(int i = 0; i < 16; i++)
    {
        ba[i] = !ba[i];
    }
    return ba;
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
        string val = parts[0];
        string to = parts[2];
        wires[to] = ushort.Parse(val);
    }
    else if(parts.Length == 4)
    {
        string val = parts[1];
        string to = parts[3];
      wires[to] = ConvertUShort(Not(ConvertBA(ushort.Parse(val))));
    }
    else if(parts.Contains("O"))
    {
        string val1 = parts[0];
        string val2 = parts[2];
        string to = parts[4];
        wires[to] = (ushort)(int.Parse(val1) | int.Parse(val2));
    }
    else if(parts.Contains("RS"))
    {

    }
    else if(parts.Contains("L"))
    {

    }
    else if(parts.Contains("A"))
    {

    }
}
