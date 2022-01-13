using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeConsole.Data
{
    public class Employment
    {
        private string _title;

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Title is required piece of data.");
                }

                // Data is considered valid
                _title = value;

            }
        }
    }
}
