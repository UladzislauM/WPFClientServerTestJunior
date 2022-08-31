using ClientServiseAppMarshalau.Models;
using ClientServiseAppMarshalau.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1;
using WpfApp1.Repository.Interface;

namespace ClientServiseAppMarshalau.Service.Implimentations
{
    internal class Service : IService
    {
        private IBaseRepositiry<Book> Book { get; set; }
        MainWindow mainWindow;

        public Service(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public void NewBook()
        {
           var bookId = Guid.NewGuid();

            Book.Create(new Book
            {
                Id = bookId,
                ImagePath = 
            });

            Workers.Create(new Worker
            {
                Id = workerId,
                Name = String.Format($"Worker{rand.Next()}"),
                Position = String.Format($"Position{rand.Next()}"),
                Telephone = String.Format($"8916{rand.Next()}{rand.Next()}{rand.Next()}{rand.Next()}{rand.Next()}{rand.Next()}{rand.Next()}")
            });

            var car = Cars.Get(carId);
            var worker = Workers.Get(workerId);

            Documents.Create(new Document
            {
                CarId = car.Id,
                WorkerId = worker.Id,
                Car = car,
                Worker = worker
            });
        }
    }
}
