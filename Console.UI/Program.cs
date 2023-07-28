using FreeSpaceManagement.Library;

FreeSpaceManager manager = new FreeSpaceManager();
int totalMemorySize = 100; // Total memory size in units
manager.Initialize(totalMemorySize);
manager.DisplayMemoryStatus();
manager.Allocate(30);
manager.Allocate(20);
manager.Allocate(10);
manager.DisplayMemoryStatus();
manager.Deallocate(30, 60);
manager.DisplayMemoryStatus();
manager.Allocate(25);
manager.DisplayMemoryStatus();
