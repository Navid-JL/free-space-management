using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeSpaceManagement.Library;

public class FreeSpaceManager
{
    private List<FreeSpace> freeSpaces;

    public FreeSpaceManager()
    {
        freeSpaces = new List<FreeSpace>();
    }

    public void Initialize(int totalMemorySize)
    {
        freeSpaces.Clear();
        freeSpaces.Add(new FreeSpace(0, totalMemorySize));
    }

    public void Allocate(int processSize)
    {
        foreach (var space in freeSpaces)
        {
            if (space.Size >= processSize)
            {
                Console.WriteLine(
                    $"Allocated {processSize} units of memory from {space.StartAddress} to {space.StartAddress + processSize}"
                );
                space.StartAddress += processSize;
                return;
            }
        }

        Console.WriteLine("Insufficient memory for allocation.");
    }

    public void Deallocate(int startAddress, int endAddress)
    {
        FreeSpace newFreeSpace = new FreeSpace(startAddress, endAddress);
        freeSpaces.Add(newFreeSpace);
        freeSpaces.Sort((x, y) => x.StartAddress.CompareTo(y.StartAddress));

        Coalesce();
    }

    private void Coalesce()
    {
        for (int i = 0; i < freeSpaces.Count - 1; i++)
        {
            if (freeSpaces[i].EndAddress == freeSpaces[i + 1].StartAddress)
            {
                freeSpaces[i].EndAddress = freeSpaces[i + 1].EndAddress;
                freeSpaces.RemoveAt(i + 1);
                Coalesce(); // Recursively coalesce until no more coalescing is possible
                return;
            }
        }
    }

    public void DisplayMemoryStatus()
    {
        Console.WriteLine("\nCurrent Memory Status:");
        foreach (var space in freeSpaces)
        {
            Console.WriteLine($"Free space: {space.StartAddress} - {space.EndAddress}");
        }
        Console.WriteLine();
    }
}
