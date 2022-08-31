using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientServiseAppMarshalau.Models.Base
{
    public abstract class BaseModel : INotifyPropertyChanged
    {
        private Guid id;
        private string imagePath { get; set; }

        public string Print()
        {
            return $"\r\t{this.Id,9}, {this.ImagePath, 50}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void PrChenged(string prName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prName));
        }

        public Guid Id
        {
            get { return this.id; }
            set
            {
                if (id == value)
                {
                    return;
                }
                this.id = value;
                PrChenged("idProp");
            }
        }

        public string ImagePath
        {
            get { return this.imagePath; }
            set
            {
                if (imagePath == value)
                {
                    return;
                }
                this.imagePath = value;
                PrChenged("imagePathProp");
            }
        }
    }
}
