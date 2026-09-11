using System;
using System.Threading.Channels;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class StereoTypeAttribute : Attribute
{
    public string Name { get; }
    public string Description { get; }

    public StereoTypeAttribute(string name, string description = "")
    {
        Name = name;
        Description = description;
    }

    
}
