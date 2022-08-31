using ClientServiseAppMarshalau.Models.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Repository.Interface
{
    public interface IBaseRepositiry<T> where T : BaseModel
    {
        public ObservableCollection<T> GetAll();
        public T Get(Guid id);
        public T Create(T model);
        public T Update(T model);
        public bool Delete(Guid id);
    }
}
