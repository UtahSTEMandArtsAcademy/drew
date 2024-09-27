string input = @"";
Dictionary<string, ushort> wires = new();
List<string> flagged = new();
//while(){}
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
static bool[] RShift(bool[] ba, int count)
{
    if(count == 0) return ba;
    bool last = ba[15];
    for(int i = 15; i >= 0; i--) ba[i] = ba[i-1];
    ba[0] = last;

    return RShift(ba, count - 1);
}
static bool[] LShift(bool[] ba, int count)
{
    if(count == 0) return ba;
    bool first = ba[0];
    for(int i = 0; i >= 15; i++) ba[i] = ba[i+1];
    ba[15] = first;

    return LShift(ba, count - 1);
}

void DoCmd()
{
    
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
        else
        {
            string wireIn1 = parts[0];
            string wireIn2 = parts[2];
            if(!wires.ContainsKey(wireIn1))
            {
                flagged.Add(wireIn1); 
                continue;
            }
            if(!wires.ContainsKey(wireIn2))
            {
                flagged.Add(wireIn2); 
                continue;
            }
            string command = parts[1];
            string wireOut = parts[4];
            if(command == "RSHIFT") wires[wireOut] = ConvertUShort(RShift(ConvertBA(wires[wireIn1]), int.Parse(wireIn2)));
            if(command == "LSHIFT") wires[wireOut] = ConvertUShort(LShift(ConvertBA(wires[wireIn1]), int.Parse(wireIn2)));
            if(command == "OR") wires[wireOut] = (ushort)(int.Parse(wireIn1) | int.Parse(wireIn2));
            if(command == "AND") wires[wireOut] = (ushort)(int.Parse(wireIn1) & int.Parse(wireIn2));
        }
    
    }
}
// for(int y = 0; y < 26; y++)
// {
//     for(int x = -1; x < 26; x++)
//     {
//         string pair = "";
//         char firstLetter = Convert.ToChar(97+x);
//         if(x != -1) pair += firstLetter;
//         char secondLetter = Convert.ToChar(97+y);
//         pair += secondLetter;
//         wires[pair] = 0;
//     }
// }
