string input = "R2, L5, L4, L5, R4, R1, L4, R5, R3, R1, L1, L1, R4, L4, L1, R4, L4, R4, L3, R5, R4, R1, R3, L1, L1, R1, L2, R5, L4, L3, R1, L2, L2, R192, L3, R5, R48, R5, L2, R76, R4, R2, R1, L1, L5, L1, R185, L5, L1, R5, L4, R1, R3, L4, L3, R1, L5, R4, L4, R4, R5, L3, L1, L2, L4, L3, L4, R2, R2, L3, L5, R2, R5, L1, R1, L3, L5, L3, R4, L4, R3, L1, R5, L3, R2, R4, R2, L1, R3, L1, L3, L5, R4, R5, R2, R2, L5, L3, L1, L1, L5, L2, L3, R3, R3, L3, L4, L5, R2, L1, R1, R3, R4, L2, R1, L1, R3, R3, L4, L2, R5, R5, L1, R4, L5, L5, R1, L5, R4, R2, L1, L4, R1, L1, L1, L5, R3, R4, L2, R1, R2, R1, R1, R3, L5, R1, R4";
// input = "R8, R4, R4, R8";
Vector2 pos = new Vector2(0,0);
int direction = 0;
List<Vector2> positions = new();
foreach(string Instructions in input.Split(", "))
{
    char dir = Instructions[0];
    string move = Instructions.Substring(1);
    if(dir == 'R')
    {
        direction++;
    }
    else
    {
        direction--;
    }
    if(direction > 3)
    {
        direction = 0;
    }
    else if (direction < 0) direction = 3;

    for(int i = 0; i < int.Parse(move); i++)
    {   
        if(direction == 0) pos.y ++;
        else if (direction == 2) pos.y --;
        else if (direction == 3) pos.x --;
        else if (direction == 1) pos.x ++;
        
        for(int j = 0; j < positions.Count; j++)
        {
            if(pos.x == positions[j].x && pos.y == positions[j].y)
            {   
                Console.WriteLine("overlap");
                Console.WriteLine(Math.Abs(pos.x) + Math.Abs(pos.y));
                // Console.WriteLine(positions[i].x);
                // Console.WriteLine(positions[i].y);
            }
            
            // Console.WriteLine(positions[j]);
        }
        positions.Add(pos);
    }
    // Console.WriteLine(pos);
    
}


struct Vector2{
    public int x;
    public int y;

    public Vector2(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public override String ToString(){
        return $"{x}, {y}";
    }
}