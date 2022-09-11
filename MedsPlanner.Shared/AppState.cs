using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedsPlanner.Shared
{
    public class AppState
    {
        //public bool DisplayDetails { get; set; } = true;

        private bool displayDetails;

        public bool DisplayDetails
        {
            get => displayDetails;
            set
            {
                displayDetails = value;
                NotifyStateChanged();
            }
        }

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
