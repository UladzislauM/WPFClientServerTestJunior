using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientServiseAppMarshalau.FilesCash;
using ClientServiseAppMarshalau.Models.Base;
using WpfApp1.Repository.Interface;

namespace WpfApp1.Repository.Implimentations
{
    public class BaseRepository<T> : IBaseRepositiry<T> where T : BaseModel
    {
        private ApplicationContext<T> Context { get; set; }
        private string pathSaveRep;

        public BaseRepository(ApplicationContext<T> context, string pathSaveRep)
        {
            Context = context;
            this.pathSaveRep = pathSaveRep;
        }

        public T Create(T model)
        {
            Context.SaveData(model);

            return model;
        }

        public bool Delete(Guid id)
        {
            if (Context.DeleteData(id))
            {
                return true;
            }
            return false;
        }

        public ObservableCollection<T> GetAll()
        {
            return Context.LoadData();
        }

        public T Update(T model)
        {
            return Context.Update(model);
        }

        public T Get(Guid id)
        {
            return Context.FindByIdInOC(id);
        }
    }
}
