using System.Collections.Generic;

namespace CloudLibrary.Model
{
    public class Infrastructure
    {
        public Infrastructure()
        {
            VirtualMachines = new List<VirtualMachine>();
            Databases = new List<Database>();
        }
        public string Name { get; set; }
        public string Provider { get; set; }
        public IList<VirtualMachine> VirtualMachines { get; set; }
        public IList<Database> Databases { get; set; }
    }

}
