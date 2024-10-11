using System.Collections.Specialized;
string input = @"x AND y -> d
x OR y -> e
x LSHIFT 2 -> f
y RSHIFT 2 -> g
NOT x -> h
NOT y -> i
123 -> x
456 -> y";
string[] cmds = input.Split('\n');
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
void Remove(string target)
{
   StringCollection strings = new();
   strings.AddRange(cmds);
   strings.Remove(target);
   cmds = new string[strings.Count];
   strings.CopyTo(cmds, 0);
}
int maxRuns = 1000;
void DoCmds()
{
    foreach(string cmd in cmds)
    {
        Console.WriteLine(cmd);
        string[] parts = cmd.Split(" ");

        if(parts.Length == 3)
        {
            string val = parts[0];
            string to = parts[2];
            wires[to] = ushort.Parse(val);
            Console.WriteLine("assiged wire: " + to);
            Remove(cmd);
        }
        else if(parts.Length == 4)
        {
            
            // Running the not bitwise opperand | NOT {val} -> {to}
            string wire1 = parts[1];
            string wireOut = parts[3];
            if(!wires.ContainsKey(wire1))
             {
                Console.WriteLine("unknown  NOT wire: " + wire1);
                
                continue;
             }
            wires[wireOut] = ConvertUShort(Not(ConvertBA(wires[wire1])));
            Remove(cmd);
        }
        else
        {
            string wireIn1 = parts[0];
            string wireIn2 = parts[2];
            if(!wires.ContainsKey(wireIn1))
             {
                Console.WriteLine("unknown first wire: " + wireIn1);
                continue;
             }
            if(!wires.ContainsKey(wireIn2))
             {
                Console.WriteLine("unknown second wire: " + wireIn2);

                continue;
             }
             else
             {
                if
             }
            string command = parts[1];
            string wireOut = parts[4];
            if(command == "RSHIFT") wires[wireOut] = ConvertUShort(RShift(ConvertBA(wires[wireIn1]), int.Parse(wireIn2)));
            if(command == "LSHIFT") wires[wireOut] = ConvertUShort(LShift(ConvertBA(wires[wireIn1]), int.Parse(wireIn2)));
            if(command == "OR") wires[wireOut] = (ushort)(wires[wireIn1] | wires[wireIn2]);
            if(command == "AND") wires[wireOut] = (ushort)(wires[wireIn1] & wires[wireIn2]);
            Remove(cmd);
        }
    
    }
}

do
{

    if(--maxRuns <= 0) break;

    DoCmds();
}
while(cmds.Length > 0);

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
