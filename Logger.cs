using System.IO;

namespace Learining2;

public class Logger
{
    private StreamWriter writetext;
    public Logger()
    {
        writetext = new StreamWriter("D:\\godot\\learining_copy\\data.csv");
    }
    public void Log(Main_char mc)
    {
        writetext.WriteLine(
            ((int)mc.Position.X).ToString() + "," 
            + ((int)mc.Position.Y).ToString() + "," 
            + ((int)mc.Velocity.X).ToString() + ","
            + ((int)mc.Velocity.Y).ToString() + ","
            + mc.PressedButton
        );
    
    }
}