using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Udokotela.Model
{
    public class Branches
    {
        public string Name { get; set; }
        public ObservableCollection<Branches> SubBranches { get; set; }

        public Branches()
        {
            SubBranches = new ObservableCollection<Branches>();
        }

        public Branches(string name, ICollection<Branches> collection)
        {
            Name = name;
            SubBranches = new ObservableCollection<Branches>(collection);
        }
    }
}
