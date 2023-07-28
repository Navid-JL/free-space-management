using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeSpaceManagement.Library;

public class FreeSpace
{
    public int StartAddress { get; set; }
    public int EndAddress { get; set; }
    public int Size => EndAddress - StartAddress;

    public FreeSpace(int startAddress, int endAddress)
    {
        StartAddress = startAddress;
        EndAddress = endAddress;
    }
}
