using System;
using System.Collections.Generic;
using System.Text;

namespace FileDB
{
    public class PathModel
    {
        public required string FileType { get; set; }
        public required string ReadedFileBy { get; set; }
        public required string WorkType { get; set; }
        public required string Brand { get; set; }
        public required string Model { get; set; }
        public required string Year { get; set; }
        public required string CapacityEngine { get; set; }
        public required string EngineCode { get; set; }
        public required string ModuleName { get; set; }
        public required string ModuleNumber { get; set; }
        public required string ModuleSoftNumber { get; set; }
        public required string MemoryType { get; set; }
    }
}
