using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLiveStock.DataContrats;
using MyLiveStock.DataAccess;
using Entity;
using System.Globalization;

namespace MyLiveStock.Service
{
    public class RabbitService : IRabbitService
    {
        private readonly Repository _repository;

        public RabbitService()
        {
            _repository = new Repository();
        }

        public Rabbit GetRabbit(string id)
        {
            return _repository.GetRabbit(id);
        }

        public List<Rabbit> GetRabbits()
        {
            return _repository.GetRabbits();
        }

        public Productrice GetProductrice(string id)
        {
            return _repository.GetProductrice(id);
        }

        public List<Productrice> GetProductrices()
        {
            return _repository.GetProductrices();
        }

        public MiseBas GetMiseBas(string id)
        {
            return GetMiseBas(id);
        }

        public List<MiseBas> GetMiseBas()
        {
            return GetMiseBas();
        }

        public Saillie GetSaillie(string id)
        {
            return _repository.GetSaillie(id);
        }

        public List<Saillie> GetSaillies()
        {
            return _repository.GetSaillies();
        }

        public List<Evenement> GetEvenement()
        {
            return _repository.GetEvenement();
        }

        public string CreateRabbit(string matricule, string color, string date, string type, string gender, string fileName, string poids)
        {
            var dat = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var id = _repository.CreateRabbit(matricule, color, dat, type, gender, fileName, poids);
            return id;
        }

        public string UpdateRabbit(string id, string matricule, string date, string type, string gender, string color, string fileName, string poids)
        {
            var dat = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var idRabbit = _repository.UpdateRabbit(id, matricule, dat, type, gender, color, fileName, poids);
            return id;
        }

        public void DeleteRabbit(string id)
        {
            _repository.DeleteRabbit(id);
        }

        public string CreateMiseBas(string id, string observation, string idSaillie, int portee, string date, string idMale)
        {
            var dateCreate = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var idRabbit = _repository.CreateMiseBas(id, observation, idSaillie, portee, dateCreate, idMale);
            return idRabbit;
        }

        public void DeleteMiseBas(string id)
        {
            _repository.DeleteMiseBas(id);
        }

        public string CreateSaillie(string id, string observation, string date, string idMale)
        {
            var dateCreate = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var idRabbit = _repository.CreateSaillie(id, observation, dateCreate, idMale);
            return idRabbit;
        }

        public void DeleteSaillie(string id, string idRabbit)
        {
            _repository.DeleteSaillie(id, idRabbit);
        }

        public string UpdateSaillie(string id, string observation, string date, string idMale, string idSaillie)
        {
            var dateCreate = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var idRabbit = _repository.UpdateSaillie(id, observation, dateCreate, idMale, idSaillie);
            return idRabbit;
        }

        public void DeathNote(string id, string mat, string date, string cause)
        {
            var dateCreate = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            _repository.DeathNote(id, mat, dateCreate, cause);
        }

        public void SevrateYoungRabbit(string idRabbit, string matMisebas)
        {
            _repository.SevrateYoungRabbit(idRabbit, matMisebas);
        }
    }
}
