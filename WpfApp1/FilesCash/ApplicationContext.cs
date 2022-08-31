using ClientServiseAppMarshalau.Models;
using ClientServiseAppMarshalau.Models.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientServiseAppMarshalau.FilesCash
{
    public class ApplicationContext<T> where T : BaseModel{

        private T entity;
        private string pathToFile;
        ApplicationContext(T entity, string pathToFile) { 
            this.entity = entity;
            this.pathToFile = pathToFile;
        }
   
        /// <summary>
        /// Serialization
        /// </summary>
        public void SaveData(object todoDataList)
        {
            using (StreamWriter writer = File.CreateText(pathToFile))
            {
                string output = JsonConvert.SerializeObject(todoDataList);
                writer.Write(output);
            }

        }

        /// <summary>
        /// Deserialization
        /// </summary>
        public ObservableCollection<T> LoadData()
        {
            var fileExist = File.Exists(pathToFile);
            if (!fileExist)
            {
                File.CreateText(pathToFile).Dispose();
                return new ObservableCollection<T>();
            }
            using (var reader = File.OpenText(pathToFile))
            {
                var fileText = reader.ReadToEnd();
                 return JsonConvert.DeserializeObject<ObservableCollection<T>>(fileText);
            }

        }

        /// <summary>
        /// Delete
        /// </summary>
        public bool DeleteData (Guid id)
        {
            var data = LoadData();
            entity = FindByIdInOC(id);
            if (data.Contains(entity))
            {
                data.Remove(entity);
                SaveData(data);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Find by id in ObservableCollection
        /// </summary>
        public T FindByIdInOC(Guid id)
        {
            var data = LoadData();
            foreach (var entityFind in data)
            {
                if (entityFind.Id == id)
                {
                    return entityFind;
                }
            }
            return null;//Bad practice... (but this programm - test Junior)
        }

        /// <summary>
        /// Update
        /// </summary>
        public T Update(T entity)
        {
            var data = LoadData();
            foreach (var entityFind in data)
            {
                if (entityFind == entity)
                {
                    data.Insert(data.IndexOf(entityFind), entity);
                    return entity;
                }
            }
            return null;//Bad practice... (but this programm - test Junior)
        }
    }
}
